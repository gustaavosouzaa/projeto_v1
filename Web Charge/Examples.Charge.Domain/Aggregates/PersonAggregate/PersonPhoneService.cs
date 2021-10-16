using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;

        private readonly IUnitOfWork _uow;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository, IUnitOfWork uow)
        {
            _personPhoneRepository = personPhoneRepository;
            _uow = uow;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task AddPhonesAsync(Person person)
        {
            _personPhoneRepository.AddPhones(person);
            await _uow.Commit();
        }

        public async Task RemoveAsync(PersonPhone phone)
        {
            _personPhoneRepository.Remove(phone);
            await _uow.Commit();
        }

        public async Task RemoveAllAsync(int personId)
        {
            await _personPhoneRepository.RemoveAllAsync(personId);
            await _uow.Commit();
        }

        public async Task EditPhonesAsync(Person person, List<PersonPhone> phones)
        {

            await _personPhoneRepository.RemoveAllAsync(person.BusinessEntityID);

            person.Phones = phones;
            _personPhoneRepository.AddPhones(person);

            await _uow.Commit();
        }
    }
}
