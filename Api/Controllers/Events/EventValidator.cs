namespace Api.Controllers.Events;

public class EventCreateValidator : AbstractValidator<EventCreateDTO>
{
    public EventCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.StartTime).NotEmpty();
        RuleFor(x => x.EndTime).GreaterThan(x => x.StartTime);
        RuleFor(x => x.AccessType).IsInEnum();
        RuleFor(x => x.ImagePath).NotEmpty();
        RuleFor(x => x.TicketsMax)
          .GreaterThan(0)
          .When(x => x.AccessType != AccessType.Free || x.HasSeat);
    }
}

public class EventUpdateValidator : AbstractValidator<EventUpdateDTO>
{
    public EventUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
        RuleFor(x => x.Address).NotEmpty();
        RuleFor(x => x.StartTime).NotEmpty();
        RuleFor(x => x.EndTime).GreaterThan(x => x.StartTime);
        RuleFor(x => x.AccessType).IsInEnum();
        RuleFor(x => x.ImagePath).NotEmpty();
        RuleFor(x => x.TicketsMax)
          .GreaterThan(0)
          .When(x => x.AccessType != AccessType.Free || x.HasSeat);
        RuleFor(x => x.TicketsSold).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TicketsSold).LessThan(x => x.TicketsMax);
    }
}
