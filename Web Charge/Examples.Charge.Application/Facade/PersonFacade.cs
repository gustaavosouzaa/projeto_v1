using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personService = personService;
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }

        public async Task<PersonsResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonsResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonResponse> GetByIdAsync(int id)
        {
            var result = await _personService.GetByIdAsync(id);

            return new PersonResponse() { 
                PersonObject = _mapper.Map<PersonDto>(result),
                Success = false,
                Errors = new List<string> { "B", "A"}
            };
        }

        public async Task<PersonResponse> AddPhonesAsync(int personId, List<PersonPhoneRequest> personPhones)
        {
            Person person = await _personService.GetByIdAsync(personId); 

            if (person != null)
            {
                person.Phones = _mapper.Map<List<PersonPhone>>(personPhones);

                await _personPhoneService.AddPhonesAsync(person);
                return new PersonResponse();
            }
            else
            {
                throw new PersonException();
            }

        }

        public async Task RemovePhoneAsync(RemovePersonPhoneRequest phone)
        {

            var personPhone = _mapper.Map<PersonPhone>(phone); 

            await _personPhoneService.RemoveAsync(personPhone);
        }

        public async Task<PersonResponse> EditPhonesAsync(int personId, List<PersonPhoneRequest> personPhones)
        {
            Person person = await _personService.GetByIdAsync(personId);

            if (person != null)
            {
                await _personPhoneService.EditPhonesAsync(person, _mapper.Map<List<PersonPhone>>(personPhones));

                return new PersonResponse();
            }
            else
            {
                throw new PersonException();
            }
        }
    }
}
