using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class OwnerBuildingRepository : IOwnerBuildingRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public OwnerBuildingRepository(DthomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OwnerBuildingVM> GetAll()
        {
            var owners = _context.OwnerBuildings.ToList();
            return _mapper.Map<List<OwnerBuildingVM>>(owners);
        }

        public OwnerBuildingVM GetById(int id)
        {
            var owner = _context.OwnerBuildings.FirstOrDefault(o => o.OwnerId == id);
            return _mapper.Map<OwnerBuildingVM>(owner);
        }

        public OwnerBuildingVM Create(OwnerBuildingModel ownerModel)
        {
            var owner = _mapper.Map<OwnerBuilding>(ownerModel);
            _context.OwnerBuildings.Add(owner);
            _context.SaveChanges();
            return _mapper.Map<OwnerBuildingVM>(owner);
        }

        public bool Update(int id, OwnerBuildingModel ownerModel)
        {
            var owner = _context.OwnerBuildings.FirstOrDefault(o => o.OwnerId == id);
            if (owner != null)
            {
                _mapper.Map(ownerModel, owner);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var owner = _context.OwnerBuildings.FirstOrDefault(o => o.OwnerId == id);
            if (owner != null)
            {
                _context.OwnerBuildings.Remove(owner);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
