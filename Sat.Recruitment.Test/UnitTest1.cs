using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Data.Models;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void CreateUser_Success()
        {
            var userController = new UsersController();
            var user = new User
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var result = userController.CreateUser(user).Result;


            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void CreateUser_Error()
        {

            var userController = new UsersController();
            var user = new User
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var result = userController.CreateUser(user).Result;
            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }
    }
}
