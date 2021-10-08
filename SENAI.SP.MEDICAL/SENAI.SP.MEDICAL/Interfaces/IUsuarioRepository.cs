using Microsoft.AspNetCore.Http;
using SENAI.SP.MEDICAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();
        void Cadastrar(Usuario novoUser);
        Usuario Login(string email, string senha);
        void SalvarPerfil(IFormFile foto, short id);
        string ConsultarPerfil(short id);
        void Atualizar(int id, Usuario atualizarUsuario);
        Usuario BuscarPorId(int id);
        void Deletar(int id);
    }
}
