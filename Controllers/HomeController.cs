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
using TDEECalc.Data;

namespace TDEECalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static AddLoserViewModel newLoser;
        public static List<AddLoserViewModel> loserList = new List<AddLoserViewModel>();
        public static string customDaysToGoal = "";
        public static bool displayDb = false;
        private FoodDbContext context;

        public HomeController(ILogger<HomeController> logger, FoodDbContext dbContext)
        {
            _logger = logger;
            context = dbContext;
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
                    CurrentActivityLevel = addLoserViewModel.CurrentActivityLevel,
                    TargetActivityLevel = addLoserViewModel.TargetActivityLevel,
                    CurrentTDEE = addLoserViewModel.FindTDEE(addLoserViewModel.CurrentWeight, addLoserViewModel.CurrentActivityLevel),
                    TargetTDEE = addLoserViewModel.FindTDEE(addLoserViewModel.TargetWeight, addLoserViewModel.TargetActivityLevel),
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
        [HttpGet]
        public IActionResult AdditionalResources()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MoreInformation()
        {
            displayDb = false;
            return View();
        }
        [HttpPost]
        public IActionResult MoreInformation(AddLoserViewModel addLoserViewModel)
        {
            displayDb = true;
            List < Food > foods = context.Foods.ToList();
            ViewBag.foodList = foods;
            ViewBag.calDiff = (double)Math.Abs(newLoser.CurrentTDEE - newLoser.TargetTDEE);
            return View(newLoser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult CustomCalories(AddLoserViewModel loser)
        {
            newLoser.CustomCals = loser.CustomCals;

            int timeToTarget = 0;

            int weightDif = 0;
            int calorieDif = newLoser.CurrentTDEE - newLoser.CustomCals;

            if (newLoser.CurrentWeight > newLoser.TargetWeight && calorieDif > 0)
            {
                weightDif = newLoser.CurrentWeight - newLoser.TargetWeight;
                timeToTarget = (int)weightDif * 3500 / (newLoser.CurrentTDEE - newLoser.CustomCals);
                customDaysToGoal = "If you ate " + newLoser.CustomCals + " calories every day, it would take you " + timeToTarget + " days to reach your goal.";
            }
            else if (newLoser.TargetWeight > newLoser.CurrentWeight && calorieDif < 0)
            {
                weightDif = newLoser.TargetWeight - newLoser.CurrentWeight;
                timeToTarget = (int)weightDif * 3500 / (newLoser.CustomCals - newLoser.CurrentTDEE);
                customDaysToGoal = "If you ate " + newLoser.CustomCals + " calories every day, it would take you " + timeToTarget + " days to reach your goal.";
            }
            else
            {
                customDaysToGoal = "Whoops! Looks like you can't reach your goal with that caloric intake. Try again.";
            }            
            return View(newLoser);
        }

    }
}
