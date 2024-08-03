using Host.DB.Entities.Base;

namespace Host.DB.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string? CellNumber { get; set; }


        //TODO LOGIN LOGIC
        public string? Username { get; set; }
        public string? Password { get; set; }

        //TODO BORROW BOOK LOGIC

        //TODO ADMIN LOGIC
    }
}
