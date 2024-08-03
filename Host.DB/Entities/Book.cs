using Host.DB.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Host.DB.Entities
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public string? BorrowFee { get; set; }

        public Guid BookCategoryId { get; set; }

        [ForeignKey("BookCategoryId")]
        public virtual BookCategory Category { get; set; }

        //TODO BorrowFee LOGIC
    }
}
