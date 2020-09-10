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
    public class ShowController : ControllerBase
    {
        private IShowRepository _showRepository { get; set; }

        public ShowController()
        {
            _showRepository = new ShowRepository();
        }

        [HttpGet]
        public IEnumerable<Show> Get()
        {
            //IEnumerable<Show> lista = _showRepository.GetAll();

            //if (lista.Count() == 0)
            //{
            //    return BadRequest("Cadastre um show.");
            //}
            //return Ok(lista);

            return _showRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_showRepository.GetById(id) != null)
            {
                return Ok(_showRepository.GetById(id));
            }
            else
            {
                return BadRequest("Show não encontrado.");
            }
        }

        [HttpPost]
        public IActionResult Post(Show show)
        {
            try
            {
                _showRepository.Add(show);
                return Ok("Show cadastrado");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar show.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Show show)
        {
            try
            {
                Show showBanco = new Show
                {
                    Id = id,
                    Nome = show.Nome,
                    Data = show.Data,
                    Descricao = show.Descricao,
                    NumeroPessoas = show.NumeroPessoas
                };

                _showRepository.Update(showBanco);
                return Ok("Show atualizado.");
            }
            catch
            {
                return BadRequest("Erro ao atualizar Show.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Show show = _showRepository.GetById(id);
                _showRepository.Delete(show);
                return Ok("show deletado");
            }
            catch
            {
                return BadRequest("Erro ao deletar show.");
            }
        }
    }
}
