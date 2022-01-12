using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace えいようちゃん
{
    public class FoodCompositionItems
    {
        /// <summary>
        /// 食品成分表のデータ　key=分類 value(Item1=食品番号,Item2=食品名,Item3=短縮名)
        /// </summary>
        public Dictionary<int, List<(int, string,string)>> FoodItems = new Dictionary<int, List<(int, string,string)>>();
        public List<string> NutrientsNames = new List<string>();
        public List<int> NutrientsSigFigs = new List<int>();

        public FoodCompositionItems()
        {
            NutrientsNames = CreateNutrientNames();
            FoodItems = SetFoodCompositionItems();
            NutrientsSigFigs = GetNutrientSigFigs();      
        }

        //NutrientSigFigsの設定、2437 卯の花煎りが最も都合よいため読み込んで使う
        List<int> GetNutrientSigFigs()
        {
            var rtn = new List<int>();
            List<string> unohana = ConnectSQL.GetFoodCompositionValue(2437);
            foreach (var o in unohana)
            {
                var okara = TextMold.ReplaceKAKKO(o).Split('.');
                if (okara.Length == 2)
                {
                    rtn.Add(okara[1].Length);
                }
                else

                {
                    rtn.Add(0);
                }
            }
            return rtn;
        }


        List<string> CreateNutrientNames()
        {
            var rtn = new List<string>();
            var dataTabel = ConnectSQL.GetCompositionName();

            for (int i = 0; i < dataTabel.Rows.Count; i++)
            {
                var datarow = dataTabel.Rows[i].ItemArray;

                if (datarow[^1].GetType() == typeof(DBNull))//単位がない
                {
                    rtn.Add(datarow[0].ToString());
                }
                else if (datarow[2].GetType() == typeof(DBNull))//詳細2がない
                {
                    var dr1 = ConvertNO_NIYORU(datarow[1].ToString());
                    rtn.Add($"{dr1}({datarow[^2]})");
                }
                else if (datarow[3].GetType() == typeof(DBNull))//詳細3がない
                {
                    var dr2 = ConvertNO_NIYORU(datarow[2].ToString());
                    rtn.Add($"{dr2}({datarow[^2]})");
                }
                else
                {
                    var dr2 = ConvertNO_NIYORU(datarow[2].ToString());
                    var dr3 = ConvertNO_NIYORU(datarow[3].ToString().Replace(datarow[2].ToString(), ""));
                    rtn.Add($"{dr2}\n{dr3}({datarow[^2]})");
                }
            }

            return rtn;
            //string NewlineText(string s)
            //{
            //    int newlineNumber = 10;
            //    string rtn = s;

            //    if (s.Length > newlineNumber)
            //    {
            //        rtn = s.Insert(newlineNumber, "\n");
            //    }
            //    return rtn;
            //}

            string ConvertNO_NIYORU(string s)
            {
                string rtn = s;
                if (s.Contains("の"))
                {
                    rtn = s.Replace("の", "\n");
                }

                if (s.Contains("による"))
                {
                    var sp = s.Split("による");
                    if (sp[sp.Length - 1] == "")
                    {
                        rtn = s.Replace("による", "");
                    }
                    else
                    {
                        rtn = s.Replace("による", "\n");
                    }
                }
                return rtn;
            }
        }

        Dictionary<int, List<(int, string, string)>> SetFoodCompositionItems()
        {
            Dictionary<int, List<(int, string, string)>> rtn = new Dictionary<int, List<(int, string, string)>>();
            for (int i = 0; i < 18; i++)//食品分類は1から18までの18こ
            {
                rtn.Add(i, null);
                var names = ConnectSQL.GetFoodCompositionFoods(i + 1);//1はじまりなので1足す
                rtn[i] = names.Select(n => (n.Item1, n.Item2, TextMold.MakeShortFoodName(n.Item2))).ToList();
            }
            return rtn;
        }
    }
}
