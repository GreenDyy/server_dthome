using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface ITrashRepository
    {
        // Lấy tất cả
        public List<TrashVM> GetAll();
        // Lấy 1
        public TrashVM GetById(int id);
        // Thêm
        public TrashVM Create(TrashModel trashModel);
        // Xóa
        public bool Delete(int id);
        // Sửa
        public bool Update(int id, TrashModel trashModel);
        // Lấy giá mới nhất
        public TrashVM GetLatestPrice(int ownerId);
    }
}
