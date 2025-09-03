using BAL.Services;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController(UserService userService) : ControllerBase
    {
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(int userTypeId, int printed, string? code)
        {
            var result = await userService.GetForPrintCards(userTypeId, printed, code);
            return Ok(ApiResponse.OK(result));
        }
    }
}
