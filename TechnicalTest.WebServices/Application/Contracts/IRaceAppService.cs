using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Application.Contracts
{
    public interface IRaceAppService
    {
        RequestResponse<Race> GetById(int id);
        RequestResponse<PageResponseDTO<Race>> GetAll(int page, int pageSize);
        RequestResponse<string> Create(RaceDTO race);
        RequestResponse<string> Update(RaceUpdateDTO race);
        RequestResponse<string> Delete(int id);

    }
}
