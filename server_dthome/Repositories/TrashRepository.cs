using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class TrashRepository : ITrashRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;

        public TrashRepository(DthomeContext dthomeContext, IMapper mapper)
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public TrashVM Create(TrashModel trashModel)
        {
            var trash = _mapper.Map<Trash>(trashModel);
            _context.Trashes.Add(trash);
            _context.SaveChanges();
            return _mapper.Map<TrashVM>(trash);
        }

        public bool Delete(int id)
        {
            var trash = _context.Trashes.FirstOrDefault(t => t.TrashId == id);
            if (trash != null)
            {
                _context.Trashes.Remove(trash);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TrashVM> GetAll()
        {
            var trashes = _context.Trashes.ToList();
            var trashVMs = _mapper.Map<List<TrashVM>>(trashes);
            return trashVMs;
        }

        public TrashVM GetById(int id)
        {
            var trash = _context.Trashes.FirstOrDefault(t => t.TrashId == id);
            return _mapper.Map<TrashVM>(trash);
        }

        public bool Update(int id, TrashModel trashModel)
        {
            var trash = _context.Trashes.FirstOrDefault(t => t.TrashId == id);
            if (trash != null)
            {
                _mapper.Map(trashModel, trash);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public TrashVM GetLatestPrice()
        {
            var latestTrash = _context.Trashes
                .OrderByDescending(t => t.EffectiveDate)
                .FirstOrDefault();
            return _mapper.Map<TrashVM>(latestTrash);
        }
    }
}
