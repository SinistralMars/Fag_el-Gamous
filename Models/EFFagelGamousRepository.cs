using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Fag_el_Gamous.Models
{
    public class EFFagelGamousRepository : IFagelGamousRepository
    {
        private BurialContext context { get; set; }

        public IQueryable<NewTable> NewTable => context.NewTable;


        public EFFagelGamousRepository (BurialContext temp)
        {
            context = temp;
        }
        public void Update(NewTable updatedBurial)
        {
            context.NewTable.Update(updatedBurial);
            context.SaveChanges();
        }
        public void Delete(long id)
        {
            var burial = context.NewTable.FirstOrDefault(b => b.Id == id);
            if (burial != null)
            {
                context.NewTable.Remove(burial);
                context.SaveChanges();
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void AddBurial(NewTable burial)
        {
            context.NewTable.Add(burial);
        }
    }
}
