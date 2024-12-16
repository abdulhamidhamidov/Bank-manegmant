using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class LoanService(IContext context): ILoanService
{
     public async Task<ApiResponse<List<Loan>>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from loans;";
        var res = (await connection.QueryAsync<Loan>(sql)).ToList();
        return new ApiResponse<List<Loan>>(res);
    }

    public async Task<ApiResponse<Loan>> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from loans where loanid=@Id;";
        var res = await connection.QuerySingleOrDefaultAsync<Loan>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Loan>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Loan>(res);
    }

    public async Task<ApiResponse<bool>> Add(Loan data)
    {
        using var connection = context.Connection();
        string sql = """
                     insert into loans( loanamount, dateissued, createdat, deletedat, customerid, branchid) values( @LoanAmount, @DateIssued, @CreatedAt, @DeletedAt, @CustomerId, @BranchId); 
                     
                     """;
        var res =await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Update(Loan data)
    {
        using var connection = context.Connection();
        string sql = """
                     update loans set loanamount=@LoanAmount, dateissued=@DateIssued, createdat=@CreatedAt, deletedat=@DeletedAt, customerid=@CustomerId, branchid=@BranchId where loanid=@Id;
                     
                     """;
        var res = await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from loans where loanid=@Id;";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<int>> CountLoan()
    {
        using var connection = context.Connection();
        string sql = "select Count(LoanAmount) from loans;";
        var res =await connection.ExecuteScalarAsync<int>(sql);
        return new ApiResponse<int>(res);
    }
}