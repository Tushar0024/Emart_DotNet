using Emart_final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Customerfolder
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> SaveCustomer(Customer c)
        {
            context.Customer.Add(c);
            await context.SaveChangesAsync();
            return c;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await context.Customer.ToListAsync();
            return customers;
        }

        public async Task DeleteCustomer(int cid)
        {
            var customerToDelete = await context.Customer.FindAsync(cid);
            if (customerToDelete != null)
            {
                context.Customer.Remove(customerToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Customer> Update(Customer c, int cid)
        {
            if (cid != c.custId)
            {
                return null;
            }

            context.Entry(c).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(cid))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return c;
        }

        public async Task<Customer> GetCustomerById(int cid)
        {
            var customer = await context.Customer.FindAsync(cid);
            return customer;
        }

        public async Task<Customer?> GetCustomerByEmail(string email)
        {
            var customer = await context.Customer.FirstOrDefaultAsync(c => c.custEmail == email);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetPrimeCustomers()
        {
            var primeCustomers = await context.Customer.Where(c => c.cardHolder == true).ToListAsync();
            return primeCustomers;
        }

        public async Task<int> CheckCust(string e, string p)
        {
            var customer = await context.Customer.FirstOrDefaultAsync(c => c.custEmail == e && c.custPassword == p);
            return customer != null ? customer.custId : -1;
        }

        public async Task<bool> CheckCardHolder(int id)
        {
            var customer = await context.Customer.FindAsync(id);
            return customer != null && customer.cardHolder;
        }

        public async Task<int> GetPointsByID(int id)
        {
            var customer = await context.Customer.FindAsync(id);
            return customer != null ? customer.points : -1;
        }

        private bool CustomerExists(int id)
        {
            return context.Customer.Any(e => e.custId == id);
        }
    }
}
