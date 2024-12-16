using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class BranchService(IContext context): IBranchService
{
     public async Task<ApiResponse<List<Branch>>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from branches;";
        var res =(await connection.QueryAsync<Branch>(sql)).ToList();
        return new ApiResponse<List<Branch>>(res);
    }

    public async Task<ApiResponse<Branch>> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from branches where branchid=@Id;";
        var res =await connection.QuerySingleOrDefaultAsync<Branch>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Branch>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Branch>(res);
    }

    public async Task<ApiResponse<bool>> Add(Branch data)
    {
        using var connection = context.Connection();
        string sql = """
                     insert into branches( branchname, branchlocation, createdat, deletedat) values ( @Branchname, @BranchLocation, @CreatedAt, @DeletedAt);
                     
                     """;
        var res =await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Update(Branch data)
    {
        using var connection = context.Connection();
        string sql = """
                     update branches set branchname=@Branchname, branchlocation=@BranchLocation, createdat=@CreatedAt, deletedat=@DeletedAt where branchid=@Id;
                     
                     """;
        var res =await connection.ExecuteAsync(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from branches where branchid=@Id;";
        var res =await connection.ExecuteAsync(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }

    public async Task<ApiResponse<List<string>>> GetAllBranchName()
    {
        using var connection = context.Connection();
        string sql = "select branchname from branches";
        var res =(await connection.QueryAsync<string>(sql)).ToList();
        return new ApiResponse<List<string>>(res);
    }
}