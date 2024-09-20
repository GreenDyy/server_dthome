using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IWaterRepository
    {
        // Lấy tất cả
        public List<WaterVM> GetAll();
        // Lấy 1
        public WaterVM GetById(int id);
        // Thêm
        public WaterVM Create(WaterModel waterModel);
        // Xóa
        public bool Delete(int id);
        // Sửa
        public bool Update(int id, WaterModel waterModel);
        // Lấy giá mới nhất
        public WaterVM GetLatestPrice();
    }
}
