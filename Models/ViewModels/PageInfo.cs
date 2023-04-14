using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fag_el_Gamous.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Pages needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBurials / BurialsPerPage);
    }
}
