﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SENAI.SP.MEDICAL.Domains;
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
    public class ClinicasController : ControllerBase
    {
        private ClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            try
            {

                if (novaClinica == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os valores inseridos são inválidos"
                    });
                }
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201, new
                {
                    Mensagem = "Clinica foi cadastrada",
                    novaClinica
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Clinica> lista = _clinicaRepository.ListarTodas();

                if (lista == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não existe nenhuma instituição"
                    });
                }

                return Ok(new
                {
                    Mensagem = $"Foram encontradas {lista.Count()} Clínicas",
                    lista
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, Clinica attClinica)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Escreva um Id"
                    });
                }

                if (_clinicaRepository.BuscarClinica(id) == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não existe nenhuma clínica "
                    });
                }
                if (attClinica.Cnpj == null || attClinica.Endereco == null || attClinica.NomeClinica == null || attClinica.RazaoSocial == null || attClinica.Cnpj.Length != 14)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Informações inseridas são inválidas!"
                    });
                }

                _clinicaRepository.Atualizar(id, attClinica);
                return Ok(new
                {
                    Mensagem = "Clínica foi atualizada",
                    attClinica
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Escreva um id"
                    });
                }

                if (_clinicaRepository.BuscarClinica(id) == null)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não existe nenhuma clínica"
                    });
                }

                _clinicaRepository.Deletar(id);
                return Ok(new
                {
                    Mensagem = "Clínica foi excluída",
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }



        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            return Ok(_clinicaRepository.BuscarClinica(id));
        }

    }
}

