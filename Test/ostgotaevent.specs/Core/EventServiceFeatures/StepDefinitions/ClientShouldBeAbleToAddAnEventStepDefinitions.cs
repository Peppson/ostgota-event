using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientShouldBeAbleToAddAnEventStepDefinitions
    {
        private readonly IEventService _eventService;

        private Event newEvent;

        private Event createdEvent;

        public ClientShouldBeAbleToAddAnEventStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Given("the client has created an event")]
        public void GivenTheClientHasCreatedAnEvent()
        {
            newEvent = new Event
            {
                Name = "event",
                Description = "new event",
                City = "Linköping",
                Address = "Gatan 2",
                ImagePath = "./",
                TicketsSold = 0,
                Price = 0
            };
        }

        [When("the user saves the event")]
        public async Task WhenTheUserSavesTheEvent()
        {
            createdEvent = await _eventService.AddEvent(newEvent);
        }

        [Then("an event should be returned")]
        public void ThenAnEventShouldBeReturned()
        {
            Assert.Equal(newEvent.Name, createdEvent.Name);
        }
    }
}
