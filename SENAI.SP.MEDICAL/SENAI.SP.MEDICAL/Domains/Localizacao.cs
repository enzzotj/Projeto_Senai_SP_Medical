using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SENAI.SP.MEDICAL.Domains
{
    public class Localizacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string latitude { get; set; }

        [BsonRequired]
        public string longitude { get; set; }

        public string descricao { get; set; }

        public string idade { get; set; }

        public string especialidade { get; set; }

    }
}
