using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Application;
using TechnicalTest.WebServices.Application.Contracts;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        readonly IAnimalAppService _animalAppService;

        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }

        /// <summary>
        /// Recupera un registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(AnimalController.GetById))]
        public async Task<RequestResponse<Animal>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.GetById(id);
            });
        }

        /// <summary>
        /// Recupera todos los registros paginados
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(AnimalController.GetAll))]
        public async Task<RequestResponse<PageResponseDTO<Animal>>> GetAll(int page, int pageSize)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.GetAll(page, pageSize);
            });
        }

        /// <summary>
        /// Recupera los animales agrupados por raza
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(AnimalController.GetAnimalsByRace))]
        public async Task<RequestResponse<IEnumerable<AnimalResponseDTO>>> GetAnimalsByRace(string? name)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.GetAnimalsByRace(name);
            });
        }

        /// <summary>
        /// Crea un nuevo registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(AnimalController.Create))]
        public async Task<RequestResponse<string>> Create([FromBody] AnimalDTO request)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.Create(request);
            });
        }

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(AnimalController.Update))]
        public async Task<RequestResponse<string>> Update([FromBody] AnimalUpdateDTO request)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.Update(request);
            });
        }

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(nameof(AnimalController.Delete))]
        public async Task<RequestResponse<string>> Delete(int id)
        {
            return await Task.Run(() =>
            {
                return _animalAppService.Delete(id);
            });
        }
    }
}
