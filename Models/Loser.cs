using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDEECalc.Models
{
    public class Loser
    {
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public int StartingWeight { get; set; }
        public int CurrentWeight { get; set; }
        public int TargetWeight { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public int BMR { get; set; }
        public int TDEE { get; set; }
        public string StartingBMI { get; set; }
        public string CurrentBMI { get; set; }
        public string TargetBMI { get; set; }
        public bool CanEdit { get; set; } = true;

        public Loser()
        {
        }
        public Loser(int age, Sex sex, int height, int sw, int cw, int tw, ActivityLevel actLevel) : this()
        {
            Age = age;
            Sex = sex;
            Height = height;
            StartingWeight = sw;
            CurrentWeight = cw;
            TargetWeight = tw;
            ActivityLevel = actLevel;
        }

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
