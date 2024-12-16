using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class AccountService(IContext context): IAccountService
{
     public ApiResponse<List<Account>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from accounts;";
        var res = connection.Query<Account>(sql).AsQueryable().ToList();
        return new ApiResponse<List<Account>>(res);
    }

    public ApiResponse<Account> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from accounts where accountid=@Id;";
        var res = connection.QuerySingleOrDefault<Account>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Account>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Account>(res);
    }

    public ApiResponse<bool> Add(Account data)
    {
        using var connection = context.Connection();
        string sql = """
                     insert into accounts( balance, accountstatus, accounttype, currency, createdat, deletedat) values ( @Balance, @AccountStatus, @AccountType, @Currency,@CreatedAt, @DeletedAt);
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Update(Account data)
    {
        using var connection = context.Connection();
        string sql = """
                     update accounts set balance=@Balance, accountstatus=@AccountStatus, accounttype=@AccountType, currency=@Currency,createdat=@CreatedAt, deletedat=@DeletedAt where accountid=@Id;
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from accounts where accountid=@Id;";
        var res = connection.Execute(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }
    public ApiResponse<decimal> GetSumOfAllBalance()
    {
        using var connection=context.Connection();
        var sql = "select sum(balance) from accounts";
        var res = connection.ExecuteScalar<decimal>(sql);
        return new ApiResponse<decimal>(res);
    }
}