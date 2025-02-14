namespace Entities
{
    public class User
    {
        public int UserId { get; set; }//Primary Key
        public String Name { get; set; }
        public String Address { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public ICollection<Order>Orders { get; set; }//One to Many with Orders Navigational Property
    }
}
