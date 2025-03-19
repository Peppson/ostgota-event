namespace Api.Controllers.Tickets;

public class TicketValidator : AbstractValidator<TicketCreateDTO>
{
    public TicketValidator()
    {   
        RuleFor(x => x.UserId).GreaterThanOrEqualTo(1).NotNull();
        RuleFor(x => x.EventId).GreaterThanOrEqualTo(1).NotNull();
    }
}
