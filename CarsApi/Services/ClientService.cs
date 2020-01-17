using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using CarsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarsApi.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;


        public ClientService(ICarStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _client = database.GetCollection<Client>(settings.ClientCollectionDetails);
        }

        public List<Client> Get() =>
            _client.Find(client => true).ToList();

        public Client Get(string id) =>
            _client.Find<Client>(client => client.Id == id).FirstOrDefault();
        

        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }

        public void Update(string id, Client cli)
        {
            _client.ReplaceOne(client => client.Id == id, cli);
        }

        public void Removed(Client cli) =>
            _client.DeleteOne(client => client.Id == cli.Id);

        public void Removed(string id) =>
            _client.DeleteOne(client => client.Id == id);
    }
}
