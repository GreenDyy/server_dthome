using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IPowerRepository
    {
        // Lấy tất cả
        public List<PowerVM> GetAll();
        // Lấy 1
        public PowerVM GetById(int id);
        // Thêm
        public PowerVM Create(PowerModel powerModel);
        // Xóa
        public bool Delete(int id);
        // Sửa
        public bool Update(int id, PowerModel powerModel);
        // Lấy giá mới nhất
        public PowerVM GetLatestPrice(int ownerId);
    }
}
