using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface IAccountService
{
    ApiResponse<List<Account>> GetAll();
    ApiResponse<Account> GetById(int id);
    ApiResponse<bool> Add(Account data);
    ApiResponse<bool> Update(Account data);
    ApiResponse<bool> Delete(int id);
    ApiResponse<decimal> GetSumOfAllBalance();
}