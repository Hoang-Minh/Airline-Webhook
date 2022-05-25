// See https://aka.ms/new-console-template for more information
using AirlineSendAgent.App;
using AirlineSendAgent.Client;
using AirlineSendAgent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()    
    .AddJsonFile("appsettings.json")
    .Build();

var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(configuration);
                })
                .ConfigureServices((context, services) => 
                {                   
                    services.AddDbContext<SendAgentDbContext>(opt => opt.UseSqlServer(context.Configuration.GetConnectionString("AirlineConnection")));
                    services.AddSingleton<IAppHost, AppHost>();
                    services.AddSingleton<IWebhookClient, WebhookClient>();
                    services.AddHttpClient();
                }).Build();


host.Services.GetService<IAppHost>()?.Run();
