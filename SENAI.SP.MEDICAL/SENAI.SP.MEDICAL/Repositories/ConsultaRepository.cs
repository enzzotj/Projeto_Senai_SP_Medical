using Microsoft.EntityFrameworkCore;
using SENAI.SP.MEDICAL.Contexts;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id);
        }

        public void CadastrarConsulta(Consultum novaConsulta)
        {

            novaConsulta.IdSituacao = 2;

            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void CancelarConsulta(int Id)
        {
            Consultum consultaBuscada = BuscarPorId(Id);
            consultaBuscada.IdSituacao = 3;

            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
        }

        public List<Consultum> ListarConsultaMedico(int id)
        {
            return ctx.Consulta
                .Include(c => c.IdMedicoNavigation.IdUsuarioNavigation)
                .Where(c => c.IdMedicoNavigation.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }

        public List<Consultum> ListarConsultaPaciente(int id)
        {
            return ctx.Consulta
                .Include(c => c.IdPacienteNavigation.IdUsuarioNavigation)
                .Where(c => c.IdPacienteNavigation.IdUsuarioNavigation.IdUsuario == id)
                .ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return ctx.Consulta
                .Select(p => new Consultum()
                {
                    IdPaciente = p.IdPaciente,
                    IdMedico = p.IdMedico,
                    IdConsulta = p.IdConsulta,
                    IdSituacao = p.IdSituacao,
                    DataConsulta = p.DataConsulta,

                    IdMedicoNavigation = new Medico()
                    {
                        Crm = p.IdMedicoNavigation.Crm,
                        IdEspecialidadeNavigation = new Especialidade()
                        {
                            NomeEspecialidade = p.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade,

                        }
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Rg = p.IdPacienteNavigation.Rg,
                        Cpf = p.IdPacienteNavigation.Cpf,
                        DataNascimento = p.IdPacienteNavigation.DataNascimento,
                        EnderecoPaciente = p.IdPacienteNavigation.EnderecoPaciente,
                        IdUsuarioNavigation = new Usuario()
                        {
                            NomeUsuario = p.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                            Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                        }
                    },

                })
                .ToList();
        }
    }
}
