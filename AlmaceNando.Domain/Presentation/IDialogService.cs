using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Presentation
{
    public interface IDialogService
    {
        public Task<decimal?> RequestAmount(string messenger,string title, bool canCancel = true);

        
    }
}
