using Host.Models.APIModels.BaseModel;

namespace Host.DB.Entities
{
    public class BookModel : BaseModel
    {
        public string BookName { get; set; }
        public string? BorrowFee { get; set; }
        public Guid BookCategoryId { get; set; }

        //TODO BorrowFee LOGIC
    }

    public static class BookModelStatic
    {
        public static Book ToEntity(this BookModel bookModel, Book entity)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.BookName = bookModel.BookName;
            entity.BookCategoryId = bookModel.BookCategoryId;
            entity.BorrowFee = bookModel.BorrowFee;

            return entity;
        }

        public static BookModel ToModel(this BookModel bookModel, Book entity)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));

            }
            bookModel.BookName = entity.BookName;
            bookModel.BookCategoryId = entity.BookCategoryId;
            bookModel.BorrowFee = entity.BorrowFee;

            return bookModel;
        }
    }
}
