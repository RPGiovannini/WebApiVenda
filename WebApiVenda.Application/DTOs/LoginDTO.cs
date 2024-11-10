using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Application.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
