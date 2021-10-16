using Examples.Charge.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Request
{
    public class RemovePersonPhoneRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
    }
}
