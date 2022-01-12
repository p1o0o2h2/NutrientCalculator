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

            var indicate = MainForm.File.Indicate_ReferenceNutrient.Select(ir => ir.ColumnIndex).ToList();
            if (MainForm.File.FileType == (int)FileType.day)
            {
                Table.MakeDayTable(indicate);
            }
            else
            {
                Table.MakeSetTable(0,indicate);
            }

            if(MainForm.File.Indicate_ReferenceNutrient.Count>0)
            {
                Figure.MakeCompareChart();
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
                var indicate = MainForm.File.Indicate_ReferenceNutrient.Select(ir => ir.ColumnIndex).ToList();
                if (MainForm.File.FileType == (int)FileType.day && Table.Mode == 1)
                {
                    Table.MakeDayTable(indicate);
                }
                else if (Table.Mode == 0)
                {
                    Table.MakeSetTable(Table.SetDishesIndex,indicate);
                }
            }

            void DisplayUnderTable()
            {
                var indicate = MainForm.File.Indicate_ReferenceNutrient.Select(ir => ir.ColumnIndex).ToList();
                if (Table.Mode==2)
                {
                    Table.MakeSetTable(rowIndex+1,indicate);
                }
                else if (Table.Mode == 1)
                {
                    Table.MakeMealTable(Table.SetDishesIndex,rowIndex,indicate);
                }
            }

            void MakeFoodsFigure()
            {
                int columnblank = 1;
                if (Table.Mode == 0)
                {
                    columnblank++;
                }
                var nutrientIndex = MainForm.File.Indicate_ReferenceNutrient.Select(ir=>ir.ColumnIndex).ToList()[columnIndex - columnblank];
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
            if (clickedIndex==-1)
            {
                Figure.MakeCompareChart();
            }
            else if(Figure.IsFoodFigure)
            {
                var indicate = MainForm.File.Indicate_ReferenceNutrient.Select(ir => ir.ColumnIndex).ToList();
                Table.MakeMealTable(FoodList[clickedIndex].Item2, FoodList[clickedIndex].Item3,indicate);
            }
            else
            {
                var indicate= MainForm.File.Indicate_ReferenceNutrient.Where(ir=>ir.ReferenceValue>0).Select(ir => ir.ColumnIndex).ToList();
                FoodList =Figure.MakeHighContentChart(indicate[indicate.Count-1-clickedIndex]);
            }
        }

        public List<List<string>>MakeOverrallTable()
        {
            var indicate = MainForm.File.Indicate_ReferenceNutrient.Select(ir => ir.ColumnIndex).ToList();
            return Table.MakeOverrallTable(indicate);
        }        
    }
}
