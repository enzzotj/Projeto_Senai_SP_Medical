﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using SENAI.SP.MEDICAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Listar()
        {
            if (_usuarioRepository.ListarUsuarios() == null)
            {
                return NotFound(new
                {
                    Mensagem = "Não há nenhum usuario cadastrado ainda"
                });
            }

            return Ok(_usuarioRepository.ListarUsuarios());
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUser)
        {
            try
            {
                if (novoUser == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "É necessário informar todos os dados"
                    });
                }
                _usuarioRepository.Cadastrar(novoUser);
                return StatusCode(201, new
                {
                    Mensagem = "O usuario informado foi cadastrado!",
                    novoUser
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("atualizar/{id}")]
        public IActionResult Atualizar(int id, Usuario atualizarUsuario)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informe um ID válido"
                    });
                }

                if (_usuarioRepository.BuscarPorId(id) == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhum usuário com este ID"
                    });
                }
                if (atualizarUsuario == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "É necessário informar todos os dados!"
                    });
                }
                _usuarioRepository.Atualizar(id, atualizarUsuario);
                return StatusCode(200, new
                {
                    Mensagem = "O usuario informado foi atualizado!",
                    atualizarUsuario
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("imagem/bd/{idUsuario}")]
        public IActionResult postBD(IFormFile arquivo, short idUsuario)
        {
            try
            {
                if (arquivo == null)
                {
                    return BadRequest(new { mensagem = "É necessario enviar uma foto .png" });
                }
                if (arquivo.Length > 5000)
                {
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem é de 5mb" });
                }

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png" || extensao != "jpg")
                {
                    return BadRequest(new { mensagem = "Apenas arquivos .png ou .jpg são permitidos" });
                }

                _usuarioRepository.SalvarPerfil(arquivo, idUsuario);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }


        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("imagem/bd/{idUsuario}")]
        public IActionResult getBd(short idUsuario)
        {
            try
            {
                string base64 = _usuarioRepository.ConsultarPerfil(idUsuario);
                return Ok(base64);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("deletar/{idUsuario}")]
        public IActionResult Deletar(short idUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(idUsuario);

                return Ok();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);

            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario userBuscado = _usuarioRepository.BuscarPorId(id);

                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Escreva ID "
                    });
                }

                if (userBuscado == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não existe nenhum usuário"
                    });
                }

                return StatusCode(201, new
                {
                    Mensagem = "Usuário foi encontrado!",
                    userBuscado
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
