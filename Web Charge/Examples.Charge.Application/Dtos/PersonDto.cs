using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PersonPhoneDto> Phones { get; set; }
    }
}
