namespace Api.Controllers.Events;

[Route("api/event")]
[ApiController]
public class EventController(IEventService eventService) : Controller
{
    private readonly IEventService _eventService = eventService;

    // get all events
    [HttpGet("get")]
    public async Task<ActionResult<List<Event>>> GetAllEvents()
    {
        try
        {
            var events = await _eventService.GetAllEvents();
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
            var events = await _eventService.GetEventById(id);
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
            var events = await _eventService.GetEventByName(name);
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
            await _eventService.AddEvent(newEvent);
            return Ok(newEvent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    //delete event
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Event>> DeleteEvent(int id)
    {
        try
        {
            var deletedEvent = await _eventService.RemoveEvent(id);
            if (deletedEvent == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(deletedEvent.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // Update event
    [HttpPut("update/{id}")]
    public async Task<ActionResult<Event>> UpdateEvent(int id, Event ev)
    {
        try
        {
            var updatedEvent = await _eventService.UpdateEvent(id, ev);
            if (updatedEvent == null)
            {
                return NotFound("Event not found.");
            }
            return Ok(updatedEvent);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}


