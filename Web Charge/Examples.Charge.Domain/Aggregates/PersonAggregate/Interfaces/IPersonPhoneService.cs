using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task AddPhonesAsync(Person person);
        Task RemoveAsync(PersonPhone phone);
        Task EditPhonesAsync(Person person, List<PersonPhone> personPhones);
    }
}

