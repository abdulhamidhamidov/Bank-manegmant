using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class TransactionService(IContext context) : ITransactionService
{
     public async Task<ApiResponse<List<Transaction>>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "SELECT * FROM transactions;";
        var res = (await connection.QueryAsync<Transaction>(sql)).ToList();
        return new ApiResponse<List<Transaction>>(res);
    }

    public async Task<ApiResponse<Transaction>> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "SELECT * FROM transactions WHERE transactionid = @Id;";
        var res = await connection.QuerySingleOrDefaultAsync<Transaction>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Transaction>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Transaction>(res);
    }

    public async Task<ApiResponse<bool>> Add(Transaction data)
    {
        using var connection = context.Connection();
        string sql = """
                     INSERT INTO transactions (transactionstatus, dateissued, amount, createdat, deletedat, fromaccountid, toaccountid) VALUES (@TransactionStatus, @DateIssued, @Amount, @Createdat, @DeletedAt, @FromaccountId, @ToaccountId);
                     
                     """;
        var res =await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async  Task<ApiResponse<bool>> Update(Transaction data)
    {
        using var connection = context.Connection();
        string sql = """
                     UPDATE transactions SET transactionstatus = @TransactionStatus,dateissued = @DateIssued,amount = @Amount,createdat = @Createdat,deletedat = @DeletedAt,fromaccountid = @FromaccountId,toaccountid = @ToaccountId WHERE transactionid = @Id;                
                     """;
        var res =await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "DELETE FROM transactions WHERE transactionid = @Id;\n";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }
    public async Task<ApiResponse<decimal>> MaxAmount()
    {
        using var connection = context.Connection();
        string sql = "SELECT Max(amount) FROM transactions;";
        var res =await connection.ExecuteScalarAsync<decimal>(sql);
        return new ApiResponse<decimal>(res);
    }
}