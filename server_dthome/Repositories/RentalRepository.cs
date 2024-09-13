using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        public readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public RentalRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public List<RentalVM> GetAll()
        {
            var rentals = _context.Rentals.ToList();
            return _mapper.Map<List<RentalVM>>(rentals);
        }

        public RentalVM GetById(int id)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalId == id);
            return _mapper.Map<RentalVM>(rental);
        }

        public RentalVM GetByIdRoomAndIsRenting(int idRoom, bool isRenting)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RoomId == idRoom && r.IsRenting == isRenting);
            return _mapper.Map<RentalVM>(rental);
        }

        public bool Update(int id, RentalModel rentalModel)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalId == id);
            if (rental != null)
            {
                _mapper.Map(rentalModel, rental);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.RentalId == id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public RentalVM Create(RentalModel rentalModel)
        {
            var rental = _mapper.Map<Rental>(rentalModel);
            _context.Rentals.Add(rental);
            _context.SaveChanges();
            return _mapper.Map<RentalVM>(rental);
        }
    }
}
