using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace えいようちゃん
{
    class OperateTableFigure
    {
        Table Table;
        Figure Figure;
       
        /// <summary>
        /// グラフに表示されている食品と区分インデックス、料理のインデックス
        /// </summary>
        List<(SetDish.Meal.Food, int,int)> FoodList;
        public static readonly List<string> TimingName = new List<string> { " ", "朝食", "昼食", "夕食", "間食" };

        public OperateTableFigure(DataGridView dataGridView,Chart chart)
        {
            Table = new Table(dataGridView);
            Figure = new Figure(chart);
        }

        /// <summary>
        /// デフォルトの表とグラフを表示する
        /// </summary>
        public void SetDefaltTableFigure()
        {
            Figure.ClearChart();
            if (MainForm.File == null || MainForm.File.SetDishes.All(sd=>sd==null))
            {
                Table.ClearTable();
                return;
            }
            var pickup = PickupIndicateNutrient();

            if (MainForm.File.FileType == (int)FileType.day)
            {
                Table.MakeDayTable(pickup);
            }
            else
            {
                Table.MakeSetTable(0,pickup);
            }

            if(pickup.Count>0)
            {
                Figure.MakeCompareChart(pickup);
            }
        }

        /// <summary>
        /// 表がクリックされたときの処理
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        public void TableClicked(int rowIndex,int columnIndex)
        {
            if (rowIndex == -1 && columnIndex == 0)//左上なら表を一階層戻す
            {
                ReturnUpperTable();
            }
            else if (columnIndex == 0)//表の左の列、選ばれた項目の詳細な表を表示
            {
                DisplayUnderTable();
            }
            else if (rowIndex == -1)//表の一番上の行＝栄養素を選択した場合、その栄養素を多く含む食品をグラフに並べる
            {
                MakeFoodsFigure();
            }
            
            void ReturnUpperTable()
            {
                if (MainForm.File.FileType == (int)FileType.day && Table.Mode == 1)
                {
                    Table.MakeDayTable(PickupIndicateNutrient());
                }
                else if (Table.Mode == 0)
                {
                    Table.MakeSetTable(Table.SetDishesIndex,PickupIndicateNutrient());
                }
            }

            void DisplayUnderTable()
            {
                if(Table.Mode==2)
                {
                    Table.MakeSetTable(rowIndex+1,PickupIndicateNutrient());
                }
                else if (Table.Mode == 1)
                {
                    Table.MakeMealTable(Table.SetDishesIndex,rowIndex,PickupIndicateNutrient());
                }
            }

            void MakeFoodsFigure()
            {
                int columnblank = 1;
                if (Table.Mode == 0)
                {
                    columnblank++;
                }
                var nutrientIndex = PickupIndicateNutrient()[columnIndex - columnblank];
                FoodList = Figure.MakeHighContentChart(nutrientIndex);
            }
        }

        /// <summary>
        /// グラフがクリックされたときの処理
        /// </summary>
        /// <param name="clickedIndex">クリックされたPoint</param>
        public void FigureCilcked(int clickedIndex)
        {
            if (MainForm.File.SumNutrient.Count == 0) return;
            if(clickedIndex==-1)
            {
                Figure.MakeCompareChart(PickupIndicateNutrient());
            }
            else if(Figure.IsFoodFigure)
            {
                Table.MakeMealTable(FoodList[clickedIndex].Item2, FoodList[clickedIndex].Item3, PickupIndicateNutrient());
            }
            else
            {
                FoodList=Figure.MakeHighContentChart(PickupIndicateNutrient()[clickedIndex]);
            }
        }

        public List<List<string>>MakeOverrallTable()
        {
            return Table.MakeOverrallTable(PickupIndicateNutrient());
        }

        /// <summary>
        /// 表示する栄養素のデータベースのカラム上でのインデックスを調べる
        /// </summary>
        /// <returns> 表示する栄養素のデータベースのカラム上でのインデックス</returns>
        List<int> PickupIndicateNutrient()
        {
            var pickup = new List<int>();
            for (int i = 0; i < MainForm.File.IndicateNutrient.Count; i++)
            {
                if (MainForm.File.IndicateNutrient[i] >= 0)
                {
                    pickup.Add(i);
                }
            }
            return pickup;
        }
    }
}
