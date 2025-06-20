using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIPattern
{
    interface ICustomerRepository
    {
        string FindCustomerById(int id);
    }

    class CustomerRepositoryImpl : ICustomerRepository
    {
        public string FindCustomerById(int id) => $"Customer #{id} found";
    }

    class CustomerService
    {
        private ICustomerRepository repository;

        public CustomerService(ICustomerRepository repo) => repository = repo;

        public void GetCustomer(int id)
        {
            Console.WriteLine(repository.FindCustomerById(id));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repo = new CustomerRepositoryImpl();
            CustomerService service = new CustomerService(repo);
            service.GetCustomer(101);
        }
    }
}