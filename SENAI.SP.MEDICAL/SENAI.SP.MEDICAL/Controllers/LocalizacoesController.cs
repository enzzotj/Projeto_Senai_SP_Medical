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
    public class LocalizacoesController : ControllerBase
    {
        private ILocalizacaoRepository _localizacaoRepository { get; set; }

        public LocalizacoesController()
        {
            _localizacaoRepository = new LocalizacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_localizacaoRepository.ListarTodas());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacao novalocalizacao)
        {
            try
            {
                _localizacaoRepository.Cadastrar(novalocalizacao);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
