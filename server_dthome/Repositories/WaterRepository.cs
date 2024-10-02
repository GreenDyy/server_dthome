using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class WaterRepository : IWaterRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public WaterRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public WaterVM Create(WaterModel waterModel)
        {
            var water = _mapper.Map<Water>(waterModel);
            _context.Water.Add(water);
            _context.SaveChanges();
            return _mapper.Map<WaterVM>(water);
        }

        public bool Delete(int id)
        {
            var water = _context.Water.FirstOrDefault(w => w.WaterId == id);
            if (water != null)
            {
                _context.Water.Remove(water);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<WaterVM> GetAll()
        {
            var waters = _context.Water.ToList();
            var waterVMs = _mapper.Map<List<WaterVM>>(waters);
            return waterVMs;
        }

        public WaterVM GetById(int id)
        {
            var water = _context.Water.FirstOrDefault(w => w.WaterId == id);
            return _mapper.Map<WaterVM>(water);
        }

        public bool Update(int id, WaterModel waterModel)
        {
            var water = _context.Water.FirstOrDefault(w => w.WaterId == id);
            if (water != null)
            {
                _mapper.Map(waterModel, water);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public WaterVM GetLatestPrice(int ownerId)
        {
            var latestWater = _context.Water
                .OrderByDescending(w => w.EffectiveDate)
                .FirstOrDefault(w => w.OwnerId == ownerId);
            return _mapper.Map<WaterVM>(latestWater);
        }
    }
}
