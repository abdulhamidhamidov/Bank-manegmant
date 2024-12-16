using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ILoanService
{
    ApiResponse<List<Loan>> GetAll();
    ApiResponse<Loan> GetById(int id);
    ApiResponse<bool> Add(Loan data);
    ApiResponse<bool> Update(Loan data);
    ApiResponse<bool> Delete(int id);
    ApiResponse<int> CountLoan();
}