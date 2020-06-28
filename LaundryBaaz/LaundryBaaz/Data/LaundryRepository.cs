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

        public Task<bool> SignUpDetails(Profile profile)
        {
            try
            {

                if (_context.SignUpDetails.Find(x => x.Email == profile.Email).FirstOrDefaultAsync().Result==null)
                {
                    _context.SignUpDetails.InsertOneAsync(profile);
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }

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
