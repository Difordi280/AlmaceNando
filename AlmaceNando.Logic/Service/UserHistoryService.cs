using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.Service
{
    public class UserHistoryService:IAuditService
    {
        //Saber si alguien esta usandolo en este momento
        private readonly ISessionService _login;

        // Ayudando hacer y averiguar el estado del usuario

        private readonly IRepository<UserHistory> _userHistorySim;

        private readonly IUserHistoryReposiory _userHistoryRepository;

        

        public UserHistoryService(IRepository<UserHistory> userHistorySim, IUserHistoryReposiory userHistoryReposiory, ISessionService login)
        {
            _userHistorySim = userHistorySim;
            _userHistoryRepository = userHistoryReposiory;
            _login = login;

        }



        public async Task OpeningCash(decimal? cash)
        {
            // 1. Configuración inicial
            DateTime now = DateTime.Now;
            string description = "";

            // Siempre buscamos el último cierre (2) para contrastar la apertura
            int actionToSearch = 2;

            // 2. Traer el último registro de cierre
            UserHistory? lastClosing = await _userHistoryRepository.GetLastOpening(now, actionToSearch);
            decimal baseCash = lastClosing?.Cash ?? 0;

            // 3. Lógica de validación de apertura
            if (cash == null)
            {
                cash = baseCash;
                description = "[Apertura] Guardado automático por ausencia de datos. Revisar.";
            }
            else if (cash == baseCash)
            {
                description = "[Apertura] Exitosa. El monto coincide con el cierre anterior.";
            }
            else
            {
                decimal diferencia = baseCash - cash.Value;
                string estado = diferencia > 0 ? "Faltante" : "Sobrante";
                description = $"[Apertura] Alerta: {estado} de ${Math.Abs(diferencia)}. Se esperaba: ${baseCash}";
            }

            // 4. Crear el registro de apertura (Tipo 1)
            UserHistory opening = new UserHistory
            {
                CreatedAt = now,
                UserId = _login.CurrentUser.Id,
                actionType = 1, // 1 siempre será Apertura
                Cash = cash.Value,
                Description = description
            };

            await _userHistorySim.AddAnsy(opening);
        }




    }
}
