using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gomomentus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly JsonPlaceholderService _jsonPlaceholderService;

        public DataController(JsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet("refresh")]
public async Task<IActionResult> RefreshData()
{
    try
    {
        await _jsonPlaceholderService.RefreshDataFromSourceAsync();
        return Ok(new { message = "Data refreshed successfully" });
    }
    catch (Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while refreshing the data.");
    }
}

    }
}
