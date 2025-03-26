namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanGetAUserByTheID_StepDefinitions
    {
        private readonly IUserService _userService;
        private int id;
        private User user;

        public ClientCanGetAUserByTheID_StepDefinitions(IUserService userService)
        {
            _userService = userService;
        }

        [Given("the client has the id")]
        public void GivenTheClientHasTheId()
        {
            id = 1;
        }

        [When("the client fetches the user")]
        public async Task WhenTheClientFetchesTheUser()
        {
            user = await _userService.GetUserById(id);
        }

        [Then("the client gets the user forom the search")]
        public void ThenTheClientGetsTheUserForomTheSearch()
        {
            Assert.Equal(id, user.Id);
            Assert.NotNull(user);
        }

        [Given("the client searches for an id that does not exist")]
        public void GivenTheClientSearchesForAnIdThatDoesNotExist()
        {
            id = 99;
            user = null;
        }

        [When("the client tries to fetch the user")]
        public async Task WhenTheClientTriesToFetchTheUser()
        {
            user = await _userService.GetUserById(id);
        }

        [Then("the client recieves null")]
        public void ThenTheClientRecievesNull()
        {
            Assert.Null(user);
        }
    }
}
