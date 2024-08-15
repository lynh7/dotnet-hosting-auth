using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace Host.Common.SharedController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Exception GetInnerEx(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
        protected async Task<IActionResult> ConvertExpcetionToHttpStatus(Exception exception)
        {
            Log.Error(exception.ToString());

            var inerEx = GetInnerEx(exception);
            var responseModel = new { Message = inerEx.Message };

            if (inerEx is SecurityException)
            {
                return await Task.Run(() => { return Unauthorized(responseModel.Message); });
            }

            //https://stackoverflow.com/a/3290369/3635724
            if (inerEx is ValidationException)
            {
                return await Task.Run(() => { return StatusCode(403, responseModel.Message); }); //Forbiden
            }

            return StatusCode(500, responseModel); // Default case.
        }
    }
}
