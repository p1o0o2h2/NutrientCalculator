using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace えいようちゃん
{  
    /// <summary>
    /// 一食クラス
    /// </summary>
    public class SetDish
    {
        /// <summary>
        /// 一食を構成する料理
        /// </summary>
        public List<Meal> meals { get; set; } = new List<Meal>();
        
        /// <summary>
        /// 時間帯、EnumConstants.csのEnum TimingTypeを代入
        /// </summary>
        public int timingType { get; set; }
        /// <summary>
        /// 一食の栄養価の合計、順番はデータベース上の栄養素カラムと同じ
        /// </summary>
        public List<float> SumNutrient = new List<float>();
         
        /// <summary>
        /// 料理クラス
        /// </summary>
        public class Meal
        {
            /// <summary>
            /// 料理の名前
            /// </summary>
            public string MealName{ get; set; }
            /// <summary>
            /// 主食、主菜等ジャンル、EnumConstants.csのEnum  DishTypeを代入
            /// </summary>
            public int MealType { get; set; }
            /// <summary>
            /// 料理を構成する食品
            /// </summary>
            public List<Food> Foods { get; set; } = new List<Food>();
            /// <summary>
            /// 料理の栄養価の合計　順番はデータベース上の栄養素カラムと同じ
            /// </summary>
            public List<float> SumNutrient  = new List<float>();

            public Meal(string name, int mealtype)
            {
                this.MealName = name;
                this.MealType = mealtype;
            }

            public Meal(string name)
            {
                this.MealName = name;
                this.MealType = (int)DishType.none;
            }

            public Meal() { }

            /// <summary>
            /// 食品クラス
            /// </summary>
            public class Food
            {
                /// <summary>
                /// 食品の正式名称
                /// </summary>
                public string Name;
                /// <summary>
                /// アプリ内の短縮名
                /// </summary>
                [JsonIgnore]    
                public string ShortName { get { return TextMold.MakeShortFoodName(Name); } }
                /// <summary>
                /// 食品の食品番号
                /// </summary>
                public int Identify { get; set; }
                /// <summary>
                /// 純使用量(g)
                /// </summary>
                public float Quantity { get; set; }
                /// <summary>
                /// 表示上の栄養価　順番はデータベース上の栄養素カラムと同じ
                /// </summary>
                public List<string> DisplayNutrientValue = new List<string>();
                /// <summary>
                /// 正確な栄養価　順番はデータベース上の栄養素カラムと同じ
                /// </summary>
                internal List<float> CalclateNutrientValue = new List<float>();
                /// <summary>
                /// 食品成分表のデータ　順番はデータベース上の栄養素カラムと同じ
                /// </summary>
                public List<string> FoodCompositionValue = new List<string>();
                //依存関係、下処理の塩コショウとかを紐づけする,未実装
                public string DependencyFoodName;
                public int DependencyPercentage;

                public  Food(string name,int identify,List<string>fc)
                {
                    this.Name = name;
                    this.Identify = identify;
                    this.Quantity = 0;
                    this.FoodCompositionValue =fc;
                }

                public Food() { }
            }
        }       
    }      
}
