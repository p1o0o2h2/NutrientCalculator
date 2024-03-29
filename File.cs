﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace えいようちゃん
{
    /// <summary>
    /// 記録クラス
    /// </summary>
    public class File
    {
        /// <summary>
        ///  [0]=フリー、一食、一人前 [1]朝食[2]昼食[3]夕食[4]間食
        /// </summary>
        public SetDish[] SetDishes { get; set; } = new SetDish[5];
        public int FileType { get; set; } = -2;
        public List<NutrientColumn> Indicate_ReferenceNutrient { get; set; } = new List<NutrientColumn>();
        public int ServePeople { get; set; } = 1;
        public string FilePath = "";
        [JsonIgnore]
        public string FileName{ get {return FilePath.Split('\\').Last().Replace(".json", "");} }
        public List<float> SumNutrient = new List<float>();
        public bool IsDisplayMaterialQuanatity { get; set; } = false;
       
        /// <summary>
        /// 食品成分表のデータを分量から栄養価を計算する
        /// </summary>
        public void CalculateSumNutrient(List<int> nutrientSigFigs)
        {
            foreach (var sd in SetDishes)
            {
                if(sd==null) continue;
                foreach (var meal in sd.meals)
                {
                    //食品ごとの栄養価を算出
                    meal.Foods.ForEach(m => SetCalclateNutrientValue(m));
                    //料理の栄養価を算出
                    meal.SumNutrient = CaluclateSum(meal.Foods.Select(m => m.CalclateNutrientValue).ToList());
                }
                //一食の栄養価を算出
                sd.SumNutrient = CaluclateSum(sd.meals.Where(s => s != null).Select(s => s.SumNutrient).ToList());//一食の値                
            }
            //全体の栄養価を算出
            SumNutrient = CaluclateSum(SetDishes.Where(s => s != null).Select(s => s.SumNutrient).ToList());

            //食品の栄養価を算出
            void SetCalclateNutrientValue(SetDish.Meal.Food food)
            {
                while(food.FoodCompositionValue.Count>food.CalclateNutrientValue.Count)
                {
                    food.CalclateNutrientValue.Add(0);
                    food.DisplayNutrientValue.Add(" ");
                }

                for (int i = 0; i < food.FoodCompositionValue.Count; i++)
                {
                    string f = food.FoodCompositionValue[i];
                    string fc = TextMold.ReplaceKAKKO(f);
                    
                    if(i==(int)NutrientDataColumn.refuse-1)
                    {
                        food.CalclateNutrientValue[i]=0;
                        food.DisplayNutrientValue[i] = f;
                    }
                    else if (float.TryParse(fc, out float value))//データが数字かどうか
                    {
                        //一人前あたりの重量/100g(栄養価はそれぞれ100gあたりのデータ)
                        float v = value*food.Quantity / MainForm.File.ServePeople / 100;                       
                        food.CalclateNutrientValue[i] = v;                       
                        food.DisplayNutrientValue[i]=TextMold.MakeDisplayNutrientValue(v,nutrientSigFigs[i]);
                    }
                    else if (fc == "Tr" || fc == "-" || fc == "(0)")//Tr=微量、-=なし、(0)=測ってないけど理論上0,そのまま書かないといけない
                    {
                        food.CalclateNutrientValue[i] = 0;
                        food.DisplayNutrientValue[i] = fc;
                    }
                    else//名前とか、栄養素じゃないもの
                    {
                        food.CalclateNutrientValue[i] = -1;
                        food.DisplayNutrientValue[i] = fc;
                    }
                }
            }

            ///引数=足すもの全部
            List<float> CaluclateSum(List<List<float>> value)
            {
                if (value.Count == 0)
                {
                    return new List<float> { };
                }

                float[] rtn = new float[value.Max(v => v.Count)];

                for (int i = 0; i < value.Count; i++)
                {
                    for (int j = 0; j < value[i].Count; j++)
                    {
                        rtn[j] += value[i][j];
                    }
                }
                return rtn.ToList();
            }
        }       
    }
}
