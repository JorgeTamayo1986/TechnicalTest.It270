using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Domain.Contracts
{
    public interface IAnimalDomainService
    {
        Animal? GetById(int id);
        PageResponseDTO<Animal> GetAll(int page, int pageSize);
        RequestResponse<string> Create(Animal race);
        RequestResponse<string> Update(Animal race);
        RequestResponse<string> Delete(int id);
        IEnumerable<AnimalResponseDTO> GetAnimalsByRace(string name);
    }
}
