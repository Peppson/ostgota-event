using System;
using Reqnroll;

namespace Test.ostgotaevent.specs.Core.UserServiceFeatures.StepDefinitions
{
    [Binding]
    public class ClientCanRemoveAUserByEnteringTheIDStepDefinitions
    {
        private readonly IUserService _userService;
        private int idToRemove;
        private bool removeResult;

        public ClientCanRemoveAUserByEnteringTheIDStepDefinitions(IUserService userService)
        {
            _userService = userService;
        }

        [Given("The database has a user with the {string}")]
        public void GivenTheDatabaseHasAUserWithThe(string idString)
        {
            idToRemove = Convert.ToInt32(idString);
        }

        [When("the client tries to remove the user")]
        public async Task WhenTheClientTriesToRemoveTheUser()
        {
            removeResult = await _userService.RemoveUserById(idToRemove);
        }

        [Then("the client recieves a bool {string} with success")]
        public void ThenTheClientRecievesABoolWithSuccess(string result)
        {
            bool expected = bool.Parse(result);
            Assert.Equal(expected, removeResult);
        }
    }
}
