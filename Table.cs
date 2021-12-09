﻿using System;
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
        public void MakeDayTable(List<int> indicateIndex)
        {
            Mode = 2;
            SetDishesIndex = -1;
            DataGridView.DataSource = null;
            var dataTable = CreateDataTable(indicateIndex);
            for (int i = 0; i < MainForm.File.SetDishes.Length; i++)
            {
                if (MainForm.File.SetDishes[i] == null) continue;

                var nr = dataTable.NewRow();
                nr.SetField(0, OperateTableFigure.TimingName[i]);
                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    var value = Math.Round(MainForm.File.SetDishes[i].SumNutrient[indicateIndex[j - 1]], MainForm.NutrientSigFigs[indicateIndex[j - 1]]);
                    nr.SetField(j, value);
                }
                dataTable.Rows.Add(nr);
            }
            DataGridView.DataSource = dataTable;
            DataGridView.Columns[0].Frozen = true;
            DataGridView.Columns[0].Width = 100;
            ColumnNotSort();
        }

        /// <summary>
        /// 一食の表を作る
        /// </summary>
        /// <param name="indicateIndex">表示する栄養素のデータベースのカラム上でのインデックス</param>
        public void MakeSetTable(int setdishesIndex,List<int> indicateIndex)
        {
            DataGridView.DataSource = null;
            Mode = 1;
            SetDishesIndex = setdishesIndex;
            var dataTable = CreateDataTable(indicateIndex);
            if (MainForm.File.FileType == (int)FileType.day)
            {
                dataTable.Columns[0].ColumnName = OperateTableFigure.TimingName[SetDishesIndex];
            }

            var meals = MainForm.File.SetDishes[SetDishesIndex].meals;

            for (int i = 0; i < meals.Count; i++)
            {
                var nr = dataTable.NewRow();

                nr.SetField(0, meals[i].MealName);
                for (int j = 1; j < dataTable.Columns.Count; j++)
                {
                    var value = Math.Round(meals[i].SumNutrient[indicateIndex[j - 1]], MainForm.NutrientSigFigs[indicateIndex[j - 1]]);//なんかぬるぽ
                    nr.SetField(j, value);
                }
                dataTable.Rows.Add(nr);
            }
            AddSetDishesSumRow(dataTable, indicateIndex);
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
                for (int j = 2; j < dataTable.Columns.Count; j++)
                {
                    nr.SetField(j, foods[i].DisplayNutrientValue[indicateIndex[j - 2]]);                    
                }
                dataTable.Rows.Add(nr);
            }
            dataTable.Rows.Add(dataTable.NewRow());

            var meal = MainForm.File.SetDishes[SetDishesIndex].meals[mealIndex];
            var mealsumrow = dataTable.NewRow();
            mealsumrow.SetField(0, meal.MealName);
            mealsumrow.SetField(1, "");
            for (int i = 2; i < dataTable.Columns.Count; i++)
            {
                var value = Math.Round(meal.SumNutrient[i - 2], MainForm.NutrientSigFigs[indicateIndex[i - 2]]);
                mealsumrow.SetField(i, value);
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
            }
            foreach (var p in pickup)
            {
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

            if (Mode == 0)
            {
                sumnr.SetField(1, " ");//食材の表の場合のみ存在する純使用量カラムは空にする
                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    var value = Math.Round(MainForm.File.SumNutrient[indicateIndex[i - 2]], MainForm.NutrientSigFigs[indicateIndex[i - 2]]);
                    sumnr.SetField(i, value);
                }
            }
            else
            {
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    var value = Math.Round(MainForm.File.SumNutrient[indicateIndex[i - 1]], MainForm.NutrientSigFigs[indicateIndex[i - 1]]);
                    sumnr.SetField(i, value);
                }
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
                columnCount += 1;//
                isDay = 1;
            }

            AddNewRow();
            if (MainForm.File.FileType == (int)FileType.day)
            {
                rtn[0][0] = "区分";
            }

            rtn[0][0 + isDay] = "献立名";
            rtn[0][1 + isDay] = "食材名";
            rtn[0][2 + isDay] = "純使用量(g)";

            for (int i = 0; i < pickup.Count; i++)
            {
                rtn[0][3 + i + isDay] = NutrientsForm.NutrientsName[pickup[i]];
            }

            ///セルの結合をしたかったため
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

                        for (int i = 0; i < pickup.Count; i++)
                        {
                            rtn.Last()[3 + isDay + i] = food.DisplayNutrientValue[pickup[i]];
                        }
                    }

                    AddNewRow();
                    rtn.Last()[1 + isDay] = "小計";//食材を全て記載したあと料理の全体のデータを載せる
                    for (int i = 0; i < pickup.Count; i++)
                    {
                        var value = Math.Round(MainForm.File.SetDishes[s].meals[m].SumNutrient[pickup[i]], MainForm.NutrientSigFigs[pickup[i]]).ToString();
                        rtn.Last()[3 + isDay + i] = value;
                    }
                }
                AddNewRow();
                rtn.Last()[1 + isDay] = "合計";//料理を全て記載したあと一食の全体のデータを載せる
                for (int i = 0; i < pickup.Count; i++)
                {
                    var value = Math.Round(MainForm.File.SetDishes[s].SumNutrient[pickup[i]], MainForm.NutrientSigFigs[pickup[i]]).ToString();
                    rtn.Last()[3 + isDay + i] = value;
                }

            }
            if (MainForm.File.FileType == (int)FileType.day)//ファイルのタイプが一日分なら、一日の合計を載せる
            {
                AddNewRow();
                rtn.Last()[1 + isDay] = "一日の合計";
                for (int i = 0; i < pickup.Count; i++)
                {
                    var value = Math.Round(MainForm.File.SumNutrient[pickup[i]], MainForm.NutrientSigFigs[i]).ToString();
                    rtn.Last()[3 + isDay + i] = value;
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