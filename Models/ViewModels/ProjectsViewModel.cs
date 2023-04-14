using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fag_el_Gamous.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<NewTable> NewTable { get; set; }
        public PageInfo PageInfo { get; set; }


        public string FilterSex { get; set; }
        public string FilterHairColor { get; set; }
        public string FilterFaceBundles { get; set; }
        public string FilterAgeAtDeath { get; set; }
        public string FilterHeadDirection { get; set; }
        public string FilterDepth { get; set; }
        public int? FilterEstimateStature { get; set; }
        public string FilterColorValue { get; set; }
        public string FilterStructureValue { get; set; }
        public string FilterTextileFunctionValue { get; set; }

    }
}
