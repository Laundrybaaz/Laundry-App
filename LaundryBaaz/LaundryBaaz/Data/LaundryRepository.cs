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

                if (_context.GetProfiles.Find(x => x.Email == profile.Email).FirstOrDefaultAsync().Result==null)
                {
                    _context.GetProfiles.InsertOneAsync(profile);
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

        public Task<bool> Submit(ClothInfo clothInfo)
        {
            try
            {
                clothInfo.orderId = getLatestOrderId() + 1;
                _context.ClothInfo.InsertOneAsync(clothInfo);
                _context.GetLatestOrderIdForClothInfo.UpdateOne(
                    Builders<OrderId>.Filter.Eq("orderId", getLatestOrderId()),
                    Builders<OrderId>.Update.Set("orderId", clothInfo.orderId)
                    );
                return Task.FromResult(true);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int getLatestOrderId()
            {
            return _context.GetLatestOrderIdForClothInfo.AsQueryable().First().orderId;
            }
    }
}
