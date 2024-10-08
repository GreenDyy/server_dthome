﻿using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IRoomRepository
    {
        //lấy all
        public List<RoomVM> GetAll();
        public List<RoomVM> GetAllByOwnerId(int ownerId);
        //lấy 1
        public RoomVM GetById(int ownerId, int id);
        //thêm
        public RoomVM Create(RoomModel roomModel);
        //xoá
        public bool Delete(int id);
        //sửa
        public bool Update(int id, RoomModel roomModel);
    }
}
