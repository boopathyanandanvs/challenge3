using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        string fileContent = File.ReadAllText("D:\\payload.json");

        dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(fileContent);

        string input = "d/e/f";

        RetrieveValue(jsonObject, input);
    }

    public static void RetrieveValue(dynamic obj, string input, string parentKey = "")
    {
        foreach (var property in obj)
        {
            string key = parentKey + (string.IsNullOrEmpty(parentKey) ? "" : "/") + property.Name;
            if (property.Value is JObject)
            {
                RetrieveValue(property.Value, input, key);
            }
            else
            {
                if (key.Equals(input))
                {

                    Console.WriteLine($"{key}: {property.Value}");

                }
            }
        }
    }
}
