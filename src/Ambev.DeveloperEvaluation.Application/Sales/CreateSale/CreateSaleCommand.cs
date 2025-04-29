using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string BranchId { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public bool Cancelled { get; set; }
    public List<SaleItem> SaleItems { get; set; }


    public CreateSaleCommand(string saleNumber, DateTime saleDate, string customerId, string branchId, string branchName, decimal totalAmount, bool cancelled, List<SaleItem> saleItems)
    {
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        BranchId = branchId;
        BranchName = branchName;
        TotalAmount = totalAmount;
        Cancelled = cancelled;
        SaleItems = saleItems;
    }
}
