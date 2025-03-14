namespace Api.Controllers.Tickets;

public class TicketValidator : AbstractValidator<TicketDTO>
{
    public TicketValidator()
    {   
        RuleFor(x => x.UserId).GreaterThanOrEqualTo(1).NotNull();
        RuleFor(x => x.EventId).GreaterThanOrEqualTo(1).NotNull();
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0).NotNull();
    }
}
