using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiVenda.Domain.Validation
{
    public class DomainExceptionValidation :Exception
    {
        public DomainExceptionValidation(string error) : base (error)
        { }
        public static void When(bool condition, string message) 
        {
            if (condition) 
            {
                throw new DomainExceptionValidation(message);
            }
        }
    }
}
