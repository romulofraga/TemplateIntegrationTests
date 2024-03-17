using IntegrationTests.Configuration;
using WebApplication;

namespace IntegrationTests;

[Collection(nameof(IntegrationTestsFixtureCollection))]
public class IntegrationTests(IntegrationTestsFixture<Program> testsFixture)
{
    [Fact]
    public async Task Get_WeatherForecast_ReturnsSuccessStatusCode()
    {
        // Arrange
        // Act
        var response = await testsFixture.Client.GetAsync("/weatherforecast");
        
        // Assert
        response.EnsureSuccessStatusCode();
    }
    
}