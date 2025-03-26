using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanFetchAllEventsStepDefinitions
    {
        private readonly IEventService _eventService;

        private List<Event> eventList;

        public ClientCanFetchAllEventsStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Given("there exists more than one event in the database")]
        public void GivenThereExistsMoreThanOneEventInTheDatabase()
        {
            var newEvent = new Event
            {
                Name = "event2",
                Description = "new event2",
                City = "Linköping",
                Address = "Gatan 3",
                ImagePath = "./",
                TicketsSold = 0,
                Price = 0
            };
            _eventService.AddEvent(newEvent);
        }

        [When("the client fetches all event")]
        public async Task WhenTheClientFetchesAllEvent()
        {
            eventList = await _eventService.GetAllEvents();
        }

        [Then("it recieves a list with all events")]
        public void ThenItRecievesAListWithAllEvents()
        {
            Assert.NotNull(eventList);
            Assert.NotEmpty(eventList);
            Assert.Equal(3, eventList.Count);
        }
    }
}
