using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.TicketServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanAddTicketsStepDefinitions
    {
        private readonly ITicketService _ticketService;

        private Ticket returnedTicket;

        private int eventId;
        private int userId;

        public ClientCanAddTicketsStepDefinitions(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Given("the client has the user-Id and event-Id")]
        public void GivenTheClientHasTheUser_IdAndEvent_Id()
        {
            eventId = 1;
            userId = 3;
        }

        [When("the client creates a ticket")]
        public async Task WhenTheClientCreatesATicket()
        {
            returnedTicket = await _ticketService.AddTicket( userId, eventId, null);
        }

        [Then("the client is returned a ticket")]
        public void ThenTheClientIsReturnedATicket()
        {
            Assert.NotNull(returnedTicket);
        }
    }
}
