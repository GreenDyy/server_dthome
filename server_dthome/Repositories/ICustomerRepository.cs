using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface ICustomerRepository
    {
        //lấy all
        public List<CustomerVM> GetAll();
        public List<CustomerVM> GetAll(int ownerId);
        //lấy 1
        public CustomerVM GetById(int id);
        public CustomerVM GetById(int ownerId, int id);
        //thêm
        public CustomerVM Create(CustomerModel cusModel);
        //xoá
        public bool Delete(int id);
        //sửa
        public bool Update(int id, CustomerModel cusModel);
    }
}
