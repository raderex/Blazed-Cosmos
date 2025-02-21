using Microsoft.AspNetCore.Http;
using Newtonsoft.Json; // Add this using directive

namespace BlazedCosmos.Helpers
{
    public static class SessionExtensions
    {
        // Remove the JsonConvert property
        // public static object JsonConvert { get; private set; }

        // Get an object from session as JSON
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        // Save an object to session as JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}