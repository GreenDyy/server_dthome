using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public readonly DthomeContext _context;
        private readonly IMapper _mapper;
        public RoomRepository(DthomeContext dthomeContext, IMapper mapper) 
        {
            _context = dthomeContext;
            _mapper = mapper;
        }

        public RoomVM Create(RoomModel roomModel)
        {
            var room = _mapper.Map<Room>(roomModel);
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return _mapper.Map<RoomVM>(room);
        }

        public bool Delete(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<RoomVM> GetAll()
        {
            var rooms = _context.Rooms.ToList();
            var roomVMs = _mapper.Map<List<RoomVM>>(rooms);
            return roomVMs;
        }

        public List<RoomVM> GetAllByOwnerId(int ownerId)
        {
            var rooms = _context.Rooms.Where(room => room.OwnerId == ownerId).ToList();
            var roomVMs = _mapper.Map<List<RoomVM>>(rooms);
            return roomVMs;
        }

        public RoomVM GetById(int ownerId, int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.OwnerId == ownerId && r.RoomId == id);
            return _mapper.Map<RoomVM>(room);
        }

        public bool Update(int id, RoomModel roomModel)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == id);
            if(room != null)
            {
                _mapper.Map(roomModel, room);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
