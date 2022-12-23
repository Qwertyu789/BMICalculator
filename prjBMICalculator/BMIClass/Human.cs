using System;

namespace prjBMICalculator.BMIClass
{



    abstract class Human : ProfileInfo
    {
        //人類BMI算法
        public override double BMI()
        {
            return Math.Round(base._Weight / Math.Pow((base._Height_cm) * 0.01, 2), 2);
        }
    }
    class HumanMale : Human
    {
        public HumanMale()
        {
            GenderNum = 0;
            //男性BMI標準
            BMIIndicator = new double[] { 25, 20 };
        }
    }
    class HumanFemale : Human
    {
        public HumanFemale()
        {
            GenderNum = 1;
            //女性BMI標準
            BMIIndicator = new double[] { 22, 18 };
        }
    }
}
