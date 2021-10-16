using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<ActionResult<PersonResponse>> AddPhonesAsync(int personId, List<PersonPhoneRequest> personPhones)
        {
            try
            {
                return Response(await _facade.AddPhonesAsync(personId, personPhones));
            }
            catch (PersonException ex)
            {
                var response = new PersonResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };
                
                return Response(HttpStatusCode.NotFound, response);
            }
            catch (Exception ex)
            {
                var response = new PersonResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };

                return Response(HttpStatusCode.BadRequest, response);
            }

        }

        [HttpDelete("phone")]
        public async Task<ActionResult<PersonResponse>> RemovePhoneAsync(RemovePersonPhoneRequest personPhone)
        {
            try
            {

                await _facade.RemovePhoneAsync(personPhone);
                return Response(null);
            }
            catch (Exception ex)
            {
                var response = new PersonResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };

                return Response(HttpStatusCode.BadRequest, response);
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
                var response = new PersonResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };
                return Response(HttpStatusCode.NotFound, response);
            }
            catch (Exception ex)
            {
                var response = new PersonResponse()
                {
                    Errors = new List<string>() { ex.Message },
                    Success = false
                };
                return Response(HttpStatusCode.BadRequest, response);
            }

        }
    }
}
