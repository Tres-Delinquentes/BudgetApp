using Backend.Api.DAL;
using Backend.Core.Models;
using Microsoft.AspNetCore.Http.Features;
using System.Text;
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

    [Fact]
    public async Task CanRecievePostFromFE()
    {
        var budgetManager = new BudgetManager();
        var validBudget = budgetManager.SmallBudget;
        if (validBudget is not null)
        {
            validBudget.Title = "Test";
            var jsonString = JsonSerializer.Serialize(validBudget);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = await _httpClient.PostAsync("api/Budget", content);

            //Assert.True(request.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
        }
    }

    [Fact]
    public async Task CanRecieveBadRequestMessageWhenPostinnInvalidBudgetFromFE()
    {
        var budgetManager = new BudgetManager();
        var invalidBudget = budgetManager.SmallBudget;
        if (invalidBudget is not null)
        {
            invalidBudget.Income.Name = "%¤#%&/@£$€";
            var jsonString = JsonSerializer.Serialize(invalidBudget);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = await _httpClient.PostAsync("api/Budget", content);

            //Assert.False(request.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }
    }
}
