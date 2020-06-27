using LaundryBaaz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Interfaces
{
    public interface ILaundryRepository
    {
        Task<bool> SignUpDetails(Profile profile);
        Task<bool> Submit(ClothInfo clothInfo);
    }
}
