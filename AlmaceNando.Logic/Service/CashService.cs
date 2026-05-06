using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class CashService:ICashService
    {

        private readonly IServiceLogin _login;

        private readonly IRepository<UserHistory> _userHistorySim;

        private readonly IUserHistoryReposiory _userHistoryRepository;

        

        public CashService(IRepository<UserHistory> userHistorySim, IUserHistoryReposiory userHistoryReposiory, IServiceLogin login)
        {
            _userHistorySim = userHistorySim;
            _userHistoryRepository = userHistoryReposiory;
            _login = login;

        }


        public async Task OpeningCash(decimal Cash)
        {
            string? Rol = _login.CurrentUser.Rol;

            if (Rol == null || Rol == "NN")
            { 
                

            }


        }


        public async Task CloseingCash(decimal Cash)
        {



        }



    }
}
