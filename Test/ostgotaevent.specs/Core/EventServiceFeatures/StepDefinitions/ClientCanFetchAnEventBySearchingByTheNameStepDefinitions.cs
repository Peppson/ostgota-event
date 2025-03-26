using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanFetchAnEventBySearchingByTheNameStepDefinitions
    {
        private readonly IEventService _eventService;

        private string eventName;

        private Event returnedEvent;

        public ClientCanFetchAnEventBySearchingByTheNameStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Given("the client knows the name to search for")]
        public void GivenTheClientKnowsTheNameToSearchFor()
        {
            eventName = "event";
        }

        [When("the client fetches the event by name")]
        public async Task WhenTheClientFetchesTheEventByName()
        {
            returnedEvent = await _eventService.GetEventByName(eventName);
        }

        [Then("the client recieves an event")]
        public void ThenTheClientRecievesAnEvent()
        {
            Assert.NotNull(returnedEvent);
            Assert.IsType<Event>(returnedEvent);
        }
    }
}
