using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Exceptions
{
    public class PersonException : Exception
    {
        public PersonException() : base("Person error")
        {

        }
    }
}
