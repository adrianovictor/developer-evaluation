using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Guid SaleId { get; private set; }
    public string ProductId { get; private set; } = string.Empty;
    public string ProductName { get; private set; } = string.Empty;
    public int Quantity { get; private set; } = 0;
    public decimal UnitPrice { get; private set; } = 0.0m;
    public decimal Discount { get; private set; } = 0.0m; 
    public decimal TotalAmount { get; private set; } = 0.0m;
    public bool Cancelled { get; private set; } = false;

    protected SaleItem() { }

    public SaleItem(Guid saleId, string productId, string productName, int quantity, decimal unitPrice, decimal discount, decimal totalAmount, bool cancelled)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = ProductName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        TotalAmount = totalAmount;
        Cancelled = cancelled;
    }

    public static SaleItem Create(Guid saleId, string productId, string productName, int quantity, decimal unitPrice, decimal discount, decimal totalAmount, bool cancelled)
        => new(saleId, productId, productName, quantity, unitPrice, discount, totalAmount, cancelled);

    public void Cancel()
    {
        Cancelled = true;
    }        
}
