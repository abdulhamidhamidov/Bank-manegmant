using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ICustomerService
{
    Task<ApiResponse<List<Customer>>> GetAll();
    Task<ApiResponse<Customer>> GetById(int id);
    Task<ApiResponse<bool>> Add(Customer data);
    Task<ApiResponse<bool>> Update(Customer data);
    Task<ApiResponse<bool>> Delete(int id);
    Task<ApiResponse<List<Customer>>> GetByCity(string city);
}