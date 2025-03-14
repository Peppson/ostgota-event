namespace Api.Controllers.Tickets;

[Route("api/ticket")]
[ApiController]
public class TicketController(ITicketService ticketService, Validator validator) : Controller
{
    private readonly ITicketService _ticketService = ticketService;
    private readonly Validator _validator = validator;


    [HttpGet("get")]
    public async Task<ActionResult<List<TicketGetDTO>>> GetAllTickets()
    {
        try
        {
            var tickets = await _ticketService.GetAllTickets();
            var dto = GetTicketGetDTO(tickets);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<TicketDTO>> CreateTicket(TicketDTO ticketDto)
    {   
        var validation = _validator.Validate(new TicketValidator(), ticketDto);
        if (validation != null)
            return validation;


        // ticket price to a free event
        // if event = free price = 0

        // TODO mapping here 
        
        try
        {
            await _ticketService.AddTicket(ticketDto);
            return Ok(ticketDto);
        }
        catch (InvalidOperationException ex)  
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{ticketId}")]
    public async Task<ActionResult<int>> DeleteTicket(int ticketId)
    {
        try
        {   
            if (!await _ticketService.RemoveTicket(ticketId))
                return NotFound("Ticket not found.");

            return Ok(ticketId);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private List<TicketGetDTO> GetTicketGetDTO(List<Ticket> tickets)
    {
        return tickets.Select(t => new TicketGetDTO
        {
            Id = t.Id,
            UserId = t.UserId,
            EventId = t.EventId,
            Price = t.Price,
            Seat = t.Seat
        }).ToList();
    }

    private TicketDTO GetTicketDTO(Ticket ticket)
    {
        return new TicketDTO
        {
            Id = ticket.Id,
            UserId = ticket.UserId,
            EventId = ticket.EventId,
            Price = ticket.Price,
            Seat = ticket.Seat
        };
    }
}
