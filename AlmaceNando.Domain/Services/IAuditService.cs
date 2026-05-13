using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface IAuditService
    {
        //CARGO:Informar y recopilar
        //Detalles:No te encargas ni de decidir ni de opinar
        //         solo guardas informacion, o expones segun lo que te ordenen
        


        public Task OpeningCash(decimal? Cash);
        public Task CloseingCash(decimal Cash);
        
    }
}
