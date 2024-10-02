using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IInvoiceRepository
    {
        // Lấy tất cả hóa đơn
        public List<InvoiceVM> GetAll();
        public List<InvoiceVM> GetAll(int ownerId);
        // Lấy hóa đơn theo ID
        public InvoiceVM GetById(int ownerId, int id);
        // Thêm hóa đơn mới
        public InvoiceVM Create(InvoiceModel invoiceModel);
        // Xóa hóa đơn theo ID
        public bool Delete(int id);
        // Cập nhật hóa đơn theo ID
        public bool Update(int id, InvoiceModel invoiceModel);
    }
}
