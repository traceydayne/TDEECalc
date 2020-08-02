using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TDEECalc.Models;

namespace TDEECalc.ViewModels
{
    public class AddLoserViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        //[Range(18,99, ErrorMessage ="You must be between 18 and 99 years old for accurate results.")]
        public int Age { get; set; }
        public Sex Sex { get; set; }
        [Required]
        /*[Range(50, 80, ErrorMessage ="Sorry, your circumstances might be different than our calculator can predict for. Please ask your doctor for help calculating your TDEE.")]*/
        public int Height { get; set; }
        public int StartingWeight { get; set; }
        [Required]
        /*[Range(50, 80, ErrorMessage = "Sorry, your circumstances might be different than our calculator can predict for. Please ask your doctor for help calculating your TDEE.")]*/
        public int CurrentWeight { get; set; }
        [Required]
        /*[Range(50, 80, ErrorMessage = "Sorry, your circumstances might be different than our calculator can predict for. Please ask your doctor for help calculating your TDEE.")]*/
        public int TargetWeight { get; set; }
        [Required]
        public ActivityLevel ActivityLevel { get; set; }
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
        public int BMR { get; set; }
        public int TDEE { get; set; }
        public string StartingBMI { get; set; }
        public string CurrentBMI { get; set; }
        public string TargetBMI { get; set; }
        public int FindBMR()
        {
            int bmr;

            if (Sex == Sex.Male)
            {
                bmr = (int)Math.Round(10 * (CurrentWeight / 2.2) + (6.25 * (Height * 2.54)) - (5 * Age) + 5);
            }
            else
            {
                bmr = (int)Math.Round(10 * (CurrentWeight / 2.2) + (6.25 * (Height * 2.54)) - (5 * Age) - 161);
            }
            return bmr;
        }

        public int FindTDEE()
        {
            int bmr = FindBMR();
            int tdee = 0;

            if (ActivityLevel == ActivityLevel.Sedentary)
            {
                tdee = (int)Math.Round(bmr * 1.15);
            }
            else if (ActivityLevel == ActivityLevel.SlightlyActive)
            {
                tdee = (int)Math.Round(bmr * 1.3);
            }
            else if (ActivityLevel == ActivityLevel.LightlyActive)
            {
                tdee = (int)Math.Round(bmr * 1.425);
            }
            else if (ActivityLevel == ActivityLevel.ModeratelyActive)
            {
                tdee = (int)Math.Round(bmr * 1.55);
            }
            else if (ActivityLevel == ActivityLevel.HighlyActive)
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
                return "A BMI of: " + bmi + " is considered underweight and may be unhealthy.";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                return "A BMI of: " + bmi + " is considered a healthy weight.";
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                return "A BMI of: " + bmi + " is considered overweight and may be unhealthy.";
            }
            else if (bmi >= 30)
            {
                return "A BMI of: " + bmi + " is considered obese and may be unhealthy.";
            }
            else
            {
                return "Whoops! Something went wrong.";
            }
        }

    }
}
