using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Models;
using MongoDB.Driver;

namespace CarsApi.Services
{
    public class CarService
    {
        private readonly IMongoCollection<Cars> _cars;

        public CarService(ICarStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cars = database.GetCollection<Cars>(settings.CarsCollectionName);
        }

        public List<Cars> Get() =>
            _cars.Find(car => true).ToList();

        public Cars Get(string id) =>
            _cars.Find<Cars>(car => car.Id == id).FirstOrDefault();

        public Cars Create(Cars car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Cars cars)
        {
            _cars.ReplaceOne(car => car.Id == id, cars);
        }

        public void Remove(Cars carIn) =>
            _cars.DeleteOne(car => car.Id == carIn.Id);
        

        public void Remove(string id) =>
            _cars.DeleteOne(car => car.Id == id);
    }
}
