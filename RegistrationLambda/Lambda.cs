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
    public static async Task<JsonObject?> FunctionHandler(InputEntity entity)
    {
        var client = new HttpClient();

        if (entity.Body == null)
            throw new ArgumentNullException("Body");

        var content = new StringContent(entity.Body.ToJsonString(), Encoding.UTF8, "application/json");

        content.Headers.Add("x-trackbox-username", entity.Username);
        content.Headers.Add("x-trackbox-password", entity.Password);
        content.Headers.Add("x-api-key", entity.ApiKey);

        var response = await client.PostAsync(entity.Url, content);
        var responseString = await response.Content.ReadAsStringAsync();

        return string.IsNullOrEmpty(responseString) ? new JsonObject() : JsonSerializer.Deserialize<JsonObject>(responseString);
    }
}
