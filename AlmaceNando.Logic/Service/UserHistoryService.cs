using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class UserHistoryService:IUserHistoryService
    {
        //Saber si alguien esta usandolo en este momento
        private readonly IServiceLogin _login;

        // Ayudando hacer y averiguar el estado del usuario

        private readonly IRepository<UserHistory> _userHistorySim;

        private readonly IUserHistoryReposiory _userHistoryRepository;

        

        public UserHistoryService(IRepository<UserHistory> userHistorySim, IUserHistoryReposiory userHistoryReposiory, IServiceLogin login)
        {
            _userHistorySim = userHistorySim;
            _userHistoryRepository = userHistoryReposiory;
            _login = login;

        }


        //Hace una apertura simple
        public async Task OpeningCash(decimal? Cash)
        {
            //ingreso de informacion ya dada
            //entender que registro hacer con el dinero

            //user
            //Action=1


            //Cash averiguar 
            string Description = "";
            DateTime dateTime = DateTime.Now;
            UserHistory? closing = new UserHistory();
            closing = await _userHistoryRepository.GetLastOpening(dateTime, 2);


            if (Cash == null)
            {

                Cash = closing?.Cash ?? 0;

                Description = "Guardado Automatico revisar Caja lo antes posible!!";


            }
            else if (closing.Cash == Cash)
            {
                Description = "Ingreso exitoso";
            }
            else
            {
                Description = $"Faltan ${closing.Cash - Cash} en la caja, porfavor revisar ";
            }

            UserHistory opening = new UserHistory
             {
                CreatedAt= DateTime.Now,
                UserId = _login.CurrentUser.Id,
                actionType=1,
                Cash=closing.Cash,
                Description=Description,
            };

             await _userHistorySim.AddAnsy(opening);


            //Descripcion


        }


        public async Task CloseingCash(decimal Cash)
        {



        }



    }
}
