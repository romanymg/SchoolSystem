using BAL.Services;
using Common.DTOs;
using Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController(UserService userService) : ControllerBase
    {
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var result = await userService.GetAll((int)UserTypeEnum.Student);
            return Ok(ApiResponse.OK(result));
        }
    }
}
