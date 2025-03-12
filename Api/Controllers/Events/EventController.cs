namespace Api.Controllers.Events;

[Route("api/event")]
[ApiController]
public class EventController(IDataService dataService) : Controller
{
    private readonly IDataService _dataService = dataService;

    [HttpGet("get")]
    public async Task<ActionResult<List<Event>>> GetAllEvents()
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
