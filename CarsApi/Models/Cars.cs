using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CarsApi.Models
{
    public class Cars
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

       [BsonElement("brand")]
        public string brand { get; set; }

        public string color { get; set; }
        public int prize { get; set; }
        public string model { get; set; }
        public bool available { get; set; }

    }
}
