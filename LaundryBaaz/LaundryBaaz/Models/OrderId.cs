using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Models
    {
      
    public class OrderId
        {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public int orderId { get; set; }


        }
    }
