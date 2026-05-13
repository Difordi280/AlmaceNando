using AlmaceNando.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface ISessionService
    {
        User? CurrentUser { get;  }
        bool IsLoggedIn { get; }

        public Task<bool> Login(string user, string password);

        public Task Logout();
    }
}
