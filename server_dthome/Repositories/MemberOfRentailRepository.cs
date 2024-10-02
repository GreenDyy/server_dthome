using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.Repositories;
using server_dthome.ViewModels;

public class MemberOfRentalRepository : IMemberOfRentalRepository
{
    private readonly DthomeContext _context;
    private readonly IMapper _mapper;

    public MemberOfRentalRepository(DthomeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<MemberOfRentalVM> GetAll()
    {
        var members = _context.MemberOfRentals.ToList();
        return _mapper.Map<List<MemberOfRentalVM>>(members);
    }

    public MemberOfRentalVM GetById(int ownerId, int id)
    {
        var member = _context.MemberOfRentals.FirstOrDefault(m => m.OwnerId == ownerId && m.MemberOfRentalId == id);
        return _mapper.Map<MemberOfRentalVM>(member);
    }

    public List<MemberOfRentalVM> GetByIdRental(int ownerId, int idRental)
    {
        var members = _context.MemberOfRentals.Where(m => m.OwnerId == ownerId && m.RentalId == idRental).ToList();
        return _mapper.Map<List<MemberOfRentalVM>>(members);
    }

    public MemberOfRentalVM Create(MemberOfRentalModel memberOfRentalModel)
    {
        var member = _mapper.Map<MemberOfRental>(memberOfRentalModel);
        _context.MemberOfRentals.Add(member);
        _context.SaveChanges();
        return _mapper.Map<MemberOfRentalVM>(member);
    }

    public bool Update(int id, MemberOfRentalModel memberOfRentalModel)
    {
        var member = _context.MemberOfRentals.FirstOrDefault(m => m.MemberOfRentalId == id);
        if (member != null)
        {
            _mapper.Map(memberOfRentalModel, member);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public bool Delete(int id)
    {
        var member = _context.MemberOfRentals.FirstOrDefault(m => m.MemberOfRentalId == id);
        if (member != null)
        {
            _context.MemberOfRentals.Remove(member);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}
