using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Response
{
    public class PersonPhonesResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonPhoneDto> Phones { get; set; }
    }
}
