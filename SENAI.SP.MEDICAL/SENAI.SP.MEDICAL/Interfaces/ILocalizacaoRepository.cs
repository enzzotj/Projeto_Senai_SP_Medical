using SENAI.SP.MEDICAL.Domains;
using System.Collections.Generic;

namespace SENAI.SP.MEDICAL.Interfaces
{
    interface ILocalizacaoRepository
    {

        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);


    }
}
