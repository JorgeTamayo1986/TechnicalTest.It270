using AutoMapper;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Application.Contracts;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.Domain.Contracts;
using TechnicalTest.WebServices.Domain.Services;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Application
{
    public class RaceAppService : IRaceAppService
    {
        readonly IRaceDomainService _raceDomainService;
        readonly IMapper _mapper;
        public RaceAppService(IRaceDomainService raceDomainService, IMapper mapper) 
        {
            _raceDomainService = raceDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Crea una registro nuevo
        /// </summary>
        /// <param name="raceDTO"></param>
        /// <returns></returns>
        public RequestResponse<string> Create(RaceDTO raceDTO)
        {
            try
            {
                var validator = RaceAppValidator.IsValid(raceDTO);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                var race = _mapper.Map<RaceDTO,Race>(raceDTO);

                return _raceDomainService.Create(race);
            }
            catch (Exception ex)
            {
                return new RequestResponse<string>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un registro en la bd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<string> Delete(int id)
        {
            try
            {
                var validator = RaceAppValidator.IsValidId(id);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                return _raceDomainService.Delete(id);
            }
            catch (Exception ex)
            {
                return new RequestResponse<string>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Recupera todos los registros 
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns></returns>
        public RequestResponse<PageResponseDTO<Race>> GetAll(int page, int pageSize)
        {
            try
            {
                var validator = RaceAppValidator.IsValidId(pageSize);

                if (!validator.IsSuccessful)
                    return new RequestResponse<PageResponseDTO<Race>>().CreateUnsuccessful(validator.Message);

                var result = _raceDomainService.GetAll(page, pageSize);

                if (result == null)
                    return new RequestResponse<PageResponseDTO<Race>>().CreateUnsuccessful(Resources.MSGNOFOUND);
                else
                    return new RequestResponse<PageResponseDTO<Race>>().CreateSuccessful(result);

            }
            catch (Exception ex)
            {
                return new RequestResponse<PageResponseDTO<Race>>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Recupera un registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<Race> GetById(int id)
        {
            try
            {
                var validator = RaceAppValidator.IsValidId(id);

                if (!validator.IsSuccessful)
                    return new RequestResponse<Race>().CreateUnsuccessful(validator.Message);

                var result = _raceDomainService.GetById(id);

                if (result == null)
                    return new RequestResponse<Race>().CreateUnsuccessful(Resources.MSGNOFOUND);
                else
                    return new RequestResponse<Race>().CreateSuccessful(result);  

            }
            catch (Exception ex)
            {
                return new RequestResponse<Race>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un registro en la bd
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public RequestResponse<string> Update(RaceUpdateDTO raceDTO)
        {
            try
            {
                var validator = RaceAppValidator.IsValidUpdate(raceDTO);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                var race = _mapper.Map<RaceUpdateDTO, Race>(raceDTO);

                return _raceDomainService.Update(race);
            }
            catch (Exception ex)
            {
                return new RequestResponse<string>().CreateError(ex.Message);
            }
        }
    }
}
