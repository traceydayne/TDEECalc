using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TDEECalc.Models;

namespace TDEECalc.ViewModels
{
    public class AddLoserViewModel
    {
        [Required (ErrorMessage ="This field is required.")]
        public int Age { get; set; }
        public Sex Sex { get; set; }
        [Required]
        public int Height { get; set; }
        public int StartingWeight { get; set; }
        [Required]
        public int CurrentWeight { get; set; }
        [Required]
        public int TargetWeight { get; set; }
        [Required]
        public ActivityLevel CurrentActivityLevel { get; set; }
        public ActivityLevel TargetActivityLevel { get; set; }
        public List<SelectListItem> SexTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(Sex.Male.ToString(), ((int)Sex.Male).ToString()),
            new SelectListItem(Sex.Female.ToString(), ((int)Sex.Female).ToString())
        };
        public List<SelectListItem> ActivityTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(ActivityLevel.Sedentary.ToString(), ((int)ActivityLevel.Sedentary).ToString()),
            new SelectListItem(ActivityLevel.SlightlyActive.ToString(), ((int)ActivityLevel.SlightlyActive).ToString()),
            new SelectListItem(ActivityLevel.LightlyActive.ToString(), ((int)ActivityLevel.LightlyActive).ToString()),
            new SelectListItem(ActivityLevel.ModeratelyActive.ToString(), ((int)ActivityLevel.ModeratelyActive).ToString()),
            new SelectListItem(ActivityLevel.HighlyActive.ToString(), ((int)ActivityLevel.HighlyActive).ToString())
        };
        public int StartingTDEE { get; set; }
        public int CurrentTDEE { get; set; }
        public int TargetTDEE { get; set; }
        public string StartingBMI { get; set; }
        public string CurrentBMI { get; set; }
        public string TargetBMI { get; set; }
        public int CustomCals { get; set; }
        public int FindBMR(int weight)
        {
            int bmr;

            if (Sex == Sex.Male)
            {
                bmr = (int)Math.Round(10 * (weight / 2.2) + (6.25 * (Height * 2.54)) - (5 * Age) + 5);
            }
            else
            {
                bmr = (int)Math.Round(10 * (weight / 2.2) + (6.25 * (Height * 2.54)) - (5 * Age) - 161);
            }
            return bmr;
        }

        public int FindTDEE(int weight, ActivityLevel activityLevel)
        {
            int bmr = FindBMR(weight);
            int tdee = 0;

            if (activityLevel == ActivityLevel.Sedentary)
            {
                tdee = (int)Math.Round(bmr * 1.15);
            }
            else if (activityLevel == ActivityLevel.SlightlyActive)
            {
                tdee = (int)Math.Round(bmr * 1.3);
            }
            else if (activityLevel == ActivityLevel.LightlyActive)
            {
                tdee = (int)Math.Round(bmr * 1.425);
            }
            else if (activityLevel == ActivityLevel.ModeratelyActive)
            {
                tdee = (int)Math.Round(bmr * 1.55);
            }
            else if (activityLevel == ActivityLevel.HighlyActive)
            {
                tdee = (int)Math.Round(bmr * 1.75);
            }

            return tdee;
        }

        public string FindBMI(int weight)
        {
            float bmi = (float)Math.Round(703 * weight / Math.Pow(Height, 2), 1);
            
            if (bmi < 18.5)
            {
                return bmi + ". This is considered underweight and may be unhealthy.";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                return bmi + ". This is within the range of a healthy weight.";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return bmi + ". This is considered overweight and may be unhealthy.";
            }
            else if (bmi >= 30)
            {
                return bmi + ". This is considered obese and may be unhealthy.";
            }
            else
            {
                return "Whoops! Something went wrong.";
            }
        }

    }
}
