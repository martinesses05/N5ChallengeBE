using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Core.BL
{
    // TODO: create a abstract generic BL for CRUD operations
    public class PermissionsBL : IPermissionsBL
    {
        private readonly IAppDBContext _dbContext;
        private readonly IMapper _mapper;

        public PermissionsBL(IAppDBContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
              
        public PagedListResponse<PermissionDTO> Get(PermissionsFilter filter)
        {
            var query = _dbContext.Permissions.Include(e=>e.PermissionType)
                .OrderBy(e => e.EmployeeName)
                .ThenBy(e => e.EmployeeSurname)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.FreeText))
            {
                var freeText = filter.FreeText.ToLower().Trim();

                query = query.Where(e =>
                    e.EmployeeName.ToLower().Trim().Contains(freeText) ||
                    e.EmployeeSurname.ToLower().Trim().Contains(freeText)
                );
            }

            var list = query.Skip(filter.PageSize * (filter.Page - 1)).Take(filter.PageSize).ToList();

            return new PagedListResponse<PermissionDTO> 
            {
                Count  = query.Count(),
                List = _mapper.Map<IList<Entities.Permission>, IList<DTOs.PermissionDTO>>(list)
            };            
        }

        public PermissionDTO GetById(int id)
        {
            var entity = _dbContext.Permissions.Include(e => e.PermissionType).Single(e => e.Id == id);
            return _mapper.Map<Entities.Permission, DTOs.PermissionDTO>(entity);
        }

        public PermissionDTO Create(PermissionDTO dto)
        {
            var permissionType = _dbContext.PermissionTypes.Single(e => e.Id == dto.PermissionTypeId);

            var entity = new Entities.Permission
            {
                EmployeeName = dto.EmployeeName,
                EmployeeSurname = dto.EmployeeSurname,
                PermissionDate = dto.PermissionDate,
                PermissionType = permissionType
            };

            _dbContext.Permissions.Add(entity);
            _dbContext.Save();

            return _mapper.Map<Entities.Permission, DTOs.PermissionDTO>(entity);
        }
        public PermissionDTO Update(PermissionDTO dto)
        {
            var entity = _dbContext.Permissions.Single(e => e.Id == dto.Id);
            entity.PermissionType = _dbContext.PermissionTypes.Single(e => e.Id == dto.PermissionTypeId);
            entity.EmployeeName = dto.EmployeeName;
            entity.EmployeeSurname = dto.EmployeeSurname;
            entity.PermissionDate = dto.PermissionDate;

            _dbContext.Save();

            return _mapper.Map<Entities.Permission, DTOs.PermissionDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Permissions.Single(e => e.Id == id);

            _dbContext.Permissions.Remove(entity);
            _dbContext.Save();
        }     
    }
}