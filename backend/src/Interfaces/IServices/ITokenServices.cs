using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entities.Entities;

namespace src.Interfaces.IServices
{
    public interface ITokenServices
    {
        public Task<string> CreateAccessToken(Usuario usuario);
    }
}