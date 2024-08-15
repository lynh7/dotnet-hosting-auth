using Host.DB.Entities.Base;

namespace Host.DB.Entities
{
    public class BookCategory : BaseEntity
    {
        public BookCategory()
        {
            CreatedOn = DateTime.Now;
            CategoryName = string.Empty;
            Books = new List<Book>();
        }

        public string CategoryName { get; set; }
        public virtual IList<Book>? Books { get; set; }

        public BookCategory InitBookCategory()  
        {
            Id = new Guid("6007d295-0d25-4c4b-8935-f440b326cc3e");
            CategoryName = "Art & Music ";

            return this;
        }
    }
}
