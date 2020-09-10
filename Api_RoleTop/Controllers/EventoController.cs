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
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository { get; set; }

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }


        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_eventoRepository.GetById(id) != null)
            {
                return Ok(_eventoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Evento não encontrado.");
            }
        }

        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Add(evento);
                return Ok("Evento cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar Evento.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento evento)
        {
            try
            {
                Evento estadioBanco = new Evento
                {
                    Id = id,
                    Nome = evento.Nome,
                    Jogo = evento.Jogo,
                    Show = evento.Show
                };

                _eventoRepository.Update(estadioBanco);
                return Ok("Evento atualizado.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar o Evento ");

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Evento evento = _eventoRepository.GetById(id);
                _eventoRepository.Delete(evento);
                return Ok("Evento Deletado.");
            }
            catch
            {
                return BadRequest("Erro ao deletar Evento.");
            }
        }
    }
}
