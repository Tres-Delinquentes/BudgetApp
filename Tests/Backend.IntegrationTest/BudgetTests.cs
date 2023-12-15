using Backend.Api.DAL;
using Backend.Core.Interfaces;
using Backend.Core.Models;
using Microsoft.AspNetCore.Http.Features;
using System.Text;
using System.Text.Json;

namespace Backend.IntegrationTest;

public class BudgetTests : IClassFixture<WebApplicationFactory<Api.Program>>
{
    private readonly HttpClient _httpClient;
    private readonly IBudgetManager _sut;
    public BudgetTests(WebApplicationFactory<Api.Program> factory)
    {
        IItemManager itemManager = new ItemManager();
        ICategoryManager categoryManager = new CategoryManager();
        _httpClient = factory.CreateDefaultClient();
        _sut = new BudgetManager(categoryManager, itemManager);
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
        var validBudget = _sut.SmallBudget;
        if (validBudget is not null)
        {
            validBudget.Title = "Test";
            var jsonString = JsonSerializer.Serialize(validBudget);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = await _httpClient.PostAsync("/api/Budget/generate-pdf", content);

            //Assert.True(request.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, request.StatusCode);
        }
    }

    [Fact]
    public async Task CanRecieveBadRequestMessageWhenPostingInvalidBudgetFromFE()
    {
        var invalidBudget = _sut.SmallBudget;
        if (invalidBudget is not null)
        {
            invalidBudget.Income.Name = "%¤#%&/@£$€";
            var jsonString = JsonSerializer.Serialize(invalidBudget);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var request = await _httpClient.PostAsync("/api/Budget/generate-pdf", content);

            //Assert.False(request.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }
    }
}
