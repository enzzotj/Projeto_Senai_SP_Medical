using SENAI.SP.MEDICAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);
        void Atualizar(int id, Clinica attClinica);
        List<Clinica> ListarTodas();
        Clinica BuscarClinica(int id);
        void Deletar(int idClinica);
    }
}
