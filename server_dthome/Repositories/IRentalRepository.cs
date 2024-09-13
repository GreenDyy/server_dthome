using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IRentalRepository
    {
        //lấy all
        public List<RentalVM> GetAll();
        //lấy 1
        public RentalVM GetById(int id);
        public RentalVM GetByIdRoomAndIsRenting(int idRoom, bool isRenting);
        //thêm
        public RentalVM Create(RentalModel rentalModel);
        //xoá
        public bool Delete(int id);
        //sửa
        public bool Update(int id, RentalModel rentalModel);
    }
}
