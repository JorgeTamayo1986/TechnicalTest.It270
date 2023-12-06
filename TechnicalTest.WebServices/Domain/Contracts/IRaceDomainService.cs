using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Domain.Contracts
{
    public interface IRaceDomainService
    {
        Race? GetById(int id);
        PageResponseDTO<Race> GetAll(int page, int pageSize);
        RequestResponse<string> Create(Race race);
        RequestResponse<string> Update(Race race);
        RequestResponse<string> Delete(int id);
    }
}
