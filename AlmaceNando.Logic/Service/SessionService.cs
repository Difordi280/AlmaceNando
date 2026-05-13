using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class ServiceLogin : ISessionService
    {
        // Almacena los datos del usuario tras un inicio de sesión exitoso.
        public User? CurrentUser { get; private set; }

        private readonly IUserRepository _userRepository;

        // Indica si existe una sesión activa actualmente.
        public bool IsLoggedIn { get; private set; }

        public ServiceLogin(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Valida las credenciales contra el repositorio y establece el estado de la sesión.
        /// </summary>
        public async Task<bool> Login(string user, string password)
        {
            // Determina si la entrada es numérica para definir el tipo de búsqueda (ej. CC vs Username).
            bool registro = user.All(a => char.IsDigit(a));

            User? get = await _userRepository.GetUserAsync(registro, user);

            // Validación de existencia, rol asignado y coincidencia de contraseña.
            if (get == null || get.Rol == "NN") return false;
            if (get.Password != password) return false;

            CurrentUser = get;
            IsLoggedIn = true;

            return IsLoggedIn;
        }

        /// <summary>
        /// Finaliza la sesión actual y limpia las credenciales en memoria.
        /// </summary>
        public async Task Logout()
        {
            CurrentUser = new User { Name = "Invitado", Rol = "NN" };
            IsLoggedIn = false;
            await Task.CompletedTask;
        }
    }
}