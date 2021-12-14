using MongoDB.Driver;
using SENAI.SP.MEDICAL.Domains;
using SENAI.SP.MEDICAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SENAI.SP.MEDICAL.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SpMedical_Tarde");
            _localizacoes = database.GetCollection<Localizacao>("mapas");
        }

        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacoes.InsertOne(novaLocalizacao);
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
