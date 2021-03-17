using System.Linq;
using System.Threading.Tasks;
using HoldPrint_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HoldPrint_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        public async Task<Customer[]> GetAllCustomersAsync()
        {
            IQueryable<Customer> query = _context.Customers;

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Customer> GetCustomerAsyncById(int customerId)
        {
            IQueryable<Customer> query = _context.Customers;

            query = query.AsNoTracking()
                         .OrderBy(customer => customer.Id)
                         .Where(customer => customer.Id == customerId);

            return await query.FirstOrDefaultAsync();
        }
    }
}