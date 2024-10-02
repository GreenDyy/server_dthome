using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IOwnerBuildingRepository
    {
        // Lấy tất cả các chủ sở hữu
        List<OwnerBuildingVM> GetAll();

        // Lấy thông tin một chủ sở hữu theo ID
        OwnerBuildingVM GetById(int id);

        // Thêm một chủ sở hữu mới
        OwnerBuildingVM Create(OwnerBuildingModel ownerModel);

        // Cập nhật thông tin của một chủ sở hữu
        bool Update(int id, OwnerBuildingModel ownerModel);

        // Xóa một chủ sở hữu theo ID
        bool Delete(int id);
    }
}
