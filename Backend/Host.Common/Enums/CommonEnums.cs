namespace Host.Common.Enums
{
    public class CommonEnums
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter), true)]
        [Flags]
        public enum LoginType
        {
            None = 0,
            Default = 1 << 0,
            Phone = 1 << 2,
            Email = 1 << 3,
        }
    }
}
