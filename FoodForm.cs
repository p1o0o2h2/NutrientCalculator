using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace えいようちゃん
{
    /// <summary>
    /// 食品を選ぶ、重量を入力する
    /// </summary>
    public partial class FoodForm : Form
    {
        /// <summary>
        /// ジャンル、時間帯別料理名
        /// </summary>
        string[][] MealnameComboboxItems = new string[5][];
        /// <summary>
        /// 食品成分表の分類名
        /// </summary>
        string[] FoodCompositionGenre= {"穀類","いも及びでん粉類","砂糖及び甘味類","豆類","種実類", "野菜類", "果実類", "きのこ類", "藻類",
            "魚介類", "肉類", "卵類", "乳類", "油脂類","菓子類","し好飲料類","調味料及び香辛料類" ,"調理済み流通食品類"};

        /// <summary>
        /// 選択された食品の履歴(食品番号,食品名)
        /// </summary>
        List<(int, string)> LogItems = new List<(int, string)>();
        /// <summary>
        /// 右クリック時のメニュー
        /// </summary>
        ContextMenuStrip Context = new ContextMenuStrip();
        public FoodForm()
        {
            InitializeComponent();

            // MealnameComboboxItemsの初期化
            for (int i = 0; i < MainForm.File.SetDishes.Count(); i++)
            {
                if(MainForm.File.SetDishes[i]==null) continue;
                MealnameComboboxItems[i] = MainForm.File.SetDishes[i].meals.Select(m => m.MealName).ToArray();                
            }

            //TimingComboBox(時間帯選択ボックス)とMealNameCombobox(料理名選択ボックス)の初期化
            //時間帯選択は一日モード以外では不要なのでEnabled = falseにする
            if (MainForm.File.FileType!=(int)FileType.day)
            {
                TimingComboBox.Enabled = false;
                TimingComboBox.Text = "";
                MealnameComboboxItems[0] = MainForm.File.SetDishes[0].meals.Select(m => m.MealName).ToArray();
                MealNameComboBox.Items.AddRange(MealnameComboboxItems[0]);
            }
            //食品群選択ボックスの初期化
            FoodCompositionComboBox.Items.AddRange(FoodCompositionGenre);
                        
            //右クリックメニューの初期化
            Context.Items.Add("削除");
            Context.MouseClick += new MouseEventHandler(Context_Click);
        }

        /// <summary>
        /// 時間帯選択ボックスで指定された時間に合わせて料理選択ボックスの内容を初期化する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MealNameComboBox.Items.Clear();
            MealNameComboBox.Items.AddRange(MealnameComboboxItems[TimingComboBox.SelectedIndex+1]);
            MealNameComboBox.SelectedIndex = -1;
        }

        /// <summary>
        ///　選択された料理の食材をDataGridViewに表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MealNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = false;///"料理名を選択してください"を非表示
            NameQuantityView.Visible = true;
            ReflectNameQuantityView();
        }
        
        /// <summary>
        /// 選択された食品群に合わせて食品リストの内容を取得・初期化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoodCompositionCombobox_Selected(object sender, EventArgs e)
        {           
            if(FoodCompositionComboBox.SelectedIndex==-1) return;            
            FoodCompositionListBox.Items.Clear();
            FoodCompositionListBox.Items.AddRange(MainForm.FoodCompositionItems[FoodCompositionComboBox.SelectedIndex].Select(a => a.Item3).ToArray());
        }
         
        /// <summary>
        /// Enterキーが押された場合、食品を名前から検索する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoodCompositionComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            FoodCompositionListBox.Items.Clear();
            var text = FoodCompositionComboBox.Text;
            List<string> match = new List<string>();
            for (int i = 0; i < MainForm.FoodCompositionItems.Count; i++)
            {                
                //入力された文字列を正規の名前に含む食品をピックアップする
                match.AddRange(MainForm.FoodCompositionItems[i].Where(f => f.Item2.Contains((text))).Select(ff => ff.Item3).ToList());
            }
            FoodCompositionListBox.Items.AddRange(match.ToArray());
        }

        /// <summary>
        /// 食品群リストから指定された食品を料理に追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoodCompositionListBox_Selected(object sender, EventArgs e)
        {
            if(MealNameComboBox.Items.Count==0||MealNameComboBox.SelectedIndex==-1)//時間帯や料理が設定されていない場合
            {
                return;
            }
            else if(FoodCompositionListBox.SelectedIndex==-1)//選択が解除された場合
            {
                return;
            }

            var newfoodName = FoodCompositionListBox.SelectedItem.ToString();
            int identify=-1;
            if (FoodCompositionComboBox.SelectedIndex==-1&& FoodCompositionComboBox.Text!="")//検索結果から選択された場合
            {
                int i = 0;         
                while (identify==-1)//その食品の属する群を探す
                {
                    var foodData= MainForm.FoodCompositionItems[i].Where(f => f.Item3 == newfoodName).FirstOrDefault();
                    
                    if(foodData!=(0,"",""))
                    {
                        identify = foodData.Item1;
                    }
                    i++;
                }
            }
            else//食品類リストから選択された場合
            {                
                identify = MainForm.FoodCompositionItems[FoodCompositionComboBox.SelectedIndex][FoodCompositionListBox.SelectedIndex].Item1;                
            }
            List<string> values = ConnectSQL.GetFoodCompositionValue(identify);
            MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[MealNameComboBox.SelectedIndex].Foods.Add(new SetDish.Meal.Food(newfoodName, identify, values));

            NameQuantityView.Rows.Add(newfoodName, 0);//名前と重量
            FoodCompositionListBox.SelectedIndex = -1;
            LogItems.Add((identify, newfoodName));//履歴リストボックス
            LogListBox.Items.Add(newfoodName);
        }

        /// <summary>
        /// 履歴リストから指定された食品を料理に追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MealNameComboBox.Items.Count == 0 || MealNameComboBox.SelectedIndex == -1)//時間帯や料理が設定されていない場合
            {
                return;
            }
            else if (LogListBox.SelectedIndex == -1)//選択が解除された場合
            {
                return;
            }

            var identify_name = LogItems[LogListBox.SelectedIndex];
            List<string> values;

            try
            {
                values = ConnectSQL.GetFoodCompositionValue(identify_name.Item1);
            }
            catch
            {
                MessageBox.Show("食品成分表データの読み込みに失敗しました。\n開いているファイルを上書き保存してソフトを再起動してください");
                return;
            }

            MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[MealNameComboBox.SelectedIndex].Foods.Add(new SetDish.Meal.Food(identify_name.Item2, identify_name.Item1,values));
            LogListBox.SelectedIndex = -1;
            ReflectNameQuantityView();
        }

        /// <summary>
        /// 食品の使用量を入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameQuantityView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(NameQuantityView.RowCount==0||e.ColumnIndex==0) return;//最初の列(=タイトル)名前(ColumnIndex==0)の場合処理しない

            var qs = NameQuantityView[1, e.RowIndex].Value.ToString();

            if (!float.TryParse(qs ,out float quantity))
            {
                NameQuantityView[1, e.ColumnIndex].Value = "";
                MessageBox.Show("使用量は半角数字で記入してください");
                return;
            }
            var foods = MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[MealNameComboBox.SelectedIndex].Foods;

            if(foods.Count>e.RowIndex)
            {
                foods[e.RowIndex].Quantity = quantity;
            }           
        }

        /// <summary>
        /// 右クリックされた時メニューを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameQuantityView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex==-1) return;

            NameQuantityView.Rows[e.RowIndex].Selected = true;
            if (e.Button==MouseButtons.Right)
            {
                Context.Show(Cursor.Position);
            }
        }

        /// <summary>
        /// 料理から食材を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Context_Click(object sender, EventArgs e)
        {
            if(NameQuantityView.CurrentRow==null) return;//どこも選択されてない

            MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[MealNameComboBox.SelectedIndex].Foods.RemoveAt(NameQuantityView.CurrentRow.Index);
            ReflectNameQuantityView();
            Context.Hide();
        }

        /// <summary>
        /// フォームが閉じられたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var _=MainForm.UpdateMainFormAsync();
        }

        /// <summary>
        /// 変更をDataGridViewに反映させる
        /// </summary>
        void ReflectNameQuantityView()
        {
            NameQuantityView.Rows.Clear();
            SetDish.Meal selectedMeal = MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[MealNameComboBox.SelectedIndex];

            foreach (var food in selectedMeal.Foods)
            {
                NameQuantityView.Rows.Add(food.ShortName, food.Quantity);
            }
        }
    }   
}
