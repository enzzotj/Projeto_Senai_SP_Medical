using SENAI.SP.MEDICAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodas();
        List<Consultum> ListarConsultaPaciente(int id);
        List<Consultum> ListarConsultaMedico(int id);
        void CadastrarConsulta(Consultum novaConsulta);
        void CancelarConsulta(int Id);
        Consultum BuscarPorId(int id);
    }
}
