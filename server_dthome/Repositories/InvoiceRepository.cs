using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public InvoiceRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public InvoiceVM Create(InvoiceModel invoiceModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceModel);
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return _mapper.Map<InvoiceVM>(invoice);
        }

        public bool Delete(int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<InvoiceVM> GetAll()
        {
            var invoices = _context.Invoices.ToList();
            var invoiceVMs = _mapper.Map<List<InvoiceVM>>(invoices);
            return invoiceVMs;
        }

        public List<InvoiceVM> GetAll(int ownerId)
        {
            var invoices = _context.Invoices.Where(t => t.OwnerId == ownerId).ToList();
            var invoiceVMs = _mapper.Map<List<InvoiceVM>>(invoices);
            return invoiceVMs;
        }

        public InvoiceVM GetById(int ownerId, int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.OwnerId == ownerId && i.InvoiceId == id);
            return _mapper.Map<InvoiceVM>(invoice);
        }

        public bool Update(int id, InvoiceModel invoiceModel)
        {
            var invoice = _context.Invoices.FirstOrDefault(i => i.InvoiceId == id);
            if (invoice != null)
            {
                _mapper.Map(invoiceModel, invoice);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
