using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace えいようちゃん
{
    /// <summary>
    /// 表とグラフを描写する
    /// </summary>
    public  class Table
    {
        /// <summary>
        /// 操作するDataGridView
        /// </summary>
        DataGridView DataGridView;
        /// <summary>
        ///  Tableの階層、一日=2,一食=1,料理=0
        /// </summary>
        public int Mode = -1;
        /// <summary>
        /// 現在表示している一食のインデックス
        /// </summary>
        public int SetDishesIndex = 0;

        public Table(DataGridView _dataGridView)
        {           
            DataGridView = _dataGridView;
        }
            
        /// <summary>
        /// 一日の表をつくる
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="indicateIndex">表示する栄養素</param>
        public void MakeDayTable(List<int> pickup)
        {
            Mode = 2;
            SetDishesIndex = -1;
            DataGridView.DataSource = null;
            var dataTable = CreateDataTable(pickup);
            var setdishNames = new List<string> {"", "朝食", "昼食", "夕食", "間食" };
            for (int i = 1; i < MainForm.File.SetDishes.Length; i++)
            {
                int columnIndex = 1;
                int pickupIndex = 0;
                var nr = dataTable.NewRow();
                while (columnIndex < dataTable.Columns.Count)
                {
                    nr.SetField(0, setdishNames[i]);
                    if (pickup[pickupIndex] == (int)NutrientDataColumn.refuse - 1)
                    {
                        pickupIndex++;
                        continue;
                    }
                    var value = Math.Round(MainForm.File.SetDishes[i].SumNutrient[pickup[pickupIndex]], MainForm.NutrientSigFigs[pickup[pickupIndex]]);
                    nr.SetField(columnIndex, value);
                    pickupIndex++;
                    columnIndex++;
                }
                dataTable.Rows.Add(nr);
            }

            var sumnr = dataTable.NewRow();
            sumnr.SetField(0, "合計");
            for (int i = 0; i < pickup.Count; i++)
            {               
                var value = Math.Round(MainForm.File.SumNutrient[pickup[i]], MainForm.NutrientSigFigs[pickup[i]]);
                sumnr.SetField(i+1, value);
            }
            dataTable.Rows.Add(sumnr);

            DataGridView.DataSource = dataTable;
            DataGridView.Columns[0].Frozen = true;
            DataGridView.Columns[0].Width = 100;
            ColumnNotSort();
        }

        /// <summary>
        /// 一食の表を作る
        /// </summary>
        /// <param name="indicateIndex">表示する栄養素のデータベースのカラム上でのインデックス</param>
        public void MakeSetTable(int setdishesIndex,List<int> pickup)
        {
            DataGridView.DataSource = null;
            Mode = 1;
            SetDishesIndex = setdishesIndex;
            var dataTable = CreateDataTable(pickup);
            if (MainForm.File.FileType == (int)FileType.day)
            {
                dataTable.Columns[0].ColumnName = OperateTableFigure.TimingName[SetDishesIndex];
            }

            var meals = MainForm.File.SetDishes[SetDishesIndex].meals;

            for (int i = 0; i < meals.Count; i++)
            {
                var nr = dataTable.NewRow();

                nr.SetField(0, meals[i].MealName);
                int columnIndex = 1;
                int pickupIndex = 0;
                while (columnIndex < dataTable.Columns.Count)
                {
                    if (pickup[pickupIndex] == (int)NutrientDataColumn.refuse - 1)
                    {
                        pickupIndex++;
                        continue;
                    }
                    var value = Math.Round(meals[i].SumNutrient[pickup[pickupIndex]], MainForm.NutrientSigFigs[pickup[pickupIndex]]);
                    nr.SetField(columnIndex, value);
                    pickupIndex++;
                    columnIndex++;
                }                
                dataTable.Rows.Add(nr);
            }
            AddSetDishesSumRow(dataTable, pickup);
            DataGridView.DataSource = dataTable;
            DataGridView.Columns[0].Frozen = true;
            ColumnNotSort();
        }

        /// <summary>
        /// 一つの料理の表をつくる、他と違って分量付き
        /// </summary>
        /// <param name="indicateIndex">表示する栄養素のデータベースのカラム上でのインデックス</param>
        public void MakeMealTable(int setdishesIndex,int mealIndex,List<int> indicateIndex)
        {
            DataGridView.DataSource = null;
            Mode = 0;
            SetDishesIndex = setdishesIndex;

            //表の左上(1列目)のカラム名を設定(朝食・ワッフル)
            var dataTable = CreateDataTable(indicateIndex);
            string columnName = "";
            if (MainForm.File.FileType == (int)FileType.day)
            {
                columnName = OperateTableFigure.TimingName[SetDishesIndex] + "・";
            }
            dataTable.Columns[0].ColumnName = columnName + MainForm.File.SetDishes[SetDishesIndex].meals[mealIndex].MealName;

            var foods = MainForm.File.SetDishes[SetDishesIndex].meals[mealIndex].Foods;
            for (int i = 0; i < foods.Count; i++)
            {
                var nr = dataTable.NewRow();
                nr.SetField(0, foods[i].ShortName);
                nr.SetField(1, foods[i].Quantity);

                int nutrientColumn = 2;
                if(MainForm.File.IsDisplayMaterialQuanatity)
                {
                    nr.SetField(2, foods[i].ContainLoss);
                    nutrientColumn++;
                }

                for (int j = nutrientColumn; j < dataTable.Columns.Count; j++)
                {
                    nr.SetField(j, foods[i].DisplayNutrientValue[indicateIndex[j - nutrientColumn]]);              
                }
                dataTable.Rows.Add(nr);
            }
            dataTable.Rows.Add(dataTable.NewRow());//合計行との間に空白を入れる

            var meal = MainForm.File.SetDishes[SetDishesIndex].meals[mealIndex];
            var mealsumrow = dataTable.NewRow();
            mealsumrow.SetField(0, meal.MealName);
            mealsumrow.SetField(1, "");

            int columnIndex = 0;
            if (MainForm.File.IsDisplayMaterialQuanatity)
            {
                mealsumrow.SetField(columnIndex, "");
                columnIndex++;
            }

            for (int i = 0; i < indicateIndex.Count; i++)
            {
                if (indicateIndex[i] == (int)NutrientDataColumn.refuse - 1)
                {
                    if (Mode == 0)
                    {
                        mealsumrow.SetField(columnIndex, "");
                        columnIndex++;
                    }
                    continue;
                }
                var value = Math.Round(MainForm.File.SumNutrient[indicateIndex[i]], MainForm.NutrientSigFigs[indicateIndex[i]]);
                mealsumrow.SetField(columnIndex, value);
                columnIndex++;
            }
            AddSetDishesSumRow(dataTable, indicateIndex);

            DataGridView.DataSource = dataTable;
            DataGridView.Columns[1].Frozen = true;
            DataGridView.ReadOnly = false;

            for (int i = 0; i < DataGridView.Columns.Count; i++)
            {
                if (i != 1)
                    DataGridView.Columns[i].ReadOnly = true;
            }
            ColumnNotSort();
        }
        
        /// <summary>
        /// DataTable作成
        /// </summary>
        /// <param name="pickup"></param>
        /// <returns></returns>
        DataTable CreateDataTable(List<int> pickup)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn(" "));
            if (Mode == 0)//料理に使用する食材の表のみ使用量のカラムを持つ
            {
                dataTable.Columns.Add(new DataColumn("純使用量\n(g)"));
                if(MainForm.File.IsDisplayMaterialQuanatity)
                {
                    dataTable.Columns.Add(new DataColumn("粗使用量\n(g)"));
                }
            }

            foreach (var p in pickup)
            {
                if(p==(int)NutrientDataColumn.refuse-1&&Mode!=0)
                {
                    continue;
                }               
                var name = string.Join("\n(", NutrientsForm.NutrientsName[p].Split("("));
                dataTable.Columns.Add(new DataColumn(name));
            }
            return dataTable;
        }

        /// <summary>
        /// DataTableに一食の栄養素の合計行を追加する
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="indicateIndex"></param>
        void AddSetDishesSumRow(DataTable dt, List<int> indicateIndex)
        {
            var sumnr = dt.NewRow();
            sumnr.SetField(0, "合計");
            int columnIndex = 1;

            if (Mode == 0)
            {
                sumnr.SetField(1, " ");//純使用量カラムは空(食材の表の場合のみ存在)
                columnIndex++;
                
                if(MainForm.File.IsDisplayMaterialQuanatity)
                {
                    sumnr.SetField(columnIndex, "");
                    columnIndex++;
                }
            }
                        
            for (int i = 0; i < indicateIndex.Count; i++)
            {
                if (indicateIndex[i]==(int)NutrientDataColumn.refuse-1)
                {
                    if(Mode == 0)
                    {
                        sumnr.SetField(columnIndex, "");
                        columnIndex++;
                    }
                    continue;
                }
                var value = Math.Round(MainForm.File.SumNutrient[indicateIndex[i]], MainForm.NutrientSigFigs[indicateIndex[i]]);
                sumnr.SetField(columnIndex, value);
                columnIndex++;
            }
            dt.Rows.Add(sumnr);
        }

        /// <summary>
        /// カラムのソート禁止を設定する
        /// </summary>
        void ColumnNotSort()
        {
            foreach (DataGridViewColumn  column in DataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 出力用の表をつくる→ここでいいの？
        /// </summary>
        /// <returns>[横列[縦列]]、セルの結合の関係上左上を始点に上から下→一つ右のカラム、という形式にしている</returns>
        public List<List<string>> MakeOverrallTable(List<int> pickup)
        {
            List<List<string>> rtn = new List<List<string>>();
            int columnCount = pickup.Count + 3;//各栄養素と献立名、食材名、純使用量(g)

            //一日分なら区分(朝食、昼食…)の列が増える
            int isDay = 0;
            if (MainForm.File.FileType == (int)FileType.day)
            {
                columnCount ++;//
                isDay = 1;
            }
            if (MainForm.File.IsDisplayMaterialQuanatity)
            {
                columnCount++;
            }

            AddNewRow();
            if (MainForm.File.FileType == (int)FileType.day)
            {
                rtn[0][0] = "区分";
            }
            rtn[0][0 + isDay] = "献立名";
            rtn[0][1 + isDay] = "食材名";
            rtn[0][2 + isDay] = "純使用量(g)";

            int columnIndex = 3;
            if(MainForm.File.IsDisplayMaterialQuanatity)
            {
                rtn[0][columnIndex + isDay] = "粗使用量(g)";
                columnIndex=4;
            }

            for (int i = 0; i < pickup.Count; i++)
            {
                rtn[0][columnIndex + i + isDay] = NutrientsForm.NutrientsName[pickup[i]];
            }

            ///セルの結合をしたかったため縦に
            for (int s = 0; s < MainForm.File.SetDishes.Length; s++)//全体
            {
                if (MainForm.File.SetDishes[s] == null) continue;
                for (int m = 0; m < MainForm.File.SetDishes[s].meals.Count; m++)//一食
                {
                    for (int f = 0; f < MainForm.File.SetDishes[s].meals[m].Foods.Count; f++)//一品
                    {
                        AddNewRow();
                        if (f == 0)//その料理の一番上の行にだけ料理名を入れる
                        {
                            rtn.Last()[0 + isDay] = MainForm.File.SetDishes[s].meals[m].MealName;
                        }
                        var food = MainForm.File.SetDishes[s].meals[m].Foods[f];
                        rtn.Last()[1 + isDay] = food.Name;
                        rtn.Last()[2 + isDay] = (food.Quantity / MainForm.File.ServePeople).ToString();//表にするとき、分量は一人前

                        if (columnIndex==4)
                        {
                            rtn.Last()[3 + isDay] = food.ContainLoss.ToString();
                        }

                        for (int i = 0; i < pickup.Count; i++)
                        {
                            rtn.Last()[columnIndex + isDay + i] = food.DisplayNutrientValue[pickup[i]];
                        }
                    }

                    AddNewRow();
                    rtn.Last()[1 + isDay] = "小計";//食材を全て記載したあと料理の全体のデータを載せる
                    for (int i = 0; i < pickup.Count; i++)
                    {
                        if(pickup[i]==(int)NutrientDataColumn.refuse-1)
                        {
                            continue;
                        }
                        var value = Math.Round(MainForm.File.SetDishes[s].meals[m].SumNutrient[pickup[i]], MainForm.NutrientSigFigs[pickup[i]]).ToString();
                        rtn.Last()[columnIndex + isDay + i] = value;
                    }
                }
                AddNewRow();
                rtn.Last()[1 + isDay] = "合計";//料理を全て記載したあと一食の全体のデータを載せる
                for (int i = 0; i < pickup.Count; i++)
                {
                    if (pickup[i] == (int)NutrientDataColumn.refuse - 1)
                    {
                        continue;
                    }
                    var value = Math.Round(MainForm.File.SetDishes[s].SumNutrient[pickup[i]], MainForm.NutrientSigFigs[pickup[i]]).ToString();
                    rtn.Last()[columnIndex+ isDay + i] = value;
                }

            }
            if (MainForm.File.FileType == (int)FileType.day)//ファイルのタイプが一日分なら、一日の合計を載せる
            {
                AddNewRow();
                rtn.Last()[1 + isDay] = "一日の合計";
                for (int i = 0; i < pickup.Count; i++)
                {
                    if (pickup[i] == (int)NutrientDataColumn.refuse - 1)
                    {
                        continue;
                    }
                    var value = Math.Round(MainForm.File.SumNutrient[pickup[i]], MainForm.NutrientSigFigs[i]).ToString();
                    rtn.Last()[columnIndex + isDay + i] = value;
                }
            }
            return rtn;

            void AddNewRow()
            {
                var row = new List<string>();
                while (row.Count < columnCount)
                {
                    row.Add("");
                }
                rtn.Add(row);
            }
        }
    }   
}
