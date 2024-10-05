using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IOwnerAccountRepository
    {
        // Lấy tất cả tài khoản chủ sở hữu
        List<OwnerAccountVM> GetAll();

        // Lấy tài khoản theo ID
        OwnerAccountVM GetById(int id);

        // Thêm tài khoản mới
        OwnerAccountVM Create(OwnerAccountModel ownerAccountModel);

        // Xóa tài khoản
        bool Delete(int id);

        // Cập nhật tài khoản
        bool Update(int id, OwnerAccountModel ownerAccountModel);

        OwnerBuildingVM Login(LoginModel loginModel);

       
    }
}
