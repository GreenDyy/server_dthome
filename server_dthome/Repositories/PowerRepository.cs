using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class PowerRepository : IPowerRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public PowerRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public PowerVM Create(PowerModel powerModel)
        {
            var power = _mapper.Map<Power>(powerModel);
            _context.Powers.Add(power);
            _context.SaveChanges();
            return _mapper.Map<PowerVM>(power);
        }

        public bool Delete(int id)
        {
            var power = _context.Powers.FirstOrDefault(p => p.PowerId == id);
            if (power != null)
            {
                _context.Powers.Remove(power);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<PowerVM> GetAll()
        {
            var powers = _context.Powers.ToList();
            var powerVMs = _mapper.Map<List<PowerVM>>(powers);
            return powerVMs;
        }

        public PowerVM GetById(int id)
        {
            var power = _context.Powers.FirstOrDefault(p => p.PowerId == id);
            return _mapper.Map<PowerVM>(power);
        }

        public bool Update(int id, PowerModel powerModel)
        {
            var power = _context.Powers.FirstOrDefault(p => p.PowerId == id);
            if (power != null)
            {
                _mapper.Map(powerModel, power);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PowerVM GetLatestPrice()
        {
            var latestPower = _context.Powers
                .OrderByDescending(p => p.EffectiveDate)
                .FirstOrDefault();
            return _mapper.Map<PowerVM>(latestPower);
        }
    }
}
