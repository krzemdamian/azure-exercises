using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Az204Auth;

public static class Program 
{
    private const string _clientId = "3f90d348-13b9-4515-b513-3d954d317e93";
    private const string _tenantId = "10780dc9-1ed2-41a5-964e-c45e0c4ad1cc";

    public static async Task Main(string[] args)
    {
        var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

        string[] scopes = { "user.read" };

        AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

        Console.WriteLine($"Token:\t{result.AccessToken}");
    }
}
