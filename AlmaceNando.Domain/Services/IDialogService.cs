using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Services
{
    public interface IDialogService
    {
        public Task<decimal?> RequestAmount(string messenger,string title);

        public bool Confirm(string messenger);
    }
}
