using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CarsApi.Models
{
    public class Client
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string carId { get; set; }


    }
}
