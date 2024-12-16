using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ITransactionService
{
    ApiResponse<List<Transaction>> GetAll();
    ApiResponse<Transaction> GetById(int id);
    ApiResponse<bool> Add(Transaction data);
    ApiResponse<bool> Update(Transaction data);
    ApiResponse<bool> Delete(int id);
    public ApiResponse<decimal> MaxAmount();

}

