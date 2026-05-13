using AlmaceNando.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services.Coordinator
{
    public interface IlogoutCoordinator
    {
        //Es el que nos va ha dar el nombre y el resultado
        // si resultado es null entonces la contraseña ingresada es invalida
        public Task<decimal?> IsAuthenticated(string password);

    }
}
