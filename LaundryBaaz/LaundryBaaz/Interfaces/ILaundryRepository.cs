using LaundryBaaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Interfaces
{
    public interface ILaundryRepository
    {
        Task SignUpDetails(Profile profile);

        bool GetAvailability(string email, string password);
    }
}
