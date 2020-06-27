using LaundryBaaz.Interfaces;
using LaundryBaaz.Models;
using Microsoft.Extensions.Options;
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
    }
}
