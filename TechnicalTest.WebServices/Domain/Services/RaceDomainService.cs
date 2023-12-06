using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.Domain.Contracts;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Domain.Services
{
    public class RaceDomainService : IRaceDomainService
    {
        readonly ApplicationContext _context;

        public RaceDomainService(ApplicationContext context) { 
            _context = context;
        }

        public RequestResponse<string> Create(Race race)
        {
            var existRace = _context.Race.FirstOrDefault(f => f.Description.Equals(race.Description));
            if(existRace != null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGEXIST, race.Description));

            _context.Race.Add(race);
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGSAVE);
        }

        public RequestResponse<string> Delete(int id)
        {
            var existRace = _context.Race.FirstOrDefault(f => f.Id.Equals(id));
            if (existRace == null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGVALIDATEDELETE, id));

            _context.Race.Remove(existRace);
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGDELETE);
        }

        public PageResponseDTO<Race> GetAll(int page, int pageSize)
        {
            var pageCount = Math.Ceiling(_context.Race.Count() / (float)pageSize);

            var races = _context.Race
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            var response = new PageResponseDTO<Race>() {
                Response = races,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return response;
        }

        public Race? GetById(int id)
            =>  _context.Race.FirstOrDefault(f => f.Id.Equals(id));

        public RequestResponse<string> Update(Race race)
        {
            var oRace = _context.Race.AsNoTracking().FirstOrDefault(f => f.Id.Equals(race.Id));

            if (oRace == null)
                return new RequestResponse<string>().CreateUnsuccessful(string.Format(Resources.MSGVALIDATEUPDATE, race.Id));

            oRace.Description = race.Description;
            oRace.State = race.State;

            _context.Race.Update(oRace);
            _context.Entry(oRace).Property(x => x.Id).IsModified = false;
            _context.SaveChanges();

            return new RequestResponse<string>().CreateSuccessful(Resources.MSGUPDATE);
        }
    }
}
