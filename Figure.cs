using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace えいようちゃん
{
    /// <summary>
    /// 表とグラフの描写
    /// </summary>
    public  class Figure
    {
        /// <summary>
        /// 操作するグラフ
        /// </summary>
        Chart Chart;
        /// <summary>
        /// 表示するグラフのタイプ　栄養素の目標値比較=false
        /// </summary>
        public bool IsFoodFigure;

        public Figure(Chart _chart)
        {
            Chart = _chart;
        }

        /// <summary>
        /// 目標値が設定されている場合、グラフを表示する
        /// </summary>
        public void MakeCompareChart(List<int>pickup)
        {
            if(MainForm.File==null||MainForm.File.SumNutrient.Count==0) return;
            if (!MainForm.File.IndicateNutrient.Any(ind=>ind>0)) return;//比較するものがあるか

            ClearChart();
            IsFoodFigure = false;
            pickup.Reverse();//上からエネルギー→廃棄率　にしたい
            var haveRef = pickup.Where(ii => MainForm.File.IndicateNutrient[ii] > 0).ToList();

            Chart.Series.Clear();
            Chart.ChartAreas[0].AxisY.Title = "充足率(%)";

            for (int i = 0; i < MainForm.File.SetDishes.Length; i++)
            {
                if (MainForm.File.SetDishes[i] == null || MainForm.File.SetDishes[i].meals.Count == 0) continue;
                Chart.Series.Add(new Series(OperateTableFigure.TimingName[i]));
                Chart.Series.Last().ChartType = SeriesChartType.StackedBar;
                Chart.Series.Last().LegendText = OperateTableFigure.TimingName[i];

                for (int j = 0; j < haveRef.Count; j++)
                {
                    int value = (int)(MainForm.File.SetDishes[i].SumNutrient[haveRef[j]] / MainForm.File.IndicateNutrient[haveRef[j]] * 100);
                    var name = TextMold.NewLineFigureItemName(NutrientsForm.NutrientsName[haveRef[j]]);
                    Chart.Series.Last().Points.AddXY(name, value);
                }
            }
        }

        /// <summary>
        /// 指定の栄養素を多く含む食品のグラフをつくる
        /// </summary>
        /// <param name="nutrientIndex">指定の栄養素</param>
        /// <returns>グラフに載せた食品とそれを含む区分、料理のIndex</returns>
        public List<(SetDish.Meal.Food, int,int)> MakeHighContentChart(int nutrientIndex)
        {
            ClearChart();
            Chart.Series.Add(new Series());
            Chart.Series[0].ChartType = SeriesChartType.StackedBar;
            Chart.ChartAreas[0].AxisY.Title = NutrientsForm.NutrientsName[nutrientIndex];

            IsFoodFigure =true;
            var pickupFood_Index = new List<(SetDish.Meal.Food, int,int)>();

            for (int s = 0; s < MainForm.File.SetDishes.Length; s++)
            {
                if (MainForm.File.SetDishes[s] == null) continue;
                for (int m = 0; m < MainForm.File.SetDishes[s].meals.Count; m++)
                {
                    MainForm.File.SetDishes[s].meals[m].Foods.ForEach(f => pickupFood_Index.Add((f, s,m)));
                }
            }

            var foodList = pickupFood_Index.OrderByDescending(f => f.Item1.CalclateNutrientValue[nutrientIndex]).ToList();
            if (foodList.Count>9)
            {
                foodList.RemoveRange(9, foodList.Count - 9);
            }
            foodList.Reverse();

            for (int i = 0; i < 9; i++)
            {
                if (foodList.Count == i) break;
                var text = TextMold.NewLineFigureItemName(foodList[i].Item1.ShortName);

                if(text.Length>6)
                {
                    text = text.Substring(0, 6);
                }
                Chart.Series[0].Points.AddXY(text, foodList[i].Item1.CalclateNutrientValue[nutrientIndex]);
            }
            return foodList;
        }

        public void ClearChart()
        {
            Chart.Series.Clear();
            Chart.ChartAreas.Clear();
            Chart.ChartAreas.Add(new ChartArea());
            Chart.ChartAreas[0].AxisX.LabelAutoFitMaxFontSize = 7;
        }
    }
}
