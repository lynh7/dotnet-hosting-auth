using Host.Common.SharedController;
using Host.DB.Entities;
using Host.Models.APIModels;
using Host.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Host.Common.Enums.CommonEnums;

namespace Host.Auth.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AuthController : BaseController
    {

        //check login type
        //check if vaild login then generate a token

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        private async Task<Client> PvLogin(LoginRequest vm, LoginType type)
        {
            Client client = new Client();

            switch (type)
            {
                case LoginType.Default:
                    {
                        var tLogin = _authService.Login(vm.Username, vm.Password);
                        client = tLogin.Result;
                        break;
                    }
            }

            return client;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// This API allowed user login into system.      
        /// </remarks>
        /// <remarks>
        /// Login API description:
        /// Enter OTP value 290993 for cheating corrected OTP.
        /// 
        ///     Login Flows: 
        ///     1. Login Sucessful -> return Token -> Done
        ///     2. Login Succesful -> Return MFAType -> Requesting auth/multi-factor/{type} with MFAType in the response (read more at the multi-factor api)
        ///     3. Login Succesful -> Return UserVerifyingType -> Requesting /user/verifying/ api with UserVerifyingType in the response model.
        /// 
        ///     4.1: Passcode expiry logic:
        ///         Based on Application.ChangePasscodeAfterXDays and 'ChangePasscodeAfterXDaysNotify'.
        ///     4.1.1: 'ChangePasscodeAfterXDays': User must change their passcode after x Days. COA system will check it and return message.
        ///     4.1.2: 'ChangePasscodeAfterXDaysNotify': Show Warning when login, 3rd-app MUST implement this using responese.PasscodeWarningDays and responese.PasscodeWarningMessage
        ///             when responese.PasscodeWarningDays > 0, 3rd-app must show the notification for user knowing that they gotta be expiry soon.
        ///  
        ///     [Flags]
        ///     public enum LoginType
        ///     {
        ///          None = 0,
        ///          Default = 1 << 0,
        ///          Phone = 1 << 2,
        ///          Email = 1 << 3,
        ///     }
        ///            
        /// </remarks>
        /// <param name="vm">LoginByMailModel model</param>
        /// <param name="type">Login Enum Type</param>
        /// <returns>
        /// Logging successed => return token
        /// MFA Required => return next MFAType and user basic data for MFA (like mail, phone)
        /// </returns>
        /// <response code="200">Success</response>
        /// <response code="500">Server Error.</response>
        /// <response code="401">Login failed</response>
        /// <response code="403">Forbiden access</response>
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [HttpPost("login/{type}")]
        public async Task<IActionResult> Login(LoginRequest vm, LoginType type)
        {
            try
            {
                var tPvLogin = PvLogin(vm, type);
                var client = tPvLogin.Result;

                if (client.Id == Guid.Empty) throw new Exception("Login Failed");

                //pass login logic
                var responseModel = new LoginResponse();

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return await ConvertExpcetionToHttpStatus(ex);
            }
        }
    }
}
