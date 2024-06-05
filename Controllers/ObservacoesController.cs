using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }
        [HttpGet("GetAllObservacoes")]

        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> observacoes = await _observacoesRepositorio.GetAll();
            return Ok(observacoes);
        }

        [HttpGet("GetObservacoesId/{id}")]

        public async Task<ActionResult<ObservacoesModel>> GetAllObservacoesId(int id)
        {
            ObservacoesModel observacoes = await _observacoesRepositorio.GetById(id);
            return Ok(observacoes);
        }
        [HttpPost("InsertObservacoes")]

        public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoesModel)
        {
            ObservacoesModel observacoes = await _observacoesRepositorio.InsertObservacoes(observacoesModel);
            return Ok(observacoes);
        }

        [HttpPut("UpdateObservacoes/{id:int}")]

        public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacoesModel)
        {
            observacoesModel.ObservacoesId = id;
            ObservacoesModel observacoes = await _observacoesRepositorio.UpdateObservacoes(observacoesModel, id);
            return Ok(observacoes);
        }

        [HttpDelete("DeleteObservacoes/{id:int}")]

        public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
        {
            bool deleted = await _observacoesRepositorio.DeleteObservacoes(id);
            return Ok(deleted);
        }


    }
}