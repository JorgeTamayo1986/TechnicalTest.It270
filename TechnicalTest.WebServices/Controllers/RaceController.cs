using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Models;
using TechnicalTest.WebServices.Application.Contracts;
using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;

namespace TechnicalTest.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        readonly IRaceAppService _raceAppService;

        public RaceController(IRaceAppService raceAppService)
        {
            _raceAppService = raceAppService;
        }

        /// <summary>
        /// Recupera un registro por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(RaceController.GetById))]
        public async Task<RequestResponse<Race>> GetById(int id)
        {
            return await Task.Run(() =>
            {
                return _raceAppService.GetById(id);
            });
        }

        /// <summary>
        /// Recupera todos los registros paginados
        /// </summary>
        /// <param name="page">Página</param>
        /// <param name="pageSize">Número de items por página</param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(RaceController.GetAll))]
        public async Task<RequestResponse<PageResponseDTO<Race>>> GetAll(int page, int pageSize)
        {
            return await Task.Run(() =>
            {
                return _raceAppService.GetAll(page,pageSize);
            });
        }

        /// <summary>
        /// Crea un nuevo registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(nameof(RaceController.Create))]
        public async Task<RequestResponse<string>> Create([FromBody] RaceDTO request)
        {
            return await Task.Run(() =>
            {
                return _raceAppService.Create(request);
            });
        }

        /// <summary>
        /// Actualiza un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(nameof(RaceController.Update))]
        public async Task<RequestResponse<string>> Update([FromBody] RaceUpdateDTO request)
        {
            return await Task.Run(() =>
            {
                return _raceAppService.Update(request);
            });
        }

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(nameof(RaceController.Delete))]
        public async Task<RequestResponse<string>> Delete(int id)
        {
            return await Task.Run(() =>
            {
                return _raceAppService.Delete(id);
            });
        }
    }
}
