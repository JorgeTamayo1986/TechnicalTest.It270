using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Application.Contracts
{
    public interface IAnimalAppService
    {
        RequestResponse<Animal> GetById(int id);
        RequestResponse<PageResponseDTO<Animal>> GetAll(int page, int pageSize);
        RequestResponse<string> Create(AnimalDTO animalDTO);
        RequestResponse<string> Update(AnimalUpdateDTO animalDTO);
        RequestResponse<string> Delete(int id);

        RequestResponse<IEnumerable<AnimalResponseDTO>> GetAnimalsByRace(string name);
    }
}
