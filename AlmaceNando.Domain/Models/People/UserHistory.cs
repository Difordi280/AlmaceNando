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

        //1.Apertura 
        //2.Cierre Declarado
        //3.Corte de Sistema 
        public int actionType { get; set; }
        
        //Campo util  para que la informacion importante la pueda sacar
        //la persona que esta utilizando la aplicacion
        public decimal Cash {  get; set; }


        public string? Description { get; set; }
    }
}
