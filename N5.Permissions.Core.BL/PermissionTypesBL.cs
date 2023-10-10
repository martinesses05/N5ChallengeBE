using AutoMapper;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Core.BL
{
    // TODO: create a abstract generic BL for CRUD operations
    public class PermissionTypesBL : IPermissionTypesBL
    {
        private readonly IAppDBContext _dbContext;
        private readonly IMapper _mapper;

        public PermissionTypesBL(IAppDBContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
              
        public PagedListResponse<PermissionTypeDTO> Get(PermissionTypesFilter filter)
        {
            var query = _dbContext.PermissionTypes
                .OrderBy(e => e.Description)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.FreeText))
            {
                var freeText = filter.FreeText.ToLower().Trim();

                query = query.Where(e =>
                    e.Description.ToLower().Trim().Contains(freeText)
                );
            }

            var list = query.Skip(filter.PageSize * (filter.Page - 1)).Take(filter.PageSize).ToList();

            return new PagedListResponse<PermissionTypeDTO> 
            {
                Count  = query.Count(),
                List = _mapper.Map<IList<Entities.PermissionType>, IList<DTOs.PermissionTypeDTO>>(list)
            };            
        }

        public PermissionTypeDTO GetById(int id)
        {
            var entity = _dbContext.PermissionTypes.Single(e => e.Id == id);
            return _mapper.Map<Entities.PermissionType, DTOs.PermissionTypeDTO>(entity);
        }

        public PermissionTypeDTO Create(PermissionTypeDTO dto)
        {            
            var entity = new Entities.PermissionType
            {
                Description = dto.Description                
            };

            _dbContext.PermissionTypes.Add(entity);
            _dbContext.Save();

            return _mapper.Map<Entities.PermissionType, DTOs.PermissionTypeDTO>(entity);
        }
        public PermissionTypeDTO Update(PermissionTypeDTO dto)
        {
            var entity = _dbContext.PermissionTypes.Single(e => e.Id == dto.Id);            
            entity.Description = dto.Description;            

            _dbContext.Save();

            return _mapper.Map<Entities.PermissionType, DTOs.PermissionTypeDTO>(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.PermissionTypes.Single(e => e.Id == id);

            _dbContext.PermissionTypes.Remove(entity);
            _dbContext.Save();
        }     
    }
}