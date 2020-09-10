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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            IEnumerable<Jogo> lista = _jogoRepository.GetTodos();
            if (lista.Count() == 0)
            {
                return BadRequest("Cadastre um jogo.");
            }
            return Ok(lista);
            //return _jogoRepository.GetAll();
        }

        /// <summary>
        /// Busca um jogo através do seu ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Retorna um jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// <response code="200">Se a lista for acessada com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Get(int id)
        {
            if (_jogoRepository.GetById(id) != null)
            {
                return Ok(_jogoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Jogo não encontrado.");
            }
        }

        /// <summary>
        /// Cadastra um novo confronto
        /// </summary>
        /// <param name="jogo">Objeto novoJogo que será cadastrado</param>
        /// <response code="201">Se o Jogo for cadastrado com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Jogo jogo)
        {
            try
            {
                _jogoRepository.Add(jogo);
                return Ok("Confronto cadastrado");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar confronto.");
            }

        }

        /// <summary>
        /// Atualiza um jogo pelo ID.
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <param name="jogo">ID do jogo que será buscado</param>
        /// <returns>null</returns>
        /// <response code="200">Se a lista for acessada com sucesso</response>
        /// <response code="400">Erro em alguma parte da requisição</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogo jogo)
        {
            try
            {
                Jogo jogoBanco = new Jogo
                {
                    Id = id,
                    SelecaoCasa = jogo.SelecaoCasa,
                    SelecaoVisitante = jogo.SelecaoVisitante,
                    Data = jogo.Data,
                    Descricao = jogo.Descricao
                };

                _jogoRepository.Update(jogoBanco);
                return Ok("Jogo atualizado.");
            }
            catch
            {
                return BadRequest("Erro ao atualizar jogo.");
            }
        }

        /// <summary>
        /// Deleta um jogo pelo ID.
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>null</returns>
        /// <response code="200">Se a lista for acessada com sucesso</response>
        /// <response code="404">Erro em alguma parte da requisição</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Jogo jogo = _jogoRepository.GetById(id);
                _jogoRepository.Delete(jogo);
                return Ok("Jogo deletado");
            }
            catch
            {
                return BadRequest("Erro ao deletar jogo.");
            }
        }
    }
}
