using Host.Common.SharedController;
using Host.DB.Entities;
using Host.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Host.Book.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get All Books
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var result = await _bookService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return await ConvertExpcetionToHttpStatus(ex);

            }
        }

        /// <summary>
        /// Create Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel model)
        {
            try
            {
                var entity = await _bookService.InsertAsync(model.ToEntity(new DB.Entities.Book()));
                return Ok(model.ToModel(entity));
            }
            catch (Exception ex)
            {
                return await ConvertExpcetionToHttpStatus(ex);
            }
        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns>BookModel</returns>
        /// 
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel model)
        {
            try
            {
                var entity = await _bookService.GetByIdAsync(model.Id);
                if (entity == null)
                {
                    return BadRequest("Not found Book Id");
                }
                var entityUpdated = await _bookService.UpdateAsync(model.ToEntity(entity));

                return Ok("Update successfully");
            }
            catch (Exception ex)
            {
                return await ConvertExpcetionToHttpStatus(ex);
            }
        }


        /// <summary>
        /// Delete Book with Id
        /// </summary>
        /// <param name="Id">Book Id</param>
        /// <returns>Message + model</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            try
            {
                var entity = await _bookService.GetByIdAsync(Id);
                if (entity == null)
                {
                    return BadRequest("Not found Book Id");
                }
                
                await _bookService.DeleteAsync(entity);

                return Ok("Delete successfully");
            }
            catch (Exception ex)
            {
                return await ConvertExpcetionToHttpStatus(ex);
            }
        }
    }
}
