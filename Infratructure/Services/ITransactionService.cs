using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ITransactionService
{
    Task<ApiResponse<List<Transaction>>> GetAll();
    Task<ApiResponse<Transaction>> GetById(int id);
    Task<ApiResponse<bool>> Add(Transaction data);
    Task<ApiResponse<bool>> Update(Transaction data);
    Task<ApiResponse<bool>> Delete(int id);
    public Task<ApiResponse<decimal>> MaxAmount();

}

