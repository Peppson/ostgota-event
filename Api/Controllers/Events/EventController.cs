namespace Api.Controllers.Events;

[Route("api/event")]
[ApiController]
public class EventController(IDataService dataService) : Controller
{
    private readonly IDataService _dataService = dataService;


    // get all events
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

    // Get event by id 
    [HttpGet("get/id/{id}")]
    public async Task<ActionResult<Event>> GetEventById(int id)
    {
        try
        {
            var events = await _dataService.GetEventById(id);
            if (events == null)
            {
                return NotFound($"Event with id: {id} was not found");
            }
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // Get event by name
    [HttpGet("get/name/{name}")]
    public async Task<ActionResult<Event>> GetEventByName(string name)
    {
        try
        {
            var events = await _dataService.DoesEventExist(name);
            if (events == null)
            {
                return NotFound($"Event with name: {name} was not found");
            }
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    //create event 
    [HttpPost("create")]
    public async Task<ActionResult<Event>> CreateEvent(Event newEvent)
    {
        try
        {
            await _dataService.AddEvent(newEvent);
            return Ok(newEvent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    //delete event
    [HttpDelete("delete")]
    public async Task<ActionResult<Event>> DeleteEvent(int id)
    {
        try
        {
            await _dataService.RemoveEvent(id);
            return Ok(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


}


