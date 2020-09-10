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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Retorna todos os usuarios.
        /// </summary>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET: api/<Usuario>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _usuarioRepository.GetAll();
        }

        /// <summary>
        /// Retorna um usuario por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuario Object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET api/<Usuario>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_usuarioRepository.GetById(id) != null)
            {
                return Ok(_usuarioRepository.GetById(id));
            }
            else
            {
                return BadRequest("Usuario nao encontrado.");
            }
        }

        /// <summary>
        /// Cadastra um usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<Usuario>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Add(usuario);
                return Ok("Usuário cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar usuário.");
            }
        }

        /// <summary>
        /// Atualiza um usuario passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT api/<Usuario>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                Usuario user = new Usuario
                {
                    Id = id,
                    Nome = usuario.Nome,
                    Apelido = usuario.Apelido,
                    Email = usuario.Email,
                    Senha = usuario.Senha

                };

                _usuarioRepository.Update(user);
                return Ok("Usuário atualizado.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar o Usuário ");

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Usuario user = _usuarioRepository.GetById(id);
                _usuarioRepository.Delete(user);
                return Ok("Usuário Deletado.");
            }
            catch
            {
                return BadRequest("Erro ao deletar.");
            }
        }
    }
}
