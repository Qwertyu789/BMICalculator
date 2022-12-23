using System;
using System.Linq;

namespace prjBMICalculator.BMIClass
{
    /// <summary>
    /// BMI評級。
    /// </summary>
    enum EnumBMIvalue
    {
        太胖 = 0,
        適中 = 1,
        太瘦 = 2,
    }
    /// <summary>
    /// 性別列表。
    /// </summary>
    enum EnumGender
    {
        男性 = 0,
        女性 = 1,
    }
    /// <summary>
    /// 物種列表。
    /// </summary>
   enum EnumSpecies
    {
        人類=0,
    }
    abstract class ProfileInfo
    {
        #region Property
        protected string _Name;
        public string Name
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_Name))
                {
                    return "沒有設定姓名";
                }
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        protected double _Height_cm;
        public double Height_cm
        {
            get { return _Height_cm; }
            set { _Height_cm = value; }
        }
        protected double _Weight;
        public double Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        protected int _Gender;
        public int GenderNum
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        /// <summary>
        /// 取得性別中文。
        /// </summary>
        public string Gender_CHT()
        {
            if (Enum.IsDefined(typeof(EnumGender), _Gender))
            {
                return Enum.GetName(typeof(EnumGender), _Gender);
            }
            else
            {
                return "性別錯誤，請檢查性別編號。";
            }
        }
        #endregion


        #region BMI_Area
        /// <summary>
        /// 計算BMI。
        /// </summary>
        public virtual double BMI()
        {
            return Math.Round(_Weight / Math.Pow((_Height_cm) * 0.01, 2), 2);
        }
        // 設定 BMI 標準
        private double[] _BMIIndicator;
        protected double[] BMIIndicator
        {
            get { return _BMIIndicator; }
            set { _BMIIndicator = value.OrderByDescending(b => b).Take(Enum.GetNames(typeof(EnumBMIvalue)).Length - 1).ToArray(); }
        }
        /// <summary>
        /// 取得BMI評語。
        /// </summary>
        public string getBMIvalue()
        {
            double _BMI = this.BMI();
            if (_Height_cm == 0 || _Weight == 0)
            {
                _BMI = 0;
            }
            int bmiValueNum = 99;
            string res = "";

            //BMI Rating
            try
            {
                //先檢查過瘦(最簡易條件)
                if (_BMI == 0)
                {
                    res = "BMI 異常，請確認身高/體重沒有錯誤。";
                }
                else if (_BMI < _BMIIndicator.Last() && _BMI > 0)
                {
                    bmiValueNum = Enum.GetValues(typeof(EnumBMIvalue)).Length - 1;
                }
                else
                {
                    //迴圈比對是否有大於等於BMI標準
                    for (int idx = 0; idx < Enum.GetValues(typeof(EnumBMIvalue)).Length - 1; idx++)
                    {
                        if (_BMI >= _BMIIndicator[idx])
                        {
                            bmiValueNum = idx;
                            break;
                        }
                    }
                }
            }
            catch
            {
                res = "BMI 評比出錯，請檢查 BMI Rating 。";
            }

            //Return
            if (Enum.IsDefined(typeof(EnumBMIvalue), bmiValueNum))
            {
                res = Enum.GetName(typeof(EnumBMIvalue), bmiValueNum);
            }

            return res;
        }
        #endregion

        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine("===基本資料===");
            Console.WriteLine("姓名：" + this.Name);
            Console.WriteLine("性別：" + this.Gender_CHT());
            Console.WriteLine("身高：" + this.Height_cm + "公分");
            Console.WriteLine("體重：" + this.Weight + "公斤");
            Console.WriteLine("=====BMI=====");
            Console.WriteLine("BMI：" + this.BMI());
            Console.WriteLine("BMI評語：" + this.getBMIvalue());
            Console.WriteLine();
        }
    }
    class ProfileHelper
    {
        public string getSpeciesList()
        {
            int counter = 0;
            string res = "";
            foreach (var item in Enum.GetNames(typeof(EnumSpecies)))
            {
                res += $"{ counter}. { item } ";
                counter += 1;
            }
            return res;
        }
        public string getGenderList()
        {
            int counter = 0;
            string res = "";
            foreach (var item in Enum.GetNames(typeof(EnumGender)))
            {
                res += $"{ counter}. { item } ";
                counter += 1;
            }
            return res;
        }

    }
}
