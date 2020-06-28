using LaundryBaaz.Interfaces;
using LaundryBaaz.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Data
{
    public class LaundryRepository : ILaundryRepository
    {
        private readonly LaundryContext _context = null;

        public LaundryRepository(IOptions<Settings> settings)
        {
            _context = new LaundryContext(settings);
        }

        public Task SignUpDetails(Profile profile)
        {
            try
            {
                return _context.SignUpDetails.InsertOneAsync(profile);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public long GetAvailability(string email, string password)
            {

            var profiles = _context.SignUpDetails;

            var filters = Builders<Profile>.Filter.Where(k => k.Email == email && k.Password == password);

            return profiles.Find(filters).CountDocuments();
            }
    }
}
