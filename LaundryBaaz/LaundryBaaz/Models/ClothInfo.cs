using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryBaaz.Models
{
    public class ClothInfo
    {
        public string UserId { get; set; }
        public CountValue Shirt { get; set; }
        public CountValue Pants { get; set; }
    }

    public class CountValue
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
