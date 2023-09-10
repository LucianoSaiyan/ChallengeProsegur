using ChallengeProsegurClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44330/api/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

string? origins = "origins";

builder.Services.AddAuthorizationCore(async sp => 
            sp.AddPolicy(origins,
               await GetDefaultPolicyAsync()));

await builder.Build().RunAsync();

Task<AuthorizationPolicy> GetDefaultPolicyAsync()
{
    return Task.FromResult(new AuthorizationPolicy(
        Enumerable.Empty<IAuthorizationRequirement>(),
        Enumerable.Empty<string>()));
}

