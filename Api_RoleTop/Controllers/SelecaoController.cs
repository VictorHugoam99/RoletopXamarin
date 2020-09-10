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
    public class SelecaoController : ControllerBase
    {
        private ISelecaoRepository _selecaoRepository { get; set; }

        public SelecaoController()
        {
            _selecaoRepository = new SelecaoRepository();
        }

        /// <summary>
        /// Retorna todas as seleções.
        /// </summary>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET: api/<Selecao>
        [HttpGet]
        public IEnumerable<Selecao> Get()
        {
            return _selecaoRepository.GetAll();
        }

        /// <summary>
        /// Retorna uma seleção por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Selecao Object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET api/<Selecao>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_selecaoRepository.GetById(id));
        }

        /// <summary>
        /// Cadastra uma seleção.
        /// </summary>
        /// <param name="selecao"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<Selecao>
        [HttpPost]
        public IActionResult Post(Selecao selecao)
        {
            try
            {
                _selecaoRepository.Add(selecao);
                return Ok("Seleção cadastrada com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar Seleção.");
            }
        }

        /// <summary>
        /// Atualiza uma seleção passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="selecao"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT api/<Selecao>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Selecao selecao)
        {
            try
            {
                Selecao selec = new Selecao
                {
                    Id = id,
                    Nome = selecao.Nome,
                    Foto = selecao.Foto         
                };

                _selecaoRepository.Update(selec);
                return Ok("Seleção atualizada.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar a Seleção ");

            }
        }

        /// <summary>
        /// Deleta uma seleção passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // DELETE api/<Selecao>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Selecao selecao = _selecaoRepository.GetById(id);
                _selecaoRepository.Delete(selecao);
                return Ok("Seleção Deletada.");
            }
            catch
            {
                return BadRequest("Erro ao deletar Seleção.");
            }
        }
    }
}
