using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace FRFLTestFramework.Config
{
    public class ConfigReader
    {
        public static TestSettings? Readconfig() 
        {
           var configFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"/AppSettings.json");

            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive= true

            };
            jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
        }

    }
}
