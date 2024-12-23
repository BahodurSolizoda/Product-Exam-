using System.Net;
using Dapper;
using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class ProductService(DapperContext context):IGenericService<Product>
{
    public async Task<Response<List<Product>>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from Products";
        var result=await connection.QueryAsync<Product>(sql);
        return new Response<List<Product>>(result.ToList());
    }

    public async Task<Response<Product>> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from Products where productId = @Id";
        var result=await connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        if (result == null) return new Response<Product>(HttpStatusCode.NotFound,"Product not found");
        return  new Response<Product>(result);
    }

    public async Task<Response<bool>> Add(Product data)
    {
        using var connection = context.Connection();
        string sql = "insert into Products (productName, description, price,stockQuantity, categoryName, createdDate) values (@productName, @description, @price, @stockQuantity, @categoryName, @createdDate)";
        var result =await connection.ExecuteAsync(sql, data);
        if (result==0) return  new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error");
        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Update(Product data)
    {
        using var connection = context.Connection();
        string sql="update Products productName=@productName, description=@description, price=@price,stockQuantity=@stockQuantity, categoryName=@categoryName, createdDate=@createdDate";
        var result =await connection.ExecuteAsync(sql, data);
        if (result==0) return  new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error");
        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from Products where productId = @id";
        var result =await connection.ExecuteAsync(sql, new { Id = id });
        if (result==0) return  new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error");
        return new Response<bool>(true);
    }

    public async Task<Response<string>> ExportProductsToFile()
    {
        var products=await ProductService.ExportProductsToFile();
        if(products.Data==null) return new Response<string>(HttpStatusCode.InternalServerError,"Product not found");
        
    }

    public Task<Response<string>> ImportProductsFromFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateProductsFromFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> AnalyzeProductsAndSaveToFile()
    {
        throw new NotImplementedException();
    }
}





