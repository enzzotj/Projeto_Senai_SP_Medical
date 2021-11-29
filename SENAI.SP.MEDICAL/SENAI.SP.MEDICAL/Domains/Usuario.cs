using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI.SP.MEDICAL.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            FotoPerfils = new HashSet<FotoPerfil>();
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public short IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<FotoPerfil> FotoPerfils { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
