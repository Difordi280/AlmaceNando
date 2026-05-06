using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface ICashService
    {
        public Task OpeningCash(decimal Cash);
        public Task CloseingCash(decimal Cash);
        
    }
}
