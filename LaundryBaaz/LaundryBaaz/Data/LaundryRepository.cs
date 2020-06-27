using LaundryBaaz.Interfaces;
using LaundryBaaz.Models;
using Microsoft.Extensions.Options;
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
    }
}
