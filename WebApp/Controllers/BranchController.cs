using Domain.Entities;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class BranchController(IBranchService branchService): ControllerBase
{
    [HttpGet]
    public ApiResponse<List<Branch>> GetAll()
    {
        return branchService.GetAll();
    }
    [HttpGet("{id:int}")]
    public ApiResponse<Branch> GetById(int id)
    {
        return branchService.GetById(id);
    }
    [HttpPost]
    public ApiResponse<bool> Add(Branch branch)
    {
        return branchService.Add(branch);
    }
    [HttpPut]
    public ApiResponse<bool> Update(Branch branch)
    {
        return branchService.Update(branch);
    }
    [HttpDelete]
    public ApiResponse<bool> Delete(int id)
    {
        return branchService.Delete(id);
    }

    [HttpGet("Get-All-BranchName")]
    public ApiResponse<List<string>> GetAllBranchName()
    {
        return branchService.GetAllBranchName();
    }
}