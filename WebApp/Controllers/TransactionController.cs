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
    public ApiResponse<List<Transaction>> GetAll()
    {
        return transactionService.GetAll();
    }
    [HttpGet("{id:int}")]
    public ApiResponse<Transaction> GetById(int id)
    {
        return transactionService.GetById(id);
    }
    [HttpPost]
    public ApiResponse<bool> Add(Transaction transaction)
    {
        return transactionService.Add(transaction);
    }
    [HttpPut]
    public ApiResponse<bool> Update(Transaction transaction)
    {
        return transactionService.Update(transaction);
    }
    [HttpDelete]
    public ApiResponse<bool> Delete(int id)
    {
        return transactionService.Delete(id);
    }
    [HttpGet("Max-amount")]
    public ApiResponse<decimal> MaxAmount()
    {
        return transactionService.MaxAmount();
    }
}