namespace Api.Controllers.Events;

[Route("api/event")]
[ApiController]
public class EventController(IEventService eventService, Validator validator) : Controller
{
    private readonly IEventService _eventService = eventService;
    private readonly Validator _validator = validator;


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

    [HttpPost("create")]
    public async Task<ActionResult<Event>> CreateEvent([FromBody] EventCreateDTO ev)
    {
        var validation = _validator.Validate(new EventCreateValidator(), ev);
        if (validation != null)
            return validation;

        var newEvent = new Event 
        {
            Name = ev.Name,
            Description = ev.Description,
            City = ev.City,
            Address = ev.Address,
            AccessType = ev.AccessType,
            StartTime = ev.StartTime,
            EndTime = ev.EndTime,
            HasSeat = ev.HasSeat,
            ImagePath = ev.ImagePath,
            TicketsMax = ev.TicketsMax,
            TicketsSold = 0,
            Price = ev.Price
        };

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

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Event>> UpdateEvent(int id, [FromBody] EventUpdateDTO ev)
    {
        var validation = _validator.Validate(new EventUpdateValidator(), ev);
        if (validation != null)
            return validation;
        
        var newEvent = new Event
        {
            Id = id,
            Name = ev.Name,
            Description = ev.Description,
            City = ev.City,
            Address = ev.Address,
            AccessType = ev.AccessType,
            StartTime = ev.StartTime,
            EndTime = ev.EndTime,
            HasSeat = ev.HasSeat,
            ImagePath = ev.ImagePath,
            TicketsMax = ev.TicketsMax,
            TicketsSold = ev.TicketsSold,
            Price = ev.Price
        };

        try
        {
            var updatedEvent = await _eventService.UpdateEvent(id, newEvent);
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
