﻿using Domain.Entities;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class BranchController(IBranchService branchService): ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Branch>>> GetAll()
    {
        return await branchService.GetAll();
    }
    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Branch>> GetById(int id)

    {
        return await branchService.GetById(id);
    }
    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Branch branch)
    {
        return await branchService.Add(branch);
    }
    [HttpPut]
    public async Task<ApiResponse<bool>> Update(Branch branch)
    {
        return await branchService.Update(branch);
    }
    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await branchService.Delete(id);
    }

    [HttpGet("Get-All-BranchName")]
    public async Task<ApiResponse<List<string>>> GetAllBranchName()
    {
        return await branchService.GetAllBranchName();
    }
}