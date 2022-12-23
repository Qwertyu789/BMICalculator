using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBMICalculator.BMIClass
{
    class Cauculator
    {
        public void BMICalculator()
        {
            CheckHelper check = new CheckHelper();

            Console.WriteLine("BMI計算");
            Console.Write($"請輸入姓名：");
            string Name = Console.ReadLine();
            Console.Write($"請輸入物種編號（{(new ProfileHelper()).getSpeciesList()}）：");
            int SpeciesNum = check.checkSpeciesNum(Console.ReadLine());
            //Console.WriteLine(SpeciesNum);
            //Console.Read();
            Console.Write($"請輸入性別編號（{(new ProfileHelper()).getGenderList()}）：");
            int GenderNum = check.checkGenderNum(Console.ReadLine());
            //Console.WriteLine(GenderNum);
            Console.WriteLine($"====請輸入身高(cm)/體重(kg)====");
            Console.Write($"請輸入身高(cm)：");
            double height = check.checkProfile(Console.ReadLine());
            Console.Write($"請輸入體重(kg)：");
            double weight = check.checkProfile(Console.ReadLine());
            Console.WriteLine($"資料填寫完畢...");
            ProfileInfo profile = buildProfile(Name, SpeciesNum, GenderNum, height, weight);

            profile.PrintInfo();

            Console.Read();
        }
        /// <summary>
        ///  建立資料，判斷部分要再思考怎麼處理。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="speciesNum"></param>
        /// <param name="genderNum"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public ProfileInfo buildProfile(string name,int speciesNum,int genderNum,double height,double weight) 
        {
            ProfileInfo res;
            switch (speciesNum)
            {
                case 0:
                    if (genderNum == 0)
                    {
                        res = new HumanMale();
                    }
                    else if(genderNum==1)
                    {
                        res = new HumanFemale();
                    }
                    else
                    {
                        res = null;
                    }
                    break;
                default:
                    res = null;
                    break;
            }

            if (res != null)
            {
                res.Name = name;
                res.Height_cm = height;
                res.Weight = weight;
            }

            return res;
        }

    }
    class CheckHelper
    {
        public int checkSpeciesNum(string Value)
        {
            int Num = 999;
            bool boolCheck = int.TryParse(Value, out Num);
            string emsg;
            if (!boolCheck)
            {
                emsg= "輸入錯誤，請重新輸入：";
                Console.Write(emsg);
                Num = checkSpeciesNum(Console.ReadLine());
            }
            else
            {
                if (!Enum.IsDefined(typeof(EnumSpecies), Num))
                {
                    emsg = "查無結果，請重新輸入：";
                    Console.Write(emsg);
                    Num = checkSpeciesNum(Console.ReadLine());
                }
            }
            return Num;
        }
        public int checkGenderNum(string Value)
        {
            int Num = 999;
            bool boolCheck = int.TryParse(Value, out Num);
            string emsg;
            if (!boolCheck)
            {
                emsg = "輸入錯誤，請重新輸入：";
                Console.Write(emsg);
                Num = checkGenderNum(Console.ReadLine());
            }
            else
            {
                if (!Enum.IsDefined(typeof(EnumGender), Num))
                {
                    emsg = "查無性別，請重新輸入：";
                    Console.Write(emsg);
                    Num = checkGenderNum(Console.ReadLine());
                }
            }
            return Num;
        }
        public double checkProfile(string Value)
        {
            double res = 999;
            bool boolCheck = double.TryParse(Value, out res);
            string emsg;
            if (!boolCheck)
            {
                emsg = "輸入錯誤，請重新輸入：";
                Console.Write(emsg);
                res = checkProfile(Console.ReadLine());
            }
            else
            {
                if (res<=0)
                {
                    emsg = "數值錯誤，請重新輸入：";
                    Console.Write(emsg);
                    res = checkProfile(Console.ReadLine());
                }
            }
            return res;
        }
       
    }
}
