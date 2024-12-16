using Domain.Entities;
using Infratructure.Responses;

namespace Infratructure.Services;

public interface ICustomerService
{
    ApiResponse<List<Customer>> GetAll();
    ApiResponse<Customer> GetById(int id);
    ApiResponse<bool> Add(Customer data);
    ApiResponse<bool> Update(Customer data);
    ApiResponse<bool> Delete(int id);
    public ApiResponse<List<Customer>> GetByCity(string city);
}