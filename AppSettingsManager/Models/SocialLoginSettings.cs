namespace AppSettingsManager.Models
{
    public class SocialLoginSettings
    {
        public ValueKey FacebookLoginSettings { get; set; }
        public ValueKey GoogleLoginSettings { get; set; }
    }

    public class ValueKey
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
