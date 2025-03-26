using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class AdminCanUpdateUserdataExceptPassword_StepDefinitions
    {
        private readonly IUserService _userService;
        private User updatedUser;
        private User user;
        private int id;
        public AdminCanUpdateUserdataExceptPassword_StepDefinitions(IUserService userService)
        {
            _userService = userService;
        }

        [Given("the admin has the id for a user")]
        public void GivenTheAdminHasTheIdForAUser()
        {
            id = 2;
        }

        [Given("have updated-userdata")]
        public void GivenHaveUpdated_Userdata()
        {
            updatedUser = new User { Username = "bertolius", PasswordHash = "1", Email = "hej@123.se"};
        }

        [When("the admin updates data")]
        public async Task WhenTheAdminUpdatesData()
        {
            user = await _userService.UpdateUserAdmin(id, updatedUser);
        }

        [Then("the new data is saved by the admin")]
        public void ThenTheNewDataIsSavedByTheAdmin()
        {
            Assert.Equal(updatedUser.Username, user.Username);
        }
    }
}
