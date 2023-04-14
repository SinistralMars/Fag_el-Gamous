using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// This code defines the IFagelGamousRepository interface for the Fag_el_Gamous project.
// It provides methods for interacting with the NewTable data model, including querying, adding, updating,
// and deleting records, as well as saving changes to the database.

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
