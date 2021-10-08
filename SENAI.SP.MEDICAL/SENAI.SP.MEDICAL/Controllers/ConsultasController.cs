using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using SENAI.SP.MEDICAL.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Consultum> listaConsultas = _consultaRepository.ListarTodas();
                if (listaConsultas.Count == 0)
                {
                    return StatusCode(404, new
                    {
                        Mensagem = "Não há nenhuma consulta cadastrada no sistema!"
                    });
                }
                return Ok(listaConsultas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Authorize(Roles = "Médico")]
        [HttpGet("Medico")]
        public IActionResult ConsultaMedico()
        {

            try
            {
                short idMedico = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Consultum> listaConsulta = _consultaRepository.ListarConsultaMedico(idMedico);

                if (listaConsulta.Count == 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhuma consulta do medico informado"
                    });
                }

                return Ok(listaConsulta);
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Nao foi possivel ver suas consultas",
                    erro
                });
            }

        }

        [Authorize(Roles = "2")]
        [HttpGet("Paciente")]
        public IActionResult ConsultaPaciente()
        {

            try
            {
                short idPaciente = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                List<Consultum> listaConsulta = _consultaRepository.ListarConsultaPaciente(idPaciente);

                if (listaConsulta.Count == 0)
                {

                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhuma consulta do paciente informado"
                    });
                }

                return Ok(listaConsulta);
            }
            catch (Exception erro)
            {

                return BadRequest(new
                {
                    mensagem = "Nao foi possivel ver suas consultas",
                    erro
                });
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsulta)
        {
            try
            {

                if (novaConsulta.IdMedico == null || novaConsulta.IdPaciente == null || novaConsulta.DataConsulta < DateTime.Now)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os dados informados são inválidos"
                    });
                }
                _consultaRepository.CadastrarConsulta(novaConsulta);

                return StatusCode(201, new
                {
                    Mensagem = "Consulta foi cadastrada",
                    novaConsulta
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("Cancelar/{id:int}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Escreva um ID válido"
                    });
                }

                if (_consultaRepository.BuscarPorId(id) == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Não há nenhuma consulta"
                    });
                }
                _consultaRepository.CancelarConsulta(id);

                return StatusCode(204, new
                {
                    Mensagem = "Consulta foi cancelada"
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
            return Ok(_consultaRepository.BuscarPorId(id));
        }

    }
}