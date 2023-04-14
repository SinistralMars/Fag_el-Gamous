using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// This code implements the IFagelGamousRepository interface in the EFFagelGamousRepository class,
// providing concrete functionality for interacting with the NewTable data model using the Entity Framework.
// It defines methods for querying, adding, updating, and deleting records, as well as saving changes to the
// BurialContext database context.

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
