﻿using server_dthome.Models;
using server_dthome.ViewModels;

namespace server_dthome.Repositories
{
    public interface IMemberOfRentalRepository
    {
        List<MemberOfRentalVM> GetAll();
        MemberOfRentalVM GetById(int id);
        List<MemberOfRentalVM> GetByIdRental(int idRental);
        MemberOfRentalVM Create(MemberOfRentalModel memberOfRentalModel);
        bool Update(int id, MemberOfRentalModel memberOfRentalModel);
        bool Delete(int id);
    }
}
