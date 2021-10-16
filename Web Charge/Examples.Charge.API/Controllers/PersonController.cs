using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonPhonesResponse>> Get(int id) 
        {
           return Response(await _facade.GetByIdAsync(id));
        }

        [HttpPost("{personId}/phones")]
        public async Task<ActionResult<PersonResponse>> AddPhones(int personId, List<PersonPhoneRequest> personPhones)
        {
            try
            {
                return Response(await _facade.AddPhones(personId, personPhones));
            }
            catch (PersonException ex)
            {
                return Response(404, ex.Message);
            }
            catch (Exception ex)
            {
                return Response(400, ex.Message);
            }

        }

        [HttpDelete("phone")]
        public async Task<ActionResult<PersonResponse>> RemovePhone(RemovePersonPhoneRequest personPhone)
        {
            try
            {

                await _facade.RemovePhoneAsync(personPhone);
                return Response(null);
            }
            catch (Exception ex)
            {
                return Response(400, ex.Message);
            }
        }

        [HttpPut("{personId}/phones")]
        public async Task<ActionResult<PersonResponse>> EditPhonesAsync(int personId, List<PersonPhoneRequest> personPhones)
        {
            try
            {
                return Response(await _facade.EditPhonesAsync(personId, personPhones));
            }
            catch (PersonException ex)
            {
                return Response(404, ex.Message);
            }
            catch (Exception ex)
            {
                return Response(400, ex.Message);
            }

        }
    }
}
