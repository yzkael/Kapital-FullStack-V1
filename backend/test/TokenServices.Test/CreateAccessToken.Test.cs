using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Contracts.AuthDtos;
using src.Entities.Entities;

namespace TokenServices.Test
{
    public class CreateAccessToken
    {

        [Theory]
        [InlineData("sudo", "123456", true)]
        [InlineData("nothing", "123456", false)]
        [InlineData("sudo", "654321", false)]
        public void TestAccessToken(string username, string password, bool succeded)
        {
            var usuario = new LoginRequestDto { Username = username, Password = password };

        }
    }
}