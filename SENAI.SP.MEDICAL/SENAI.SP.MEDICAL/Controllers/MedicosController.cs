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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }



        [HttpGet]
        public IActionResult Listar()
        {
            List<Medico> lista = _medicoRepository.ListarTodos();

            return Ok(lista);
        }



        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            try
            {
                if (novoMedico.Crm == null || novoMedico.IdEspecialidade <= 0 || novoMedico.IdClinica <= 0 || novoMedico.IdUsuario <= 0)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Dados errados"
                    });
                }

                _medicoRepository.Cadastrar(novoMedico);

                return Ok(new
                {
                    Mensagem = "Médico foi cadastrado",
                    novoMedico
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
