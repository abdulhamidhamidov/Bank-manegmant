using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface IAccountService
{
    Task<ApiResponse<List<Account>>> GetAll();
    Task<ApiResponse<Account>> GetById(int id);
   Task<ApiResponse<bool>> Add(Account data);
    Task<ApiResponse<bool>> Update(Account data);
    Task<ApiResponse<bool>> Delete(int id);
    Task<ApiResponse<decimal>> GetSumOfAllBalance();
}