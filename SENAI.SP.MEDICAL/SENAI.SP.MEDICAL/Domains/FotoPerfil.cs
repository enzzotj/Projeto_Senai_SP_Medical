using System;
using System.Collections.Generic;

#nullable disable

namespace SENAI.SP.MEDICAL.Domains
{
    public partial class FotoPerfil
    {
        public short IdFotoPerfil { get; set; }
        public short? IdUsuario { get; set; }
        public string NomeArquivo { get; set; }
        public byte[] Binario { get; set; }
        public string MimeType { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
