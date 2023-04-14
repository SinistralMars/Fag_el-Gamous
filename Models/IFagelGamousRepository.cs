using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Fag_el_Gamous.Models
{
    public interface IFagelGamousRepository
    {
        IQueryable<NewTable> NewTable { get; }





        void Update(NewTable updatedBurial);
        void Delete(long id);
        void SaveChanges();
        void AddBurial(NewTable burial);




    }
}
