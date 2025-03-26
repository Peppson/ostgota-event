using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class TheClientCanUpdateTheInformationOfAnEventStepDefinitions
    {
        private readonly IEventService _eventService;

        private Event editedEvent;

        private Event returnedEvent;

        public TheClientCanUpdateTheInformationOfAnEventStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Given("the client has an edited event")]
        public void GivenTheClientHasAnEditedEvent()
        {
            editedEvent = new Event
            {
                Name = "event2",
                Description = "new event2",
                City = "Norrköping",
                Address = "Gatan 3",
                ImagePath = "./",
                TicketsSold = 0,
                Price = 0
            };
        }

        [When("the client updates the event")]
        public async Task WhenTheClientUpdatesTheEvent()
        {
            returnedEvent = await _eventService.UpdateEvent(2, editedEvent);
        }

        [Then("the returned event contains the new information")]
        public void ThenTheReturnedEventContainsTheNewInformation()
        {
            Assert.NotNull(returnedEvent);
            Assert.Equal(editedEvent.City ,returnedEvent.City);
        }
    }
}
