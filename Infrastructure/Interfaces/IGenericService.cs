using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IGenericService<T>
{
    Task<Response<List<T>>> GetAll();
    Task<Response<T>> GetById(int id);
    Task<Response<bool>> Add(T data);
    Task<Response<bool>> Update(T data);
    Task<Response<bool>> Delete(int id);
    
    Task<Response<string>> ExportProductsToFile();
    Task<Response<string>> ImportProductsFromFile(string filePath);
    Task<Response<string>> UpdateProductsFromFile(string filePath);
    Task<Response<string>> AnalyzeProductsAndSaveToFile();
}