using AlmaceNando.Domain.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.IRepositories
{
    public interface IUserHistoryReposiory
    {
        //Consultar ultima apertura 
        //Para asi emparejarlo 
        //En ocaciones buscare la apertura, y en otras el cierre
        public  Task<UserHistory?> GetLastOpening(DateTime dateTime , int Action);
       
    }
}
