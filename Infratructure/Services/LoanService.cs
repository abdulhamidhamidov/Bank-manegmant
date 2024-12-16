using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class LoanService(IContext context): ILoanService
{
     public ApiResponse<List<Loan>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from loans;";
        var res = connection.Query<Loan>(sql).AsQueryable().ToList();
        return new ApiResponse<List<Loan>>(res);
    }

    public ApiResponse<Loan> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from loans where loanid=@Id;";
        var res = connection.QuerySingleOrDefault<Loan>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Loan>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Loan>(res);
    }

    public ApiResponse<bool> Add(Loan data)
    {
        using var connection = context.Connection();
        string sql = """
                     insert into loans( loanamount, dateissued, createdat, deletedat, customerid, branchid) values( @LoanAmount, @DateIssued, @CreatedAt, @DeletedAt, @CustomerId, @BranchId); 
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Update(Loan data)
    {
        using var connection = context.Connection();
        string sql = """
                     update loans set loanamount=@LoanAmount, dateissued=@DateIssued, createdat=@CreatedAt, deletedat=@DeletedAt, customerid=@CustomerId, branchid=@BranchId where loanid=@Id;
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from loans where loanid=@Id;";
        var res = connection.Execute(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }

    public ApiResponse<int> CountLoan()
    {
        using var connection = context.Connection();
        string sql = "select Count(LoanAmount) from loans;";
        var res = connection.ExecuteScalar<int>(sql);
        return new ApiResponse<int>(res);
    }
}