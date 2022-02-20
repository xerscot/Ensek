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

namespace Samples.Tests
{
    public class ReadingsTest
    {
        [Fact]
        public async Task GetAccounts()
        {
            await using var application = new ReadingsApplication();

            var client = application.CreateClient();
            var accounts = await client.GetFromJsonAsync<List<Account>>("/accounts");

            Assert.Empty(accounts);
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