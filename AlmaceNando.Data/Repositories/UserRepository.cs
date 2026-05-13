using AlmaceNando.Data.Context;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(StoreContext context):base(context) { }

        public async Task<User?> GetUserAsync(bool identification, string Name)
        {
            User? user = new User();

            if (identification)
            {
                user = await _context.Set<User>().FirstOrDefaultAsync(x => x.Identification == Name);
            }
            else
            {
                user = await _context.Set<User>().FirstOrDefaultAsync(x => x.UserName == Name);
            }

            return user;
        }
    }
}
