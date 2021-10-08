using SENAI.SP.MEDICAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        void Cadastrar(Medico novoMedico);
    }
}
