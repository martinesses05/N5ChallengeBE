using Microsoft.AspNetCore.Mvc;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Endpoints.Default.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypesController : ControllerBase
    {
        // TODO: create a generic base controller for CRUD operations
        private readonly IPermissionTypesBL _bl;

        public PermissionTypesController(IPermissionTypesBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public ActionResult<PagedListResponse<PermissionTypeDTO>> Get([FromQuery] PermissionTypesFilter filter)
        {
            return _bl.Get(filter);
        }

        [HttpGet("{id}")]
        public ActionResult<PermissionTypeDTO> Get(int id)
        {
            return _bl.GetById(id);
        }

        [HttpPost]
        public PermissionTypeDTO Post([FromBody] PermissionTypeDTO dto)
        {
            return _bl.Create(dto);
        }

        [HttpPut]
        public PermissionTypeDTO Put(PermissionTypeDTO dto)
        {
            return _bl.Update(dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bl.Delete(id);
        }     
    }
}