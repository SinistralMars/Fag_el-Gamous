// Import required namespaces
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

// Define the Fag_el_Gamous.Controllers namespace
namespace Fag_el_Gamous.Controllers
{
    // Create a HomeController class that inherits from Controller
    public class HomeController : Controller
    {
        // Declare private variables for logging, the repository, the model path, and the ML context
        private readonly ILogger<HomeController> _logger;
        private readonly IFagelGamousRepository _repo;
        private readonly string _modelPath;
        private readonly MLContext _mlContext;

        // Constructor for the HomeController class
        public HomeController(ILogger<HomeController> logger, IFagelGamousRepository repo)
        {
            // Initialize the logger, repository, model path, and ML context
            _logger = logger;
            _repo = repo;
            _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MLModels", "headlocation.onnx");
            _mlContext = new MLContext();
        }

        // Handle GET requests for the Index action
        public IActionResult Index()
        {
            // Return the default Index view
            return View();
        }

        // Handle GET requests for the Privacy action
        public IActionResult Privacy()
        {
            // Return the Privacy view
            return View();
        }

        // Handle GET requests for the Admin action and require authorization
        [Authorize]
        public IActionResult Admin()
        {
            // Return the Admin view for authorized users
            return View();
        }

        // Handle GET requests for the Burial action with various filtering options
        public IActionResult Burial(string sex, string hairColor, string faceBundles, string ageAtDeath, string headDirection, string depth, int? estimateStature, string structureValue, string colorValue, string textileFunctionValue, int pageNum = 1)
        {
            // Set the page size for pagination
            int pageSize = 10;

            // Query the repository's NewTable
            var query = _repo.NewTable.AsQueryable();

            // Apply filters to the query based on the provided parameters
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

            // Create a ProjectsViewModel object with the filtered query results and pagination info
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

            // Return the Burial view with the ProjectsViewModel object
            return View(x);
        }

        // Handle GET requests for the Details action with the provided burial ID
        public IActionResult Details(long id)
        {
            // Find the burial with the matching ID
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            // If the burial is not found, return a NotFound result
            if (burial == null)
            {
                return NotFound();
            }

            // Return the Details view with the burial data
            return View(burial);
        }

        // Handle GET requests for the Edit action with the provided burial ID
        public IActionResult Edit(long id)
        {
            // Find the burial with the matching ID
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            // If the burial is not found, return a NotFound result
            if (burial == null)
            {
                return NotFound();
            }

            // Return the Edit view with the burial data
            return View(burial);
        }

        // Handle POST requests for the Edit action with the provided burial ID and updated burial data
        [HttpPost]
        public IActionResult Edit(long id, NewTable updatedBurial)
        {
            // Find the burial with the matching ID
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            // If the burial is not found, return a NotFound result
            if (burial == null)
            {
                return NotFound();
            }

            // Update the burial properties with the values from the updatedBurial object
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

            // Update the burial in the repository
            _repo.Update(burial);

            // Redirect to the Burial action
            return RedirectToAction(nameof(Burial));
        }

        // Handle GET requests for the Delete action with the provided burial ID
        public IActionResult Delete(long id)
        {
            // Find the burial with the matching ID
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            // If the burial is not found, return a NotFound result
            if (burial == null)
            {
                return NotFound();
            }

            // Return the Delete view with the burial data
            return View(burial);
        }

        // Handle POST requests for the Delete action with the provided burial ID
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(long id)
        {
            // Find the burial with the matching ID
            var burial = _repo.NewTable.FirstOrDefault(b => b.Id == id);

            // If the burial is not found, return a NotFound result
            if (burial == null)
            {
                return NotFound();
            }

            // Delete the burial and save the changes
            _repo.Delete(burial.Id);

            // Redirect to the Burial action
            return RedirectToAction(nameof(Burial));
        }

        // Handle GET requests for the Add action
        public IActionResult Add()
        {
            // Create a new CreateBurialViewModel object
            var viewModel = new CreateBurialViewModel();
            return View(viewModel);
        }

        // Generate a unique ID for a new burial
        private long GenerateUniqueID()
        {
            // Find the maximum ID value in the repository and add 1 to generate a unique ID
            long maxID = _repo.NewTable.Max(b => b.Id);
            return maxID + 1;
        }

        // Handle POST requests for the Add action with the provided CreateBurialViewModel object
        [HttpPost]
        public IActionResult Add(CreateBurialViewModel viewModel)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // Generate a unique ID for the new burial and add it to the repository
                viewModel.Burial.Id = GenerateUniqueID();
                _repo.AddBurial(viewModel.Burial);
                _repo.SaveChanges();

                // Redirect to the Burial action
                return RedirectToAction("Burial");
            }

            // Return the Add view with the viewModel if the model state is invalid
            return View(viewModel);
        }




        // Handle GET requests for the Supervised action
        public IActionResult Supervised()
        {
            // Return the Supervised view
            return View();
        }

        // Handle GET requests for the Unsupervised action
        public IActionResult Unsupervised()
        {
            // Return the Unsupervised view
            return View();
        }


        // Handle GET requests for the Error action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Return the Error view with a new ErrorViewModel object containing the current request ID
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}









