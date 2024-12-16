using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ILoanService
{
    Task<ApiResponse<List<Loan>>> GetAll();
    Task<ApiResponse<Loan>> GetById(int id);
    Task<ApiResponse<bool>> Add(Loan data);
    Task<ApiResponse<bool>> Update(Loan data);
    Task<ApiResponse<bool>> Delete(int id);
    Task<ApiResponse<int>> CountLoan();
}