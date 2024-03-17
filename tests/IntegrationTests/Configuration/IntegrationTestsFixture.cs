using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication;

namespace IntegrationTests.Configuration;

[CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
public class IntegrationTestsFixtureCollection: ICollectionFixture<IntegrationTestsFixture<Program>>;

public class IntegrationTestsFixture<TProgram> : IDisposable where TProgram : class
{
    private readonly WebAppFactory<TProgram> Factory;
    public readonly HttpClient Client;
    
    public IntegrationTestsFixture()
    {
        var clientOptions = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = true,
            HandleCookies = true,
            MaxAutomaticRedirections = 10,
            BaseAddress = new Uri("http://localhost")
        };
        
        Factory = new WebAppFactory<TProgram>();
        Client = Factory.CreateClient(clientOptions);
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}