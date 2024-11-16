
using System.Net.Http;
using System.Net.Http.Json;

namespace AsyncAwaitTestProgramApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IMyAppProvider, MyAppProvider>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/callmymethod", async (HttpContext httpcontext, IMyAppProvider provider) =>
            {
                int count = 20;
                var results = new List<object?>();
                for (int i = 0; i < count; i++)
                {
                    results.Add(await provider.Get().Result.Content.ReadFromJsonAsync<object>());
                }
                return results;
            });

            app.MapGet("/callmymethodasync", (HttpContext httpcontext, IMyAppProvider provider) =>
            {
                int count = 20;
                var results = new List<Task<HttpResponseMessage>>();
                results.AddRange(Enumerable.Range(0, count).Select(i => provider.Get()));
                var tasks = results.ToArray();

                //Task.WaitAll(tasks);
                return tasks.Select(t => t.Result.Content.ReadFromJsonAsync<object>().GetAwaiter().GetResult());
            });

            app.MapGet("/GetWeatherForecast", async (IMyAppProvider provider) => {
                var task = provider.GetWeatherForecastAsync().Result;
                return ;
            
            });

            app.MapGet("/GetMultipleWeatherForecast", async (IMyAppProvider provider) => {
                var task1 = provider.GetWeatherForecastAsync();
                var task2 = provider.GetWeatherForecastAsync();
                var task3 = provider.GetWeatherForecastAsync();
                var task4 = provider.GetWeatherForecastAsync();
                var task5 = provider.GetWeatherForecastAsync();
                //var tt= await Task.WhenAll(task1,task2, task3, task4, task5);
                //Task.WaitAll(task1, task2, task3, task4, task5);

                return task1; 

            });

            app.Run();
        }
    }

    public interface IMyAppProvider
    {
        Task<HttpResponseMessage> Get();
        Task<HttpResponseMessage> GetWeatherForecastAsync();

    }

    public class MyAppProvider : IMyAppProvider
    {
        private readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7114")
        };

        public Task<HttpResponseMessage> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/WeatherForecast");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("MyHeader", "aaaaa");
            return _httpClient.SendAsync(request);
        }

        public  Task<HttpResponseMessage> GetWeatherForecastAsync()
        {
            //Task.Delay(10000);
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7114")
            };

            var response =  httpClient.GetAsync("/api/WeatherForecast");
            Console.WriteLine("dddd");
            return  response;
        }
    }
}
