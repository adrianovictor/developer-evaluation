namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleItemCommand
{
    public string ProductId { get; private set; } = string.Empty;
    public string ProductName { get; private set; } = string.Empty;
    public int Quantity { get; private set; } = 0;
    public decimal UnitPrice { get; private set; } = 0.0m;
    public decimal Discount { get; private set; } = 0.0m; 
    public decimal TotalAmount { get; private set; } = 0.0m;
    public bool Cancelled { get; private set; } = false;

    public CreateSaleItemCommand(string productId, string productName, int quantity, decimal unitPrice, decimal discount, decimal totalAmount, bool cancelled)
    {
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        TotalAmount = totalAmount;
        Cancelled = cancelled;
    }
}
