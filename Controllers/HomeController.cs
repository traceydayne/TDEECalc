using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDEECalc.Models;
using TDEECalc.ViewModels;

namespace TDEECalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static AddLoserViewModel newLoser;
        public static List<AddLoserViewModel> loserList = new List<AddLoserViewModel>();
        public static Dictionary<string, int>[] foodDictionary = {(new Dictionary<string, int>() {{ "servings of pasta", 200 }}),(new Dictionary<string, int>() { { "Krispy Kreme donuts", 190 } }),
            (new Dictionary<string, int>() { { "pounds of spaghetti squash", 140 } }),
            (new Dictionary<string, int>() { { "cans of Coca-Cola ", 140 } }),
            (new Dictionary<string, int>() { { "McDoubles", 390 } }),
            new Dictionary<string, int>() { { "slices of pepperoni pizza", 340 } }};
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AddLoserViewModel addLoserViewModel = new AddLoserViewModel();
            return View(addLoserViewModel);
        }
        [HttpPost]
        public IActionResult Index(AddLoserViewModel addLoserViewModel)
        {
            if (ModelState.IsValid)
            {

                newLoser = new AddLoserViewModel
                {
                    Age = addLoserViewModel.Age,
                    Sex = addLoserViewModel.Sex,
                    Height = addLoserViewModel.Height,
                    StartingWeight = addLoserViewModel.StartingWeight,
                    CurrentWeight = addLoserViewModel.CurrentWeight,
                    TargetWeight = addLoserViewModel.TargetWeight,
                    ActivityLevel = addLoserViewModel.ActivityLevel,
                    CurrentTDEE = addLoserViewModel.FindTDEE(addLoserViewModel.CurrentWeight, addLoserViewModel.ActivityLevel),
                    TargetTDEE = addLoserViewModel.FindTDEE(addLoserViewModel.TargetWeight, addLoserViewModel.ActivityLevel),
                    StartingBMI = addLoserViewModel.FindBMI(addLoserViewModel.StartingWeight),
                    CurrentBMI = addLoserViewModel.FindBMI(addLoserViewModel.CurrentWeight),
                    TargetBMI = addLoserViewModel.FindBMI(addLoserViewModel.TargetWeight)
                };

                loserList.Add(newLoser);

                return View(newLoser);
            }
            else
            {
                return View(addLoserViewModel);
            }
        }

        [HttpPost]
        public IActionResult Reset()
        {
            AddLoserViewModel addLoserViewModel = new AddLoserViewModel();
            return View(addLoserViewModel);
        }

        [HttpPost]
        public IActionResult Edit()
        {
            
            return View(newLoser);
        }

        public IActionResult AdditionalResources()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void AddToList()
        {
            
        }
    }
}
