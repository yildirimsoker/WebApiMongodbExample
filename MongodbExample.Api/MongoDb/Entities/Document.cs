using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbExample.Api.MongoDb.Entities
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
    }
}
