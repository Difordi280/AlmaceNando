using System;
using System.Collections.Generic;
using System.Text;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Services;
using AlmaceNando.Domain.Services.Coordinator;
using AlmaceNando.Domain.Models.People;

namespace AlmaceNando.Logic.Coordinator
{
    public class LoginCoordinator : ILoginCoordinator
    {
        private readonly ISessionService sessionService;

        private readonly IUserRepository userRepository;

        private readonly IAuditService auditService;

        private readonly IFinanceService financeService;

        


        private User? SaveUser {  get; set; }

        public LoginCoordinator(ISessionService sessionService, IUserRepository userRepository,IAuditService auditService, IUserHistoryReposiory userHistoryReposiory)
        {
            this.sessionService = sessionService;
            this.userRepository = userRepository;
            this.auditService = auditService;
            this.userHistoryReposiory = userHistoryReposiory;
        }

        public async Task<bool> AutomaticOpening(string username, string password)
        {
            return false;
        }


        public async Task<bool> AutomaticClosing(string username, string password)
        {
            //para cerrar primero se tiene que comprovar que el usuario que tenemos es valido
            bool identification = username.All(c => char.IsDigit(c));

            SaveUser = await userRepository.GetUserAsync(identification, username);

            if (SaveUser == null) return false;
            else
            {
                //antes de servicio de calculadora, saber cual fue el ultimo cierre y apertura 




                decimal? Cash = null;
                decimal? Debtor = null;
                //servicio Calculadora
                //(Cash,Debtor) = financeService.CloseShift()
                

                // Reporte del servicio auditor
                //auditService.CloseingCash();

            }
            


            return true;
            

        }

    }
}
