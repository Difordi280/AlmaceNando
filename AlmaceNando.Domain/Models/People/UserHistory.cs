using AlmaceNando.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.People
{

    public class UserHistory:BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        //1.ingreso
        //2.salida
        public int actionType { get; set; }

        public string? Description { get; set; }
    }
}
