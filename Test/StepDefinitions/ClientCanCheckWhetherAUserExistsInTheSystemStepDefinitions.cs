using System;
using Core.Models;
using Core.Services.Users;
using Core.Data;
using Reqnroll;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test.StepDefinitions
{
    [Binding]
    public class ClientCanCheckWhetherAUserExistsInTheSystemStepDefinitions
    {
        private readonly IUserService _userService;
        private readonly IDatabase _db;
        private string username;
        private bool userExists;
        private bool expectedResult;

        public ClientCanCheckWhetherAUserExistsInTheSystemStepDefinitions(IUserService userService, IDatabase db)
        {
            _userService = userService;
            _db = db;
        }

        [Given("the client has the username {string}")]
        public async Task GivenTheClientHasTheUsername(string username)
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

        [When("the client checks whether the user exists in the system")]
        public async Task WhenTheClientChecksWhetherTheUserExistsInTheSystem()
        {
            userExists = await _userService.DoesUserExist(username);
        }

        [Then("the client is informed that the user exists is {string}")]
        public void ThenTheClientIsInformedThatTheUserExistsIs(string expectedResult)
        {
            bool expected = bool.Parse(expectedResult);
            Assert.Equal(expected, userExists);
        }
    }
}
