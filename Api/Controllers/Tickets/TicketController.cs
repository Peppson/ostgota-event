namespace Api.Controllers.Tickets;

[Route("api/ticket")]
[ApiController]
public class TicketController(ITicketService ticketService, Validator validator) : Controller
{
    private readonly ITicketService _ticketService = ticketService;
    private readonly Validator _validator = validator;


    [HttpGet("get")]
    public async Task<ActionResult<List<TicketDTO>>> GetAllTickets()
    {
        try
        {
            var tickets = await _ticketService.GetAllTickets();
            var dto = TicketGetDTO(tickets);
            return Ok(dto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<TicketDTO>> CreateTicket(TicketCreateDTO dto)
    {   
        var validation = _validator.Validate(new TicketValidator(), dto);
        if (validation != null)
            return validation;

        try
        {
            var result = await _ticketService.AddTicket(dto.UserId, dto.EventId, dto.Price, dto.Seat);
            var ticket = GetTicketDTO(result!);
            return Ok(ticket);
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

    private static List<TicketDTO> TicketGetDTO(List<Ticket> tickets)
    {
        return tickets.Select(t => new TicketDTO
        {
            Id = t.Id,
            UserId = t.UserId,
            EventId = t.EventId,
            Price = t.Price,
            Seat = t.Seat
        }).ToList();
    }

    private static TicketDTO GetTicketDTO(Ticket ticket)
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
