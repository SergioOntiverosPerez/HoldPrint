using System.Threading.Tasks;
using HoldPrint_WebAPI.Models;

namespace HoldPrint_WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Customer
        Task<Customer[]> GetAllCustomersAsync();        
        Task<Customer> GetCustomerAsyncById(int customerId);
    }
}