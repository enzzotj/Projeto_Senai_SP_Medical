using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI.SP.MEDICAL.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public short IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
