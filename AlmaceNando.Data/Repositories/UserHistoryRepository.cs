using AlmaceNando.Data.Context;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Repositories
{
    public class UserHistoryRepository:IUserHistoryReposiory
    {

        private readonly StoreContext _context;

        public UserHistoryRepository( StoreContext context)
        {
            _context = context; 
        }
        public async Task<UserHistory?> GetLastOpening(DateTime dateTime , Guid IdUser)
        {
            //1. Se organiza la lista, para tener los ultimo productos de primero 
            //2. Se busca al primero dato que cumpla, sobre todo con, Id ,ActionType y que sea el ultimo

            UserHistory? ByOrder= await _context.Set<UserHistory>()
                .OrderByDescending(element => element.CreatedAt)
                .FirstOrDefaultAsync(T => T.CreatedAt < dateTime &&  IdUser == T.UserId && T.actionType == 1);

            return ByOrder ;
        }
    }
}
