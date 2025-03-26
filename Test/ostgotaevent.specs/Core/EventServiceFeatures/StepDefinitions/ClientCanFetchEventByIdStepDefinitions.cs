using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.EventServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanFetchEventByIdStepDefinitions
    {
        private IEventService _eventService;

        private int id;

        private Event returnedEvent;

        public ClientCanFetchEventByIdStepDefinitions(IEventService eventService)
        {
            _eventService = eventService;
        }
        [Given("The client know the id of the event")]
        public void GivenTheClientKnowTheIdOfTheEvent()
        {
            id = 1;
        }

        [When("the client fetches the event by id")]
        public async Task WhenTheClientFetchesTheEventById()
        {
            returnedEvent = await _eventService.GetEventById(id);
        }

        [Then("the client is returned an event")]
        public void ThenTheClientIsReturnedAnEvent()
        {
            Assert.NotNull(returnedEvent);
        }
    }
}
