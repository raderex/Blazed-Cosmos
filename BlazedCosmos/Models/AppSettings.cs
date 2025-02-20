namespace BlazedCosmos.Models
{
    public class AppSettings
    {
        public string ApiKey { get; set; }
        public FeatureFlags FeatureFlags { get; set; }
    }

    public class FeatureFlags
    {
        public bool EnableNewCheckout { get; set; }
    }
}