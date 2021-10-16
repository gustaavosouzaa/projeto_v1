using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonFacade
    {
        Task<PersonResponse> GetByIdAsync(int id);
        Task<PersonResponse> AddPhonesAsync(int personId, List<PersonPhoneRequest> personPhones);
        Task RemovePhoneAsync(RemovePersonPhoneRequest phone);
        Task<PersonResponse> EditPhonesAsync(int personId, List<PersonPhoneRequest> personPhones);
    }
}