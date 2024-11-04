using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TrialLogicAppSourceAPI
{
    public class GetItems
    {
        private readonly ILogger<GetItems> _logger;

        public GetItems(ILogger<GetItems> logger)
        {
            _logger = logger;
        }

        [Function("GetItems")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var items = new List<Item>
            {
                new() { ID = 1, Resolution = "1080p", Price = 299.99m },
                new() { ID = 2, Resolution = "4K", Price = 599.99m },
                new() { ID = 3, Resolution = "8K", Price = 999.99m }
            };

            return new OkObjectResult(items);
        }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Resolution { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}