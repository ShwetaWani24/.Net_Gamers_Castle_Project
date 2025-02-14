using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    
        public class Order
        {
            public int OrderId { get; set; }//Primary Key
            public int UserId { get; set; }//Foreign Key
            public int ProductId { get; set; }//Foreign Key
            public DateTime OrderDate { get; set; }
            public long Total { get; set; }
            public String OrderStatus { get; set; }
            public User user { get; set; }//Many To One Navigational Property
            public Product product { get; set; }//Many to One Navigational Property 
        }
    }

