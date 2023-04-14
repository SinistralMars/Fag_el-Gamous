using Fag_el_Gamous.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Fag_el_Gamous.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace Fag_el_Gamous.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFagelGamousRepository _repo;
        private readonly string _modelPath;
        private readonly MLContext _mlContext;
        public HomeController(ILogger<HomeController> logger, IFagelGamousRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MLModels", "headlocation.onnx");
            _mlContext = new MLContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Burial(string sex, string hairColor, string faceBundles, string ageAtDeath, string headDirection, string depth, int? estimateStature, string structureValue, string colorValue, string textileFunctionValue, int pageNum = 1)
        {
            int pageSize = 10;

            var query = _repo.NewTable.AsQueryable();


            if (!string.IsNullOrEmpty(sex))
            {
                query = query.Where(b => b.Sex == sex);
            }

            if (!string.IsNullOrEmpty(hairColor))
            {
                query = query.Where(b => b.Haircolor == hairColor);
            }

            if (!string.IsNullOrEmpty(faceBundles))
            {
                query = query.Where(b => b.Facebundles == faceBundles);
            }

            if (!string.IsNullOrEmpty(ageAtDeath))
            {
                query = query.Where(b => b.Ageatdeath == ageAtDeath);
            }

            if (!string.IsNullOrEmpty(headDirection))
            {
                query = query.Where(b => b.Headdirection == headDirection);
            }

            if (!string.IsNullOrEmpty(depth))
            {
                query = query.Where(b => b.Depth == depth);
            }
            if (estimateStature.HasValue)
            {
                query = query.Where(b => b.Estimatestature == estimateStature.Value);
            }

            if (!string.IsNullOrEmpty(structureValue))
            {
                query = query.Where(b => b.StructureValue == structureValue);
            }

            if (!string.IsNullOrEmpty(colorValue))
            {
                query = query.Where(b => b.ColorValue == colorValue);
            }

            if (!string.IsNullOrEmpty(textileFunctionValue))
            {
                query = query.Where(b => b.TextileFunctionValue == textileFunctionValue);
            }

            var x = new ProjectsViewModel
            {
                NewTable = query
                    .OrderBy(b => b.Id)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = query.Count(),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                FilterSex = sex,
                FilterHairColor = hairColor,
                FilterFaceBundles = faceBundles,
                FilterAgeAtDeath = ageAtDeath,
                FilterHeadDirection = headDirection,
                FilterDepth = depth,
                FilterEstimateStature = estimateStature,
                FilterStructureValue = structureValue,
                FilterColorValue = colorValue,
                FilterTextileFunctionValue = textileFunctionValue,
            };

            return View(x);
        }


        public IActionResult Details(long id)
        {
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }
        public IActionResult Edit(long id)
        {
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        [HttpPost]
        public IActionResult Edit(long id, NewTable updatedBurial)
        {
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            // Update the burial properties
            burial.Id = updatedBurial.Id;
            burial.Burialid = updatedBurial.Burialid;
            burial.Dateofexcavation = updatedBurial.Dateofexcavation;
            burial.Sex = updatedBurial.Sex;
            burial.Northsouth = updatedBurial.Northsouth;
            burial.Depth = updatedBurial.Depth;
            burial.Eastwest = updatedBurial.Eastwest;
            burial.Adultsubadult = updatedBurial.Adultsubadult;
            burial.Facebundles = updatedBurial.Facebundles;
            burial.Southtohead = updatedBurial.Southtohead;
            burial.Preservation = updatedBurial.Preservation;
            burial.Fieldbookpage = updatedBurial.Fieldbookpage;
            burial.Squareeastwest = updatedBurial.Squareeastwest;
            burial.Goods = updatedBurial.Goods;
            burial.Text = updatedBurial.Text;
            burial.Wrapping = updatedBurial.Wrapping;
            burial.Haircolor = updatedBurial.Haircolor;
            burial.Westtohead = updatedBurial.Westtohead;
            burial.Samplescollected = updatedBurial.Samplescollected;
            burial.Area = updatedBurial.Area;
            burial.Length = updatedBurial.Length;
            burial.Burialnumber = updatedBurial.Burialnumber;
            burial.Dataexpertinitials = updatedBurial.Dataexpertinitials;
            burial.Westtofeet = updatedBurial.Westtofeet;
            burial.Ageatdeath = updatedBurial.Ageatdeath;
            burial.Southtofeet = updatedBurial.Southtofeet;
            burial.Excavationrecorder = updatedBurial.Excavationrecorder;
            burial.Photos = updatedBurial.Photos;
            burial.Hair = updatedBurial.Hair;
            burial.Burialmaterials = updatedBurial.Burialmaterials;
            burial.Fieldbookexcavationyear = updatedBurial.Fieldbookexcavationyear;
            burial.Clusternumber = updatedBurial.Clusternumber;
            burial.Shaftnumber = updatedBurial.Shaftnumber;
            burial.Squarenorthsouth = updatedBurial.Squarenorthsouth;
            burial.Headdirection = updatedBurial.Headdirection;
            burial.Estimatestature = updatedBurial.Estimatestature;
            burial.StructureValue = updatedBurial.StructureValue;
            burial.ColorValue = updatedBurial.ColorValue;
            burial.TextileFunctionValue = updatedBurial.TextileFunctionValue;

            _repo.Update(burial);

            return RedirectToAction(nameof(Burial));
        }

        public IActionResult Delete(long id)
        {
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long id)
        {
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            if (burial == null)
            {
                return NotFound();
            }

            _repo.Delete(burial.Id);

            return RedirectToAction(nameof(Burial));
        }
        public IActionResult Add()
        {
            var viewModel = new CreateBurialViewModel();
            return View(viewModel);
        }
        private long GenerateUniqueID()
        {
            long maxID = _repo.NewTable.Max(b => b.Id);
            return maxID + 1;
        }

        [HttpPost]
        public IActionResult Add(CreateBurialViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Burial.Id = GenerateUniqueID();
                _repo.AddBurial(viewModel.Burial);
                _repo.SaveChanges();

                return RedirectToAction("Burial");
            }

            return View(viewModel);
        }





        public IActionResult Supervised()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}









