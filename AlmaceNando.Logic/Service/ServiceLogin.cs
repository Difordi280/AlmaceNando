using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class ServiceLogin:IServiceLogin
    {
        public User? CurrentUser { get;private set; }

        private readonly IUserRepository  _userRepository;

        private readonly IRepository<UserHistory> UserHistoryRespository;

        public bool IsLoggedIn { get; private set; }
        
        public ServiceLogin(IUserRepository userRepository, IRepository<UserHistory> _userhistoryreposity) 
        { 
            _userRepository = userRepository;
            UserHistoryRespository = _userhistoryreposity;

        }
        public async Task<bool> Login(string user, string password)
        {
            bool registro = user.All(a => char.IsDigit(a));

            User? get = await _userRepository.GetUserAsync(registro, user);

            if (get == null || get.Rol == "NN") return false;

            if (get.Password != password) return false;

            CurrentUser = get;

            UserHistory history = new UserHistory()
                {
                    Id= Guid.NewGuid(),
                    UserId= get.Id,
                    actionType= 1,
                    Description=$"Inicio sesion un {get.Rol}"
                };

            await UserHistoryRespository.AddAnsy(history);

            IsLoggedIn = true;

            return IsLoggedIn;
        }

        public async Task Logout()
        {
            UserHistory history = new UserHistory()
            {
                Id = Guid.NewGuid(),
                UserId = CurrentUser.Id,
                actionType = 1,
                Description = $"Inicio sesion un {CurrentUser.Rol}"
            };

            await UserHistoryRespository.AddAnsy(history);


            IsLoggedIn = false;

        }
    }
}
