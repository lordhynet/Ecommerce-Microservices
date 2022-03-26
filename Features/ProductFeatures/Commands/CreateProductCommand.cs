using MediatR;
using Product.Microservice.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Microservice.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationContext _context;

            public CreateProductHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Model.Product();
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.Id;
            }
        }

    }
}
