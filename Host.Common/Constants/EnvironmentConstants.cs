namespace Host.Common.Constants
{
    public static class EnvironmentConstants
    {
        public const string GH_DB_CONNECTION = "GH_DB_CONNECTION"; //"server=localhost;user=root;database=host_dev;password=root;port=3306"
        public const string GH_DB_SQLSERVER_CONNECTION = "GH_DB_SQLSERVER_CONNECTION"; //"server=localhost;user=root;database=gh_dev;password=root;port=3306"
        public const string GH_DB_MONGO_CONNECTIONSTRING = "GH_DB_MONGO_CONNECTIONSTRING"; // mongodb://localhost:27017
        public const string GH_DB_MONGO_DBName = "GH_DB_MONGO_DBName";
        public const string SENDGRID_API_KEY = "SENDGRID_API_KEY";
        public const string FROM_EMAIL_ADDRESS = "FROM_EMAIL_ADDRESS";
        public const string SMS_ACCOUNT_SID = "SMS_ACCOUNT_SID";
        public const string SMS_AUTH_TOKEN = "SMS_AUTH_TOKEN";
        public const string SMS_PHONE_FROM = "SMS_PHONE_FROM";
        public static string FileStorageType = "FileStorageType";
        public static string DB_Provider = "DB_Provider";
        public static string AzureBlobConnectionString = "AzureBlobConnectionString";

        public static string FileStorageAzureBlob = "FileStorageAzureBlob";
        public static string DB_Provider_AzureSql = "AzureSql";
        public static string AzureSqlConnectionString = "AzureSqlConnectionString";
        public static string BackgroundJobInterval = "BackgroundJobInterval";
        public static string BackgroundJobIntervalTransaction = "BackgroundJobIntervalTransaction";
        public static string BackgroundJobIntervalDefault = "24"; // hours
        public static string BackgroundJobIntervalTransactionDefault = "5"; // minutes
        public static string FE_URL = "FE_URL";
    }
}
