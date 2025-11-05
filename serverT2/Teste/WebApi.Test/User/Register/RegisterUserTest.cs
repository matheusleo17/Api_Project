using CommonTesteUtilities.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.User.Register
{
    public class RegisterUserTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public RegisterUserTest(WebApplicationFactory<Program> factory) 
        {
           _httpClient = factory.CreateClient();
        }
        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var response = await _httpClient.PostAsJsonAsync("User", request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            await using var reponseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(reponseBody);

            responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);
        }
    }
}
