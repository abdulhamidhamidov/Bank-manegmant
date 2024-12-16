using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface IBranchService
{
    ApiResponse<List<Branch>> GetAll();
    ApiResponse<Branch> GetById(int id);
    ApiResponse<bool> Add(Branch data);
    ApiResponse<bool> Update(Branch data);
    ApiResponse<bool> Delete(int id);
    public ApiResponse<List<string>> GetAllBranchName();
}