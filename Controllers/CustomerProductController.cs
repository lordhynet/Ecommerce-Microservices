using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModel.Model;
using System;
using System.Threading.Tasks;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IBus _busService;

        public CustomerProductController(IBus busService)
        {
            _busService = busService;
        }
        [HttpPost]
        public async Task<string> CreateProduct(CustomerProduct product)
        {
            if (product != null)
            {
                product.AddedOnDate = System.DateTime.Now;
                Uri uri = new Uri("rabbitmq://localhost/productQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(product);
                return "true";
            }
            return "false";
        }
    }
}
