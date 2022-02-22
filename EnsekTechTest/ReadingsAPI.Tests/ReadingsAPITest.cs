using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace ReadingsAPI.Tests
{
    public class ReadingsAPITest
    {
        [Fact]
        public async Task GetAccounts()
        {
            await using var application = new ReadingsApplication();

            var client = application.CreateClient();
            var accounts = await client.GetFromJsonAsync<List<Account>>("/accounts");

            Assert.Empty(accounts);
        }

        [Fact]
        public async Task PostAccount()
        {
            await using var application = new ReadingsApplication();

            var client = application.CreateClient();
            var response = await client.PostAsJsonAsync("/accounts", new Account { AccountId = 9988, FirstName = "Harry", LastName = "Test" });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var accounts = await client.GetFromJsonAsync<List<Account>>("/accounts");

            var account = Assert.Single(accounts);
            Assert.Equal(9988, account.AccountId);
        }

        [Fact]
        public async Task GetReadings()
        {
            await using var application = new ReadingsApplication();

            var client = application.CreateClient();
            var readings = await client.GetFromJsonAsync<List<MeterReading>>("/readings");

            Assert.Empty(readings);
        }
    }

    class ReadingsApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<ReadingsDbContext>));

                services.AddDbContext<ReadingsDbContext>(options =>
                    options.UseInMemoryDatabase("Testing", root));
            });

            return base.CreateHost(builder);
        }
    }
}