using Backend.Core.Models;
using System.Text.Json;

namespace Backend.IntegrationTest;

public class BudgetTests : IClassFixture<WebApplicationFactory<Api.Program>>
{
    private readonly HttpClient _httpClient;
    public BudgetTests(WebApplicationFactory<Api.Program> factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }


    [Fact]
    public async Task CanGetListOfAllBudgets()
    {
        var response = await _httpClient.GetAsync("api/Budget");

        var responseString = await response.Content.ReadAsStringAsync();
        var budgetList = new List<Budget>();

        if (responseString is not null)
            budgetList = JsonSerializer.Deserialize<List<Budget>>(responseString);
        


        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
        Assert.True(response.Content.Headers.ContentLength > 0);
        Assert.True(budgetList.Count > 0);
        Assert.NotEmpty(budgetList);
    }
}
