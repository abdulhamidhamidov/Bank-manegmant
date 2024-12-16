using Domain.Entities;
using Infratructure.Responses;
using Infratructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class LoanController(ILoanService loanService): ControllerBase
{
    [HttpGet]
    public ApiResponse<List<Loan>> GetAll()
    {
        return loanService.GetAll();
    }
    [HttpGet("{id:int}")]
    public ApiResponse<Loan> GetById(int id)
    {
        return loanService.GetById(id);
    }
    [HttpPost]
    public ApiResponse<bool> Add(Loan loan)
    {
        return loanService.Add(loan);
    }
    [HttpPut]
    public ApiResponse<bool> Update(Loan loan)
    {
        return loanService.Update(loan);
    }
    [HttpDelete]
    public ApiResponse<bool> Delete(int id)
    {
        return loanService.Delete(id);
    }
    [HttpGet("Count-Loan")]
    public ApiResponse<int> CountLoan()
    {
        return loanService.CountLoan();
    }

}