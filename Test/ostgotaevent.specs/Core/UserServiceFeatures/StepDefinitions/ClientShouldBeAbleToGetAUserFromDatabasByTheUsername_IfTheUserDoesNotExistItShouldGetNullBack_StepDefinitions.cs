namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientShouldBeAbleToGetAUserFromDatabasByTheUsername_IfTheUserDoesNotExistItShouldGetNullBack_StepDefinitions
    {
        private User user;
        private readonly IUserService _userService;
        private readonly IDatabase _db;
        private string actual;
        private string username;

        public ClientShouldBeAbleToGetAUserFromDatabasByTheUsername_IfTheUserDoesNotExistItShouldGetNullBack_StepDefinitions(IUserService userService, IDatabase db)
        {
            _userService = userService;
            _db = db;
        }

        [Given("the client has the username {string} for user lookup")]
        public async Task GivenTheClientHasTheUsernameForUserLookup(string username)
        {
            this.username = username;
            
            // If the user should exist, add them to the database
            if (username == "arif")
            {
                var user = new User
                {
                    Username = username,
                    Email = "test@example.com",
                    PasswordHash = "123"
                };
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
            }
        }

        [When("the client gets the user from the system")]
        public async Task WhenTheClientGetsTheUserFromTheSystem()
        {
            user = await _userService.GetUserByName(username);
            actual = user != null ? "User" : "null";
        }

        [Then("the client gets the result {string}")]
        public void ThenTheClientGetsTheResult(string expectedResult)
        {
            Assert.Equal(expectedResult, actual);
        }
    }
}
