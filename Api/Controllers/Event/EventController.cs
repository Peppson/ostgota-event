namespace Api.Controllers.Event;

[Route("api/event")]
[ApiController]
public class EventController(IDataService dataService) : Controller
{
    private readonly IDataService _dataService = dataService;

    [HttpGet("get")]
    public async Task<ActionResult<List<Data.Models.Event>>> GetAllEvents()
    {
        try
        {
            var events = await _dataService.GetAllEvents();
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
