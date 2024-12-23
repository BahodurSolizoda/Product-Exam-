using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController(IGenericService<Product> productService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAll()
    {
        return await productService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Response<Product>> GetById(int id)
    {
        return await productService.GetById(id);
    }

    [HttpPost]
    public async Task<Response<bool>> Add([FromBody]Product product)
    {
        return await productService.Add(product);
    }


    [HttpPut]
    public async Task<Response<bool>> Update([FromBody] Product product)
    {
        return await productService.Update(product);
    }


    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await productService.Delete(id);
    }
}