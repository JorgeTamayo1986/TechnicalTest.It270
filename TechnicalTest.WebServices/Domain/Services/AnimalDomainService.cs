using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.Domain.Contracts;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Domain.Services
{
    public class AnimalDomainService : IAnimalDomainService
    {
        readonly ApplicationContext _context;
        public AnimalDomainService(ApplicationContext context)
        {
            _context = context;
        }


        public RequestResponse<string> Create(Animal animal)
        {
            var existRace = _context.Race.FirstOrDefault(f => f.Id.Equals(animal.RaceId));

            if (existRace == null)
                return new RequestResponse<string>().CreateUnsuccessful(Resources.MSGINVALIDRACE);


            var existAnimal = _context.Animal.FirstOrDefault(f => f.Name.Equals(animal.Name));
            if (existAnimal != null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGEXIST, animal.Name));


            _context.Animal.Add(animal);
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGSAVE);
        }

        public RequestResponse<string> Delete(int id)
        {
            var exist = _context.Animal.FirstOrDefault(f => f.Id.Equals(id));
            if (exist == null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGVALIDATEDELETE, id));

            _context.Animal.Remove(exist);
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGDELETE);
        }

        public PageResponseDTO<Animal> GetAll(int page, int pageSize)
        {
            var pageCount = Math.Ceiling(_context.Animal.Count() / (float)pageSize);

            var animal = _context.Animal
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            var response = new PageResponseDTO<Animal>()
            {
                Response = animal,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public Animal? GetById(int id)
         => _context.Animal.FirstOrDefault(f => f.Id.Equals(id));

        public RequestResponse<string> Update(Animal animal)
        {
            var oAnimal = _context.Animal.AsNoTracking().FirstOrDefault(f => f.Id.Equals(animal.Id));

            if (oAnimal == null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGVALIDATEUPDATE, animal.Id));

            oAnimal.State = animal.State;
            oAnimal.BirthDate = animal.BirthDate;
            oAnimal.Gender = animal.Gender;
            oAnimal.Price = animal.Price;
            oAnimal.RaceId = animal.RaceId;

            _context.Animal.Update(oAnimal);
            _context.Entry(oAnimal).Property(x => x.Id).IsModified = false;
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGUPDATE);
        }

        public IEnumerable<AnimalResponseDTO> GetAnimalsByRace(string name)
        {

            var query = (from RC in _context.Race.AsNoTracking()
                         join AN in _context.Animal on RC.Id equals AN.RaceId
                         where AN.State
                         select new
                         {
                             RC.Description,
                             AN.Id
                         })
                        .GroupBy(a => a.Description)
                        .Select(a => new AnimalResponseDTO()
                        {
                            Race = a.Key,
                            Animals = a.Count()
                        });

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(f => f.Race.Equals(name));


            return query;
        }
    }
}
