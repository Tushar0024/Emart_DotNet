using Emart_final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Customerfolder
{
    public interface ICustomerRepository
    {
        Task<Customer> SaveCustomer(Customer c);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task DeleteCustomer(int cid);
        Task<Customer> Update(Customer c, int cid);
        Task<Customer> GetCustomerById(int cid);
        Task<Customer?> GetCustomerByEmail(string email);
        Task<IEnumerable<Customer>> GetPrimeCustomers();
        Task<int> CheckCust(string e, string p);
        Task<bool> CheckCardHolder(int id);
        Task<int> GetPointsByID(int id);
    }
}
