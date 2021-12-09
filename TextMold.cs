using System;

namespace えいようちゃん
{
    /// <summary>
    /// 名前の短縮や改行などのメソッド集
    /// </summary>
    public static class TextMold
    {
        /// <summary>
        /// 食品の短縮ネームを作成
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string MakeShortFoodName(string name)
        {
            char splitSpace;
            if (name.Contains('　'))
            {
                splitSpace = '　';
            }
            else if (name.Contains('　'))
            {
                splitSpace = '　';
            }
            else//スペースがない=短縮箇所なしなのでそのまま返す
            {
                return name;
            }

            var splitedNames = name.Split(splitSpace);

            //栽培条件等が記載されている時の"もの"を消す
            string rtnLast = "";
            if (splitedNames[^1].Contains('(') && splitedNames[^1].Contains("もの"))
            {
                rtnLast = splitedNames[^1].Replace("もの", "");
                splitedNames[^1] = "";
            }

            //[]肉'・'稲が含まれるなら普通にほしい
            //[]牛　ラム・マトンなら前は不要、中は必要
            //[]の前の前が<>なら前が必要
            //デフォ＝前も中も不要
            //前後で完全一致なら文字数が多い方をとる
            //調理済みは[2]以降→"料理"が含まれる
            if (splitedNames[0].Contains("料理"))
            {
                string rtn = "";
                for (int i = 2; i < splitedNames.Length; i++)
                {
                    if (rtn == splitedNames[i])
                    {
                        break;
                    }
                    rtn += splitedNames[i];
                }
                return rtn;
            }

            for (int i = 0; i < splitedNames.Length; i++)
            {
                if (splitedNames[i].Contains('(') || splitedNames[i].Contains('（'))//かっこの中はいらない
                {
                    splitedNames[i] = "";
                }

                if (splitedNames[i].Contains('<') || splitedNames[i].Contains('＜'))
                {
                    splitedNames[i] = "";
                }

                if (splitedNames[i].Contains('[') || splitedNames[i].Contains('［'))
                {
                    if ((splitedNames[i].Contains("牛") || splitedNames[i].Contains("ラム") || splitedNames[i].Contains("マトン")) && i > 0)
                    {
                        if (i != 0)
                        {
                            splitedNames[i - 1] = "";
                        }
                    }
                    else if (splitedNames[i].Contains("肉") || splitedNames[i].Contains("稲") || splitedNames[i].Contains("品"))
                    {
                        continue;
                    }
                    else
                    {
                        splitedNames[i] = "";
                        if (i != 0)
                        {
                            splitedNames[i - 1] = "";
                        }
                    }
                }

                if (i == splitedNames.Length - 1)
                {
                    break;
                }
                if (splitedNames[i].Length > splitedNames[i + 1].Length && splitedNames[i].Contains(splitedNames[i + 1]))
                {
                    splitedNames[i + 1] = "";
                }
                else if (splitedNames[i + 1].Length > splitedNames[i].Length && splitedNames[i] != "" && splitedNames[i + 1].Contains(splitedNames[i]))
                {
                    splitedNames[i] = splitedNames[i + 1];
                    splitedNames[i + 1] = "";
                }
            }
            return string.Join("", splitedNames) + rtnLast;
        }

        /// <summary>
        /// 各栄養素に合わせた有効数字に丸める。切り捨てると0になる場合、規則に沿った表示を設定する
        /// (例)小数第1位まで有効の場合、0.04=Tr、0.004=0
        /// </summary>
        /// <param name="raw">丸める前の値</param>
        /// <param name="sigfig">有効桁数(小数点以下)</param>
        /// <returns></returns>
        public static string MakeDisplayNutrientValue(float raw, int sigfig)
        {
            var value = Math.Round(raw, sigfig);
            if (value > 0)
            {
                return value.ToString();
            }

            var last = Math.Round(raw, sigfig + 1) * Math.Pow(10, sigfig + 1) % 10;
            if (last == 0)
            {
                return "0";
            }
            else//5がならない
            {
                return "Tr";
            }
        }

        /// <summary>
        /// グラフ用の改行
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NewLineFigureItemName(string name)
        {
            string rtn = "";
            foreach(var splitedName in name.Split('('))
            {
                var r = "";
                for(int i=0;i<splitedName.Length;i++)//単位を外す
                {
                    r += splitedName[i];
                    if(i%3==2)
                    {
                        r += '\n';
                    }
                }

                if(splitedName.Contains(')'))//単位を戻す
                {
                    rtn = $"{rtn}({r}\n";
                }
                else
                {
                    rtn += r+"\n";
                }
            }
            return rtn.TrimEnd();
        }

        /// <summary>
        /// 文字列からかっこを消す
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReplaceKAKKO(string s)
        {
            if (s != "(0)" && s.Contains("("))
            {
                return s.Replace("(", "").Replace(")", "");
            }
            return s;
        }
    }
}
