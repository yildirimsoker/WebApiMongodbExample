using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbExample.Api.ApiModel
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public string ProductDescription { get; set; }
        public string Id { get; set; }
    }
}
