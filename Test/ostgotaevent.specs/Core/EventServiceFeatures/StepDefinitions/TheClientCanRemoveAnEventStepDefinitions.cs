using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class TheClientCanRemoveAnEventStepDefinitions
    {
        private readonly IEventService _eventService;

        private List<Event> eventList;

        private int id;

        private int expected;

        private int actual;

        public TheClientCanRemoveAnEventStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Given("the client has the id for event to be removed")]
        public async Task GivenTheClientHasTheIdForEventToBeRemoved()
        {
            var newEvent = new Event
            {
                Name = "event3",
                Description = "new event",
                City = "Linköping",
                Address = "Gatan 2",
                ImagePath = "./",
                TicketsSold = 0,
                Price = 0
            };

            await _eventService.AddEvent(newEvent);
            id = 3;
        }

        [When("the client removes the event")]
        public async Task WhenTheClientRemovesTheEvent()
        {
            eventList = await _eventService.GetAllEvents();
            expected = eventList.Count();
            var result = await _eventService.RemoveEvent(id);
        }

        [Then("the amount of events goes down")]
        public async Task ThenTheAmountOfEventsGoesDown()
        {
            eventList = await _eventService.GetAllEvents();
            actual = eventList.Count();
            Assert.NotEqual(expected, actual);
        }
    }
}
