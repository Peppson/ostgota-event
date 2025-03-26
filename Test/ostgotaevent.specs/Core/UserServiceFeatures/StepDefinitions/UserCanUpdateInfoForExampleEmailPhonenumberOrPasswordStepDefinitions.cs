using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class UserCanUpdateInfoForExampleEmailPhonenumberOrPasswordStepDefinitions
    {
        private readonly IUserService _userService;
        private readonly IDatabase _db;
        private User user;
        private string newPhoneNumber = "123";

        public UserCanUpdateInfoForExampleEmailPhonenumberOrPasswordStepDefinitions(IUserService userService, IDatabase db)
        {
            _userService = userService;
            _db = db;
        }
        [Given("the user exists inside the database")]
        public void GivenTheUserExistsInsideTheDatabase()
        {
            user = _db.Users.FirstOrDefault(x => x.Id == 3);
        }

        [Given("the user has changed phonenumber in the client")]
        public void GivenTheUserHasChangedPhonenumberInTheClient()
        {
            user.PhoneNumber = newPhoneNumber;
        }

        [When("the user updates the info")]
        public async Task WhenTheUserUpdatesTheInfo()
        {
            user = await _userService.UpdateUser(user.Id, user);
        }

        [Then("the client should return a user with the new info")]
        public void ThenTheClientShouldReturnAUserWithTheNewInfo()
        {
            Assert.Equal(newPhoneNumber, user.PhoneNumber);
        }
    }
}
