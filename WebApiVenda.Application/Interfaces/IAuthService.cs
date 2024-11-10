using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(string email, string senha);
    }
}
