using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services.Coordinator
{
    public interface ILoginCoordinator
    {
        //realiza todas los operaciones necesarias para que la sesion se abra 
        public Task<bool> AutomaticOpening(string username, string password);
        public Task<bool> AutomaticClosing(string username, string password);


    }
}
