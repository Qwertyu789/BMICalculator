using prjBMICalculator.BMIClass;
using System;

namespace prjBMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Human m = new HumanMale {  Height_cm = 170, Name = "John", Weight = 70 };
            //Human f = new HumanFemale { Name = "Nancy", Height_cm = 156, Weight = 40 };

            //m.PrintInfo();
            //f.PrintInfo();
            //Console.Read();

            (new Cauculator()).BMICalculator();
        }
       
    }
   
}

