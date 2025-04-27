using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public string SaleNumber { get; private set; } = string.Empty;
    public DateTime SaleDate { get; private set; }
    public string CustomerId { get; private set; } = string.Empty;
    public string CustomerName { get; private set; } = string.Empty;
    public string BranchId { get; private set; } = string.Empty;
    public string BranchName { get; private set; } = string.Empty;
    public decimal TotalAmount { get; private set; } = 0.0m;
    public bool Cancelled { get; private set; } = false;
    private readonly List<SaleItem> _items = [];
    public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

    protected Sale() { }

    public Sale(string saleNumber, DateTime saleDate, string customerId, string customerName, string branchId, string branchName, decimal totalAmount, bool cancelled)
    {
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        CustomerName = customerName;
        BranchId = branchId;
        BranchName = branchName;
        TotalAmount = totalAmount;
        Cancelled = cancelled;
    }

    public static Sale Create(string saleNumber, DateTime saleDate, string customerId, string customerName, string branchId, string branchName, decimal totalAmount, bool cancelled)
        => new(saleNumber, saleDate, customerId, customerName, branchId, branchName, totalAmount, cancelled);

    public void AddItem(string productId, string productName, int quantity, decimal unitPrice)
    {
        ValidateQuantity(quantity);
        
        var discount = CalculateDiscount(quantity, unitPrice);
        var totalItemAmount = (quantity * unitPrice) - discount;
        
        var saleItem = new SaleItem(Id, productId, productName, quantity, unitPrice, discount, totalItemAmount, false);
        _items.Add(saleItem);
        
        RecalculateTotalAmount();
    }

    public void RemoveItem(Guid itemId)
    {
        var item = _items.Find(i => i.Id == itemId) 
            ?? throw new ArgumentException($"Item with id {itemId} not found in sale {Id}");
        
        _items.Remove(item);
        RecalculateTotalAmount();
    }

    private void RecalculateTotalAmount()
    {
        TotalAmount = 0;
        foreach (var item in _items)
        {
            if (!item.Cancelled)
            {
                TotalAmount += item.TotalAmount;
            }
        }
    }

    private decimal CalculateDiscount(int quantity, decimal unitPrice)
    {
        return quantity switch
        {
            < 4 => 0,
            >= 4 and < 10 => unitPrice * quantity * 0.1m,  // 10% discount
            >= 10 and <= 20 => unitPrice * quantity * 0.2m, // 20% discount
            _ => throw new ArgumentException("Cannot sell more than 20 identical items")
        };
    }

    private void ValidateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero");
            
        if (quantity > 20)
            throw new ArgumentException("Cannot sell more than 20 identical items");
    }            
}
