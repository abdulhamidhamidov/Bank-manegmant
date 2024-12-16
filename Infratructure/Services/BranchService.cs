using System.Net;
using Dapper;
using Domain.Entities;
using Infratructure.DataContext;
using Infratructure.Responses;

namespace Infratructure.Services;

public class BranchService(IContext context): IBranchService
{
     public ApiResponse<List<Branch>> GetAll()
    {
        using var connection = context.Connection();
        string sql = "select * from branches;";
        var res = connection.Query<Branch>(sql).AsQueryable().ToList();
        return new ApiResponse<List<Branch>>(res);
    }

    public ApiResponse<Branch> GetById(int id)
    {
        using var connection = context.Connection();
        string sql = "select * from branches where branchid=@Id;";
        var res = connection.QuerySingleOrDefault<Branch>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Branch>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<Branch>(res);
    }

    public ApiResponse<bool> Add(Branch data)
    {
        using var connection = context.Connection();
        string sql = """
                     insert into branches( branchname, branchlocation, createdat, deletedat) values ( @Branchname, @BranchLocation, @CreatedAt, @DeletedAt);
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Update(Branch data)
    {
        using var connection = context.Connection();
        string sql = """
                     update branches set branchname=@Branchname, branchlocation=@BranchLocation, createdat=@CreatedAt, deletedat=@DeletedAt where branchid=@Id;
                     
                     """;
        var res = connection.Execute(sql, data);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public ApiResponse<bool> Delete(int id)
    {
        using var connection = context.Connection();
        string sql = "delete from branches where branchid=@Id;";
        var res = connection.Execute(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Customer not found");
        return new ApiResponse<bool>(res != 0);
    }

    public ApiResponse<List<string>> GetAllBranchName()
    {
        using var connection = context.Connection();
        string sql = "select branchname from branches";
        var res = connection.Query<string>(sql).ToList();
        return new ApiResponse<List<string>>(res);
    }
}