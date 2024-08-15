using Host.Common.Constants;
using Host.Common.Utilities;
using Host.DB.Entities.Base;

namespace Host.DB.Entities
{
    public class Client : BaseEntity
    {
        public Client()
        {
            IsSuperAdmin = false;
        }

        public string? Name { get; set; }
        public string? CellNumber { get; set; }


        //TODO LOGIN LOGIC
        public string? Username { get; set; }

        private byte[] _password;
        /// <summary>
        /// Only public getter, setter will be private.
        /// For what? For knowing which places are changing this field!
        /// </summary>
        /// <value></value>
        public byte[]? Password { get; private set; }

        public bool IsSuperAdmin { get; set; }

        private string _passwordSalt;

        /// <summary>
        /// Every single passcode has their own salt for more secured.
        /// </summary>
        /// 
        public string PasscodeSalt
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_passwordSalt))
                {
                    var salt = Convert.ToBase64String(Utility.CreateSalt());
                    _passwordSalt = salt;
                }

                return _passwordSalt;
            }
            set
            {
                this._passwordSalt = value;
            }
        }

        public Client SuperAdminSeedDefault()
        {
            Username = GlobalConstants.SuperAdminUsername;
            Password = Utility.HashPassword(GlobalConstants.SuperAdminPassword, PasscodeSalt);

            IsSuperAdmin = true;

            return this;
        }

        //TODO BORROW BOOK LOGIC

        //TODO ADMIN LOGIC
    }
}
