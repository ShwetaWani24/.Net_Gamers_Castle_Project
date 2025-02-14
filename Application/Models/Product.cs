using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public int Stock { get; set; }
        public String ImageUrl { get; set; }
        public ICollection <Order> Orders { get; set; }
    }
}
