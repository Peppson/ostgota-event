namespace Api.Controllers.Tickets;

[Route("api/ticket")]
[ApiController]
public class TicketController(ITicketService ticketService) : Controller
{
    private readonly ITicketService _ticketService = ticketService;


    [HttpGet("get")]
    public async Task<ActionResult<List<TicketDTO>>> GetAllTickets()
    {
        try
        {
            var tickets = await _ticketService.GetAllTickets();
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<TicketDTO>> CreateTicket(TicketDTO ticketDto)
    {
        try
        {
            await _ticketService.AddTicket(ticketDto);
            return Ok(ticketDto);
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
}
