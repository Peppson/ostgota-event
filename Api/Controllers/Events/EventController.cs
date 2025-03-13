using Api.Controllers.EventValidation;

namespace Api.Controllers.Events;

[Route("api/event")]
[ApiController]
public class EventController(IEventService eventService) : Controller
{
    private readonly IEventService _eventService = eventService;


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

    [HttpPost("create")]
    public async Task<ActionResult<Event>> CreateEvent(Event newEvent)
    {

        var validator = new EventValidator();
        var result = validator.Validate(newEvent);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(x => new
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }));
        }

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

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Event>> UpdateEvent(int id, Event ev)
    {

        var validator = new EventValidator();
        var result = validator.Validate(ev);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors.Select(x => new
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }));
        }
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
