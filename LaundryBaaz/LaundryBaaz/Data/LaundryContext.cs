using LaundryBaaz.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Data
{
    public class LaundryContext
    {
        private readonly IMongoDatabase _database = null;

        public LaundryContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Profile> SignUpDetails
        {
            get
            {
                return _database.GetCollection<Profile>("Profile");
            }
        }


        
    }
}
