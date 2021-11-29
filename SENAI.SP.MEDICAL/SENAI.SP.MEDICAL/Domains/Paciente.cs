﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI.SP.MEDICAL.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdPaciente { get; set; }
        public short? IdUsuario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string EnderecoPaciente { get; set; }
        public string NomePaciente { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
