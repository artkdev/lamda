using Amazon.Lambda.Core;
using Entities;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace RegistrationLambda;

public class Lambda
{
    private readonly static string url = "https://fg.trafficvision.network/api/signup/procform";
    private static string username = string.Empty;
    private static string password = string.Empty;
    private static string apikey = "2643889w34df345676ssdas323tgc738";

    public static async Task<JsonObject?> FunctionHandler(InputEntity entity)
    {
        var client = new HttpClient();

        entity.Globalization ??= "en";
        entity.Globalization = entity.Globalization.ToLower();

        var json = ReadJsonTemplate(entity.Globalization);
        json["userip"] = entity.UserIp;
        json["firstname"] = entity.FirstName;
        json["lastname"] = entity.LastName;
        json["email"] = entity.Email;
        json["password"] = entity.Password;
        json["phone"] = entity.Phone;

        username = json["h_user"].ToString();
        password = json["h_password"].ToString();

        json.Remove("h_user");
        json.Remove("h_password");

        var content = new StringContent(json.ToJsonString(), Encoding.UTF8, "application/json");

        content.Headers.Add("x-trackbox-username", username);
        content.Headers.Add("x-trackbox-password", password);
        content.Headers.Add("x-api-key", apikey);

        var response = await client.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();

        return string.IsNullOrEmpty(responseString) ? new JsonObject() : JsonSerializer.Deserialize<JsonObject>(responseString);
    }

    public static JsonObject ReadJsonTemplate(string globalization)
    {
        string filename = $"template_{globalization}.json";

        if (!File.Exists(filename))
            throw new Exception("Not correct globalization argument");

        string text = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<JsonObject>(text);
    }
}
