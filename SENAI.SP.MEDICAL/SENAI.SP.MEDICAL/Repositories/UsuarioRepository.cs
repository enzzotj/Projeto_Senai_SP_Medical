using Microsoft.AspNetCore.Http;
using SENAI.SP.MEDICAL.Contexts;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI.SP.MEDICAL.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();

        public void Atualizar(int id, Usuario atualizarUsuario)
        {
            Usuario userBuscado = BuscarPorId(id);

            if (atualizarUsuario.Senha != null || atualizarUsuario.Email != null)
            {
                userBuscado.Email = atualizarUsuario.Email;
                userBuscado.Senha = atualizarUsuario.Senha;

                ctx.Usuarios.Update(userBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUser)
        {
            ctx.Usuarios.Add(novoUser);
            ctx.SaveChanges();
        }

        public string ConsultarPerfil(short id)
        {
            FotoPerfil imagemBuscada = new FotoPerfil();

            imagemBuscada = ctx.FotoPerfils.FirstOrDefault(i => i.IdUsuario == id);

            if (imagemBuscada != null)
            {
                return Convert.ToBase64String(imagemBuscada.Binario);
            }

            return null;
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
            if (usuarioBuscado == null)
            {
                throw new Exception("Id nao existente");
            }
            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios
                .Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Email = u.Email,
                    IdTipoUsuario = u.IdTipoUsuario,
                    IdTipoUsuarioNavigation = new TipoUsuario()
                    {
                        NomeTipoUser = u.IdTipoUsuarioNavigation.NomeTipoUser
                    }
                })
                .ToList();
        }

        public Usuario Login(string EmailUsuario, string SenhaUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == EmailUsuario && e.Senha == SenhaUsuario);
        }

        public void SalvarPerfil(IFormFile foto, short id)
        {
            FotoPerfil novaImagem = new FotoPerfil();

            using (var ms = new MemoryStream())
            {
                foto.CopyTo(ms);

                novaImagem.Binario = ms.ToArray();
                novaImagem.NomeArquivo = foto.FileName;
                novaImagem.MimeType = foto.FileName.Split('.').Last();
                novaImagem.IdUsuario = id;
            }

            FotoPerfil imagemExistente = new FotoPerfil();
            imagemExistente = ctx.FotoPerfils.FirstOrDefault(i => i.IdUsuario == id);

            if (imagemExistente != null)
            {
                imagemExistente.Binario = novaImagem.Binario;
                imagemExistente.NomeArquivo = novaImagem.NomeArquivo;
                imagemExistente.MimeType = novaImagem.MimeType;
                imagemExistente.IdUsuario = id;

                ctx.FotoPerfils.Update(imagemExistente);
            }
            else
            {
                ctx.FotoPerfils.Add(novaImagem);
            }

            ctx.SaveChanges();
        }
    }
}
