using System.Text;

namespace Host.Common.Constants
{
    public class GlobalConstants
    {
        public const string REGEX_PASSCODE = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z])(.*)$";
        public const string SuperAdminUsername = "superadmin";
        //Superadmin1st => Argon2id 8cores, memory 1024 * 8 = 0.0078125 GB, 4 iterations, 16lengths
        public const string SuperAdminPassword = "Superadmin1st";

    }
}
