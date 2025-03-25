using System;
using System.Runtime.CompilerServices;
using Core.Services.Users;
using Core.Data;
using Reqnroll;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Test.StepDefinitions
{
    [Binding]
    public class ClientCanAddAUserToTheSystemStepDefinitions
    {
        private readonly IUserService _userService;
        private User user;

        public ClientCanAddAUserToTheSystemStepDefinitions(IUserService userService)
        {
            _userService = userService;
        }

        [Given("the user has been created")]
        public void GivenTheUserHasBeenCreated()
        {
            user = new User { Username = "JeppaJoggius", PasswordHash = "123", Email = "Kaffejocke@Flutterjocke.com" };
        }

        [When("the client adds the user to the system")]
        public void WhenTheClientAddsTheUserToTheSystem()
        {
            _userService.AddUser(user);
        }

        [Then("the user is added to the system")]
        public async Task ThenTheUserIsAddedToTheSystem()
        {
            Assert.True(await _userService.DoesUserExist(user.Username));
        }
    }
}
