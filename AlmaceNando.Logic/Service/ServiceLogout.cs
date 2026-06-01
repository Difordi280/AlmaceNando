using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using AlmaceNando.Domain.Services.Coordinator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class ServiceLogout:IlogoutCoordinator
    {
        private readonly ISaleHistoryRepository _HistoryR;
        private readonly IUserHistoryReposiory _UserR;
        private readonly ISessionService _login;
        
        
        public ServiceLogout(ISaleHistoryRepository History, IUserHistoryReposiory UserR, ISessionService login )
        {
            _HistoryR = History;
            _UserR = UserR;
            _login = login;
        }
        

        public async Task<decimal?> IsAuthenticated(string password)
        {
            //simulamos calve
            string autheticated = "16755";
            decimal? value = null;

            if (autheticated == password )
            {
                // buscamos la ultima apertura
                UserHistory? opening = await _UserR.GetLastOpening( DateTime.Now,1);


                // buscamos todas las ventas desde ahi en adelante y paramos  en la hora que nos dio el primero metodo
                //var  Sales =  await _HistoryR.GetHistoryProducts(opening.CreatedAt , DateTime.Now, _login.CurrentUser.Id);

                // sumar todos lo precios
                //value = SalesSum(Sales);

                // vamos  haciendo una lista  de los productos que se vendieron 
            }
            else if (_login.CurrentUser.Password == password) 
            { 
            }
          

            return value;
        }

        private decimal SalesSum(IEnumerable<Sale> sales)
        {
            decimal sum = 0;
            foreach (Sale sale in sales)
            {
                sum += sale.TotalAmount;
            }

            return sum;
        }
        
    }
}
