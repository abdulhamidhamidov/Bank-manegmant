using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface IBranchService
{
    Task<ApiResponse<List<Branch>>> GetAll();
    Task<ApiResponse<Branch>> GetById(int id);
    Task<ApiResponse<bool>> Add(Branch data);
    Task<ApiResponse<bool>> Update(Branch data);
    Task<ApiResponse<bool>> Delete(int id); 
    Task<ApiResponse<List<string>>> GetAllBranchName();
}