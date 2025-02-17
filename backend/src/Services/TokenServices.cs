using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entities.Entities;
using src.Interfaces.IServices;

namespace src.Services
{
    public class TokenServices : ITokenServices
    {
        public Task<string> CreateAccessToken(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}