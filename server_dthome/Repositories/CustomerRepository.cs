using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public CustomerVM Create(CustomerModel cusModel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerVM> GetAll()
        {
            var customer = _context.Customers.ToList();
            var customerVMs = _mapper.Map<List<CustomerVM>>(customer);
            return customerVMs;
        }

        public CustomerVM GetById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            var customerVM = _mapper.Map<CustomerVM>(customer);
            return customerVM;
        }

        public bool Update(int id, CustomerModel cusModel)
        {
            throw new NotImplementedException();
        }
    }
}
