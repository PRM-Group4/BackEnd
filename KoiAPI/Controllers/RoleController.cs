using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Services.IServices;
using Services.Modal.Request;

namespace KoiAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class RoleController : ODataController
    {
         private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }


        //[Authorize(Roles = "Staff")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole(int id, RoleRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool isUpdated = await _service.Update(id, dto);

                if (isUpdated)
                {
                    // Return a success response
                    return Ok();
                }
                else
                {
                    // Return a not found response if the service was not updated successfully
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Return a bad request response for any other exceptions
                return BadRequest();
            }
        }
        //[EnableQuery]
        //[Authorize(Roles = "Staff")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateRole(RoleRequest dto)
        {
            try
            {
                var data = await _service.Create(dto);
                if (data == null)
                {
                    return BadRequest();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }

        //[EnableQuery]
        //[Authorize(Roles = "Staff")]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        //[EnableQuery]
        //[Authorize(Roles = "Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            try
            {
                var result = await _service.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //[EnableQuery]
        //[Authorize(Roles = "Staff")]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
