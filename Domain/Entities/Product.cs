namespace Domain.Entities;

public class Product
{
    public int ProducrId { get; set; }
    public string ProducrName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
}