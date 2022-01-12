using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace えいようちゃん
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 栄養素のデータ
        /// </summary>
        public static FoodCompositionItems FoodCompositionItems;
        //checkboxの生成に時間がかかるのでフィールドに持たせている
        NutrientsForm NutrientsForm;
        static OperateTableFigure OperateTableFigure;
        //なぜかデザイナーのツールボックスに出ない
        Chart chart;
        /// <summary>
        /// アプリ内で一つのファイルのみ開き、各フォームで編集する形になっている
        /// アプリ起動中一つしか作りたくないのでstatic
        /// </summary>
        public static File File { get; private set; } = new File();

        public MainForm()
        {
            InitializeComponent();
            Task.Run(() =>
            {               
                try
                {
                    FoodCompositionItems = new FoodCompositionItems();
                    NutrientsForm = new NutrientsForm();
                }
                catch
                {
                    MessageBox.Show("食品成分表データの読み込みに失敗しました。ソフトを再起動してください");
                    return;
                }               
            });
        }
        
        /// <summary>
        /// ChartとTableの初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {            
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            tableLayoutPanel1.SetColumnSpan(chart, 2);
            OperateTableFigure = new OperateTableFigure(ResultDataGridView,chart);
            tableLayoutPanel1.Controls.Add(chart, 4, 1);
            chart.MouseClick += new MouseEventHandler(this.Chart_MouseClick);            
        }

        /// <summary>
        /// fileとTableとChartを最新のデータに更新する
        /// </summary>
        public static async Task UpdateMainFormAsync()
        {
            Task t =Task.Run(() => 
            {
                while (FoodCompositionItems.NutrientsSigFigs == null|| FoodCompositionItems.NutrientsSigFigs.Count==0)
                {
                    Task.Delay(1000);
                }
                File.CalculateSumNutrient(FoodCompositionItems.NutrientsSigFigs);
            });
            await t;
            OperateTableFigure.SetDefaltTableFigure();
        }
       
        /// <summary>
        /// ファイルの読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void InportFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JSONファイル|*.json";
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    File = Json.InportFile(dialog.FileName);
                    File.FilePath = dialog.FileName;
                    SetFoodCompsitions();
                    var _=UpdateMainFormAsync();
                    this.Text = File.FileName;                
                    this.Cursor = Cursors.Default;
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"ファイルが開けません\n{exception.Message}{exception.StackTrace}");
                }
            }

            ///Fileに書かれたFoodの食品番号からデータを取得する
            void SetFoodCompsitions()
            {
                for(int s=0;s<File.SetDishes.Length;s++)
                {
                    if(File.SetDishes[s]==null) continue;
                    for(int m =0;m<File.SetDishes[s].meals.Count;m++)
                    {
                        for(int f=0;f< File.SetDishes[s].meals[m].Foods.Count;f++)
                        {
                            var food = File.SetDishes[s].meals[m].Foods[f];
                            food.FoodCompositionValue.AddRange(ConnectSQL.GetFoodCompositionValue(food.Identify));
                            food.Name = food.FoodCompositionValue[(int)NutrientDataColumn.name-1];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 名前を付けて保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFileButton_Click(object sender, EventArgs e)
        {
            if (File.FilePath != "")
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    Json.ExportFile(File.FilePath);
                    this.Cursor = Cursors.Default;
                }
                catch
                {
                    MessageBox.Show("開いているファイルの保存に失敗しました");
                }
            }
            File = new File();
            this.Text = File.FileName;
            OperateTableFigure.SetDefaltTableFigure();

        }

        /// <summary>
        /// 保存　Fileにパスがない場合は名前を付けて保存、ある場合は上書き
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.FilePath == "")
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = "JSONファイル|*.json";
                    dialog.InitialDirectory = File.FilePath;
                    DialogResult dialogResult = dialog.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Json.ExportFile(dialog.FileName);
                        File.FilePath = dialog.FileName;
                        this.Cursor = Cursors.Default;
                        this.Text = File.FileName;
                    }
                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    Json.ExportFile(File.FilePath);
                    this.Cursor = Cursors.Default;
                }
                MessageBox.Show("保存しました");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"保存に失敗しました\n{exception.Message}");
            }
        }

        /// <summary>
        /// NutrientsFormを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NutrietsFormOpenButton_Click(object sender, EventArgs e)//
        {
            this.Cursor = Cursors.WaitCursor;
            while (true)
            {
                if(NutrientsForm != null)
                {
                    this.Cursor = Cursors.Default;
                    NutrientsForm.Show(); 
                    break;
                }                
            }
        }

        /// <summary>
        /// 基準値を設定するフォームを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferenceValueFormOpenButton_Click(object sender, EventArgs e)
        {            
            ReferenceValueForm form = new ReferenceValueForm();
            form.Show();
        }
        
        /// <summary>
        /// ファイルのタイプと種類、料理名を決めるフォームを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDishMealFormButton_Click(object sender, EventArgs e)
        {            
            SetDishMealForm form = new SetDishMealForm();
            form.Show();
        }

        private void FoodFormOpenButton_Click(object sender, EventArgs e)
        {
            if (File.FileType == (int)FileType.none)
            {
                MessageBox.Show("ファイルの種類を決めてください");
                return;
            }
            else if (File.SetDishes.All(sd => sd==null||sd.meals.Count==0))
            {
                MessageBox.Show("メニューを決めてください");
                return;
            }
            
            FoodForm foodForm = new FoodForm();
            foodForm.Show();
        }
        
        private void TableFigureCleanupButton_Click(object sender, EventArgs e)
        {
            OperateTableFigure.SetDefaltTableFigure();
        }

        private void ResultDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            while (NutrientsForm == null)//DataGridViewの前にNutrientsFormを初期化するので通ることはないが念のため
            {
                this.Cursor = Cursors.WaitCursor;
                Task.Delay(1000);
            }
            this.Cursor = Cursors.Default;
            OperateTableFigure.TableClicked(e.RowIndex,e.ColumnIndex);
        }

        private void ResultDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (ResultDataGridView.Columns.Count<2||ResultDataGridView.Columns[1].HeaderText != "純使用量\n(g)") return;

            var dgv = (DataGridView)sender;
            var changeCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var input = e.FormattedValue.ToString();

            if (changeCell.Value.ToString() == input) return;

            if (float.TryParse(input, out float q))
            {
                var food =SearchChangedFood();
                food.Quantity = q;
                var _ = UpdateMainFormAsync();
            }
            else
            {
                MessageBox.Show("半角数字で入力してください");
                dgv.CancelEdit();
                e.Cancel = true;
                return;
            }

            SetDish.Meal.Food SearchChangedFood()
            {
                List<string> TimingName = new List<string> { "", "朝食", "昼食", "夕食", "間食" };
                int setdishesIndex = 0;
                int mealIndex = 0;
                var mealName = ResultDataGridView.Columns[0].HeaderText;
                if (File.FileType == (int)FileType.day)
                {
                    var s = mealName.Split('・');
                    setdishesIndex = TimingName.IndexOf(s[0]);
                    mealName = s[1];
                }
                mealIndex = File.SetDishes[setdishesIndex].meals.IndexOf(File.SetDishes[setdishesIndex].meals
                    .Where(m => m.MealName == mealName).First());
                return File.SetDishes[setdishesIndex].meals[mealIndex].Foods[e.RowIndex];
            }
        }

        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            OperateTableFigure.FigureCilcked(chart.HitTest(e.X, e.Y).PointIndex);   
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excelファイル|*.xlsx";
            DialogResult dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {                
                try
                {
                    var a = OperateTableFigure.MakeOverrallTable();
                    Output.OutputNutrientValueForXlsx(a, dialog.FileName);

                    Process ps = new Process();
                    ps.StartInfo.FileName =dialog.FileName;
                    ps.StartInfo.UseShellExecute = true;
                    ps.Start();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }           
        }
    }
}