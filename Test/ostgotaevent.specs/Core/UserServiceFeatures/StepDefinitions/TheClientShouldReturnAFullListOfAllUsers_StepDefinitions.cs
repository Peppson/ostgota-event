namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class TheClientShouldReturnAFullListOfAllUsers_StepDefinitions
    {
        private readonly IUserService _userService;
        private List<User> _userList;
        private int expected = 5; //expected is 5, based on adding 3 other users during testing and removing 1. Might be 6 depending on test-timing.
        private int actual;

        public TheClientShouldReturnAFullListOfAllUsers_StepDefinitions(IUserService userService, IDatabase database)
        {
            _userService = userService;
        }

        [Given("The database contains a list of users")]
        public async Task GivenTheDatabaseContainsAListOfUsers()
        {
            var user1 = new User { Username = "Adam", PasswordHash = "123", Email = "adam@email.com" };
            var user2 = new User { Username = "Bertil", PasswordHash = "123", Email = "bertil@email.com" };
            var user3 = new User { Username = "Carl", PasswordHash = "123", Email = "carl@email.com" };

            await _userService.AddUser(user1);
            await _userService.AddUser(user2);
            await _userService.AddUser(user3);

        }

        [When("the client calls the GetAllUser-function")]
        public async Task WhenTheClientCallsTheGetAllUser_Function()
        {
            _userList = await _userService.GetAllUsers();
            actual = _userList.Count();
        }

        [Then("the client recieves a list of all created users")]
        public void ThenTheClientRecievesAListOfAllCreatedUsers()
        {
            Assert.Equal(expected, actual);
        }
    }
}
