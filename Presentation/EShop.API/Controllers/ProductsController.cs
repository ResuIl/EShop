using EShop.Application.Features.Commands.Products.AddProduct;
using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMediator mediator;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMediator mediator)
        {
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
            this.mediator = mediator;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest request)
        {
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        //[HttpGet("getall")]
        //public IActionResult GetAll([FromQuery] Pagination pagination)
        //{
        //    // baseurl/api/products?page=1&size=10
        //    try
        //    {
        //        //return Ok(productReadRepository.GetAll()); // without Pagination

        //        var products = productReadRepository.GetAll(tracking: false);
        //        var totalCount = products.Count();

        //        products = products.OrderBy(p => p.CreatedTime).Skip(pagination.Size * pagination.Page).Take(pagination.Size).ToList();

        //        return Ok(new { products, totalCount });
        //    }
        //    catch (Exception)
        //    {
        //        // logging
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddProductCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await mediator.Send(request);
                    return StatusCode((int)HttpStatusCode.Created);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }


        //[HttpPost("add")]
        //public async Task<IActionResult> Add([FromBody] AddProductViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Product product = new()
        //            {
        //                Id = Guid.NewGuid(),
        //                Name = model.Name,
        //                Description = model.Desc,
        //                Price = model.Price,
        //                Stock = model.Stock,
        //                CreatedTime = DateTime.Now,
        //            };

        //            var result = await productWriteRepository.AddAsync(product);
        //            if (result)
        //            {
        //                await productWriteRepository.SaveChangesAsync();
        //                return StatusCode((int)HttpStatusCode.Created);
        //            }
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception)
        //    {
        //        // logging
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}


        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    return Ok();
        //}
    }
}
