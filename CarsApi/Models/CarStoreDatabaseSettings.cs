﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Models
{
    public class CarStoreDatabaseSettings : ICarStoreDatabaseSettings
    {
        public string ClientCollectionDetails { get; set; }
        public string CarsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICarStoreDatabaseSettings
    {
        string ClientCollectionDetails { get; set; }
        string CarsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
