using Microsoft.AspNetCore.Mvc;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.DTOs;
using N5.Permissions.Core.DTOs.Common;
using N5.Permissions.Core.DTOs.Filters;

namespace N5.Permissions.Endpoints.Default.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionsController : ControllerBase
    {
        // TODO: create a generic base controller for CRUD operations
        private readonly IPermissionsBL _bl;

        public PermissionsController(IPermissionsBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public ActionResult<PagedListResponse<PermissionDTO>> Get([FromQuery] PermissionsFilter filter)
        {
            return _bl.Get(filter);
        }

        [HttpGet("{id}")]
        public ActionResult<PermissionDTO> Get(int id)
        {
            return _bl.GetById(id);
        }

        [HttpPost]
        public PermissionDTO Post([FromBody] PermissionDTO dto)
        {
            return _bl.Create(dto);
        }

        [HttpPut]
        public PermissionDTO Put(PermissionDTO dto)
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