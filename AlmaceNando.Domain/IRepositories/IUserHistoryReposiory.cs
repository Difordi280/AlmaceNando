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
        public  Task<UserHistory> GetLastOpening(DateTime dateTime , Guid IdUser);
       
    }
}
