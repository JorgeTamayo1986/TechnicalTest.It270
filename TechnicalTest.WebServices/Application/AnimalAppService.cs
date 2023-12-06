using AutoMapper;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Application.Contracts;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.Domain.Contracts;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Application
{
    public class AnimalAppService : IAnimalAppService
    {
        readonly IAnimalDomainService _animalDomainService;
        readonly IMapper _mapper;
        public AnimalAppService(IAnimalDomainService animalDomainService, IMapper mapper) { 
            _animalDomainService = animalDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Crea una registro nuevo
        /// </summary>
        /// <param name="raceDTO"></param>
        /// <returns></returns>
        public RequestResponse<string> Create(AnimalDTO animalDTO)
        {
            try
            {
                var validator = AnimalAppValidator.IsValid(animalDTO);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                var animal = _mapper.Map<AnimalDTO, Animal>(animalDTO);

                return _animalDomainService.Create(animal);
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
                var validator = AnimalAppValidator.IsValidId(id);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                return _animalDomainService.Delete(id);
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
        public RequestResponse<PageResponseDTO<Animal>> GetAll(int page, int pageSize)
        {
            try
            {
                #region Validate
                var validator = AnimalAppValidator.IsValidId(page);

                if (!validator.IsSuccessful)
                    return new RequestResponse<PageResponseDTO<Animal>>().CreateUnsuccessful(validator.Message);

                validator = AnimalAppValidator.IsValidId(pageSize);

                if (!validator.IsSuccessful)
                    return new RequestResponse<PageResponseDTO<Animal>>().CreateUnsuccessful(validator.Message); 
                #endregion

                var result = _animalDomainService.GetAll(page, pageSize);

                if (result == null)
                    return new RequestResponse<PageResponseDTO<Animal>>().CreateUnsuccessful(Resources.MSGNOFOUND);
                else
                    return new RequestResponse<PageResponseDTO<Animal>>().CreateSuccessful(result);

            }
            catch (Exception ex)
            {
                return new RequestResponse<PageResponseDTO<Animal>>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Recuperar la cantidad de animales por raza
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RequestResponse<IEnumerable<AnimalResponseDTO>> GetAnimalsByRace(string name)
        {
            try
            {
                var result = _animalDomainService.GetAnimalsByRace(name);

                if (!result.Any())
                    return new RequestResponse<IEnumerable<AnimalResponseDTO>>().CreateUnsuccessful(Resources.MSGNOFOUND);
                else
                    return new RequestResponse<IEnumerable<AnimalResponseDTO>>().CreateSuccessful(result);

            }
            catch (Exception ex)
            {
                return new RequestResponse<IEnumerable<AnimalResponseDTO>>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Recupera un registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestResponse<Animal> GetById(int id)
        {
            try
            {
                var validator = AnimalAppValidator.IsValidId(id);

                if (!validator.IsSuccessful)
                    return new RequestResponse<Animal>().CreateUnsuccessful(validator.Message);

                var result = _animalDomainService.GetById(id);

                if (result == null)
                    return new RequestResponse<Animal>().CreateUnsuccessful(Resources.MSGNOFOUND);
                else
                    return new RequestResponse<Animal>().CreateSuccessful(result);

            }
            catch (Exception ex)
            {
                return new RequestResponse<Animal>().CreateError(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un registro en la bd
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public RequestResponse<string> Update(AnimalUpdateDTO animalDTO)
        {
            try
            {
                var validator = AnimalAppValidator.IsValidUpdate(animalDTO);

                if (!validator.IsSuccessful)
                    return new RequestResponse<string>().CreateUnsuccessful(validator.Message);

                var race = _mapper.Map<AnimalUpdateDTO, Animal>(animalDTO);

                return _animalDomainService.Update(race);
            }
            catch (Exception ex)
            {
                return new RequestResponse<string>().CreateError(ex.Message);
            }
        }
    }
}
