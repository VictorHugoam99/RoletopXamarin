using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_RoleTop.Domains;
using Api_RoleTop.Interfaces;
using Api_RoleTop.Repositories;

namespace Api_RoleTop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadioController : ControllerBase
    {
        private IEstadioRepository _estadioRepository { get; set; }

        public EstadioController()
        {
            _estadioRepository = new EstadioRepository();
        }


        [HttpGet]
        public IEnumerable<Estadio> Get()
        {
            return _estadioRepository.GetAll();
        }

        [HttpGet("{id}/eventos")]
        public IEnumerable<Estadio> GetEventos(int id)
        {
            return _estadioRepository.PegarEventoEstadio(id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_estadioRepository.GetById(id) != null)
            {
                return Ok(_estadioRepository.GetById(id));
            }
            else
            {
                return BadRequest("Estadio não encontrado.");
            }
        }

        [HttpPost]
        public IActionResult Post(Estadio estadio)
        {
            try
            {
                _estadioRepository.Add(estadio);
                return Ok("Estadio cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar estadio.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estadio estadio)
        {
            try
            {
                Estadio estadioBanco = new Estadio
                {
                    Id = id,
                    Nome = estadio.Nome,
                    Foto = estadio.Foto,
                    Latitude = estadio.Latitude,
                    Longitude = estadio.Longitude,
                    Cidade = estadio.Cidade,
                    Uf = estadio.Uf,
                    Evento = estadio.Evento
                };

                _estadioRepository.Update(estadioBanco);
                return Ok("Estadio atualizado.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar o Estadio ");

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Estadio estadio = _estadioRepository.GetById(id);
                _estadioRepository.Delete(estadio);
                return Ok("Estadio Deletado.");
            }
            catch
            {
                return BadRequest("Erro ao deletar Estadio.");
            }
        }
    }
}
