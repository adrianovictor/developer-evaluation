using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale> GetByIdAsync(Guid id);
    Task<Sale> GetByNumberAsync(string number);
    Task<IEnumerable<Sale>> GetAllAsync();
    Task<IEnumerable<Sale>> GetByCustomerIdAsync(string customerId);
    Task<IEnumerable<Sale>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task AddAsync(Sale sale);
    Task UpdateAsync(Sale sale);
    Task<bool> ExistsAsync(Guid id);
}
