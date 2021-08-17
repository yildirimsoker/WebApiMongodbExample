using MongoDB.Bson;
using MongodbExample.Api.MongoDb.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbExample.Api.MongoDb.Entities
{
    [BsonCollection("Product")]
    public class Product : Document
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string ProductDescription { get; set; }
    }
}
