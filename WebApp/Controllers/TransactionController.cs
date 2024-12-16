using Domain.Entities;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class TransactionController(ITransactionService transactionService): ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Transaction>>> GetAll()
    {
        return await transactionService.GetAll();
    }
    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Transaction>> GetById(int id)
    {
        return await transactionService.GetById(id);
    }
    [HttpPost]
    public async Task<ApiResponse<bool>> Add(Transaction transaction)
    {
        return await transactionService.Add(transaction);
    }
    [HttpPut]
    public async Task<ApiResponse<bool>> Update(Transaction transaction)
    {
        return await transactionService.Update(transaction);
    }
    [HttpDelete]
    public async Task<ApiResponse<bool>> Delete(int id)
    {
        return await transactionService.Delete(id);
    }
    [HttpGet("Max-amount")]
    public async Task<ApiResponse<decimal>> MaxAmount()
    {
        return await transactionService.MaxAmount();
    }
}