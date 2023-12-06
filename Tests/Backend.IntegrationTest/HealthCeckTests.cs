namespace Backend.IntegrationTest;

public class HealthCeckTests : IClassFixture<WebApplicationFactory<Api.Program>>
{
    private readonly HttpClient _httpClient;
    public HealthCeckTests(WebApplicationFactory<Api.Program> factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task HealthCheckReturnsHealthyAsync()
    {
        var response = await _httpClient.GetAsync("api/healthcheck");

        response.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}