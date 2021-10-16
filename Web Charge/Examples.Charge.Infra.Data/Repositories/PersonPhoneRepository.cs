using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public void AddPhones(Person person)
        {
            _context.Update(person);
        }

        public void Remove(PersonPhone phone)
        {
            _context.Remove(phone);
        }

        public async Task RemoveAllAsync(int personId)
        {
            var phones = await _context.PersonPhone.Where(x => x.BusinessEntityID == personId).FirstOrDefaultAsync();

            if(phones != null)
               _context.RemoveRange(phones);
        }
    }
}
