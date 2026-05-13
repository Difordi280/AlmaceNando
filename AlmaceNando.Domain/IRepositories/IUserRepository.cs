using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.IRepositories
{
    public interface IUserRepository: IRepository<User>
    {
        public Task<User?> GetUserAsync(bool identification,string Name);
    }
}
