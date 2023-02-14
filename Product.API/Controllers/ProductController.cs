using Application.DTOs.Product;
using Application.Features.Products.Requests.Commands;
using Application.Features.Products.Requests.Queries;
using Application.Interfaces;
using Application.Responses;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        //private IApplicationDBContext _context;

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] ProductDto product)
        {
            var command = new CreateProductCommand { productDto = product };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _mediator.Send(new GetProductListRequest() { });//autre methode injection dependance
            return Ok(products);
        }

        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
           // var product = await _mediator.Send(new GetProductRequest { Id = id });
           // return Ok(product);
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto product)
        {
            var command = new UpdateProductCommand { Id = id, productDto = product };
            await _mediator.Send(command);
            return NoContent();
        }



    }
}
