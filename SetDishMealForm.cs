using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace えいようちゃん
{
    /// <summary>
    /// ファイルのタイプ、時間帯、料理名などを設定する
    /// </summary>
    public partial class SetDishMealForm : Form
    {
        string[] FileTypeItems = new string[4] {"フリー","一食","一日","一人分"};
        string[] MealTypeItems = new string[5] { "", "主食", "汁物", "主菜", "副菜" };
        string[] TimingTypeItems = new string[4] { "朝食", "昼食", "夕食", "間食" };
        List<ListBox> listboxes;
        List<ListBox> oneday;

        public SetDishMealForm()
        {
            InitializeComponent();
            TypeSelectComboBox.Items.AddRange(FileTypeItems);
            TimingComboBox.Items.AddRange(TimingTypeItems);
            MealTypeBox.Items.AddRange(MealTypeItems);
            listboxes = new List<ListBox> {StanderdListBox,BreakFastListBox, LunchListBox, DinnerListBox, SnackListBox };
            oneday = new List<ListBox> { BreakFastListBox, LunchListBox, DinnerListBox, SnackListBox };
        }

        /// <summary>
        /// 現在のファイル内容の反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTypeForm_Load(object sender, EventArgs e)
        {
            if (MainForm.File.FileType == -2) return;//デフォルトのまま

            TypeSelectComboBox.SelectedIndex = MainForm.File.FileType;
            ServePeopleTextbox.Text = MainForm.File.ServePeople.ToString();
            ReflectSetDishes();
        }

        /// <summary>
        /// ファイルのタイプを設定し、それに合わせた画面をつくる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeSelectCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisualChange();
            int befortype = MainForm.File.FileType;
            
            if(befortype==-1||befortype==TypeSelectComboBox.SelectedIndex) return;

            if (befortype == (int)FileType.day)
            {
                for (int i = 1; i < MainForm.File.SetDishes.Length; i++)
                {
                    if(MainForm.File.SetDishes[i]==null)
                    {
                        continue;
                    }
                    MainForm.File.SetDishes[0].meals.AddRange(MainForm.File.SetDishes[i].meals);
                    MainForm.File.SetDishes[i] = null;
                }    
            }
            MainForm.File.FileType = TypeSelectComboBox.SelectedIndex;
            ReflectSetDishes();
            
            ///ファイルのタイプに合わせた画面をつくる、入力不必要なものを隠す
            void VisualChange()
            {
                List<Control> variebleControls = new List<Control>
            {
                StanderdListBox,
                BreakFastLabel,
                BreakFastListBox,
                LunchLabel,
                LunchListBox,
                DinnerLabel,
                DinnerListBox,
                SnackLabel,
                SnackListBox,
                CutLabel1,
                CutLabel2,
                ServePeopleTextbox,
                NameTextBox,
                NameLabel,
                MealTypeBox,
                MealTypeLabel,
                SetDishButton,
                SelectliftButton,
                TimingComboBox,
                TimingLabel,
                DeleteButton
            };

                variebleControls.ForEach(v => v.Visible = false);
                NameTextBox.Text = "";
                List<Label> onedayLabel = new List<Label> { BreakFastLabel, LunchLabel, DinnerLabel, SnackLabel };
                switch (TypeSelectComboBox.SelectedIndex)
                {
                    case (int)FileType.free:
                        StanderdListBox.Visible = true;
                        NameTextBox.Visible = true;
                        NameLabel.Visible = true;
                        SetDishButton.Visible = true;
                        SelectliftButton.Visible = true;
                        DeleteButton.Visible = true;
                        oneday.ForEach(o => o.SelectedIndex = -1);
                        break;
                    case (int)FileType.set:
                        StanderdListBox.Visible = true;
                        //MealTypeBox.Visible = true;
                        //MealTypeLabel.Visible = true;
                        NameTextBox.Visible = true;
                        NameLabel.Visible = true;
                        SetDishButton.Visible = true;
                        SelectliftButton.Visible = true;
                        DeleteButton.Visible = true;
                        oneday.ForEach(o => o.SelectedIndex = -1);
                        break;
                    case (int)FileType.day:
                        oneday.ForEach(o => o.Visible = true);
                        onedayLabel.ForEach(o => o.Visible = true);
                        StanderdListBox.SelectedIndex = -1;
                        //MealTypeBox.Visible = true;
                        //MealTypeLabel.Visible = true;
                        TimingLabel.Visible = true;
                        TimingComboBox.Visible = true;
                        NameTextBox.Visible = true;
                        NameLabel.Visible = true;
                        SetDishButton.Visible = true;
                        SelectliftButton.Visible = true;
                        DeleteButton.Visible = true;
                        break;
                    case (int)FileType.serve:
                        StanderdListBox.Visible = true;
                        CutLabel1.Visible = true;
                        CutLabel2.Visible = true;
                        ServePeopleTextbox.Visible = true;
                        NameTextBox.Visible = true;
                        NameLabel.Visible = true;
                        SetDishButton.Visible = true;
                        SelectliftButton.Visible = true;
                        DeleteButton.Visible = true;
                        oneday.ForEach(o => o.SelectedIndex = -1);
                        break;
                    default:
                        break;
                }
            }            
        }

        /// <summary>
        /// 選択されている料理を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //どのListBoxが選択されているか調べる、SelectedIndexをキーにして降順に並べ替えて最初の要素を取得
            //一つ以外は選択できないようになっているのでFirst()以外は-1
            ListBox listBox = listboxes.OrderByDescending(od => od.SelectedIndex).First();
            int setDishesIndex=listboxes.IndexOf(listBox);
            
            if(listBox.SelectedIndex==-1)
            {
                MessageBox.Show("削除するアイテムを選択してください");
                return;
            }
            else
            {
                MainForm.File.SetDishes[setDishesIndex].meals.RemoveAt(listBox.SelectedIndex);
            }
            ReflectSetDishes();
        }
        
        /// <summary>
        /// 料理名を入力する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDishButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("メニュー名を入力してください");
                return;
            }

            int  selectedIndex;
            if (MainForm.File.FileType==(int)FileType.day)
            {
                if (TimingComboBox.SelectedIndex == -1)
                {
                    MessageBox.Show("区分を入力してください");
                    return;
                }
                selectedIndex = listboxes[TimingComboBox.SelectedIndex].SelectedIndex;
            }
            else
            {
                selectedIndex = StanderdListBox.SelectedIndex;
            }
            
            if(selectedIndex==-1)//新しく料理を設定する場合
            {
                if (MainForm.File.SetDishes[TimingComboBox.SelectedIndex+1] == null)
                {
                    MainForm.File.SetDishes[TimingComboBox.SelectedIndex+1] = new SetDish();
                }
                MainForm.File.SetDishes[TimingComboBox.SelectedIndex+1].meals.Add(new SetDish.Meal(NameTextBox.Text, MealTypeBox.SelectedIndex-1));
            }
            else//既存の料理の名称や設定を変更する場合
            {
                MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[selectedIndex].MealType= MealTypeBox.SelectedIndex - 1;
                MainForm.File.SetDishes[TimingComboBox.SelectedIndex + 1].meals[selectedIndex].MealName = NameTextBox.Text;
            }

            //
            foreach (var sd in MainForm.File.SetDishes)
            {
                if (sd == null || sd.meals.Count == 0) continue;
                sd.meals.Sort((a, b) => a.MealType - b.MealType);
            }
            ReflectSetDishes();

            NameTextBox.Text = "";
            MealTypeBox.SelectedIndex = -1;
        }

        /// <summary>
        /// 料理名の選択状態を解除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectLiftButton_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = "";
            TimingComboBox.SelectedIndex = -1;
            MealTypeBox.SelectedIndex = -1;
            oneday.ForEach(l => l.SelectedIndex = -1);
        }

        /// <summary>
        /// 一日のどこかのリストボックスが選択された場合、それ以外の選択を解除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeOnedayListaboxesSelect(object sender, EventArgs e)
        {
            //自己参照回避
            if (((ListBox)sender).SelectedIndex == -1) return;
           
            List<ListBox> oneday = new List<ListBox> { BreakFastListBox, LunchListBox, DinnerListBox, SnackListBox };
            TimingComboBox.SelectedIndex = oneday.IndexOf((ListBox)sender);
            oneday.Remove((ListBox)sender);
            NameTextBox.Text = ((ListBox)sender).SelectedItem.ToString();
            foreach (var o in oneday)
            {
                o.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 一日タイプ以外で既存の料理が選択された場合、名前入力欄に反映
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StanderdListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex == -1) return;
            NameTextBox.Text = ((ListBox)sender).SelectedItem.ToString();
        }

        /// <summary>
        /// 現在設定されていることを画面に反映する
        /// </summary>
        private void ReflectSetDishes()
        {
            listboxes.ForEach(o => o.Items.Clear());
            switch (MainForm.File.FileType)
            {
                case (int)FileType.free:
                case (int)FileType.serve:
                    if(MainForm.File.SetDishes[0]==null|| MainForm.File.SetDishes[0].meals.Count==0)
                    {
                        break;
                    }
                    for (int i = 0; i < MainForm.File.SetDishes[0].meals.Count; i++)
                    {
                        StanderdListBox.Items.Add(MainForm.File.SetDishes[0].meals[i].MealName);
                    }
                    break;
                case (int)FileType.set:
                case (int)FileType.day:
                    for (int i = 0; i < MainForm.File.SetDishes.Length; i++)
                    {
                        if (MainForm.File.SetDishes[i] == null || MainForm.File.SetDishes[i].meals.Count==0) continue;
                        var ml = MainForm.File.SetDishes[i].meals.OrderBy(m => m.MealType).ToList();//主食や主菜などのジャンルでソート
                        for (int j = 0; j < MainForm.File.SetDishes[i].meals.Count; j++)
                        {               
                            listboxes[i].Items.Add(MakeMealNames(ml[j].MealName, ml[j].MealType));
                        }
                    }
                    break;
                default:
                    break;
            }

            //主食や主菜などのジャンルを料理名に付け加える
            string MakeMealNames(string names, int mealtypes)
            {
                if (mealtypes > -1)
                {
                    return $"【{MealTypeItems[mealtypes+1]}】{names}";
                }
                else
                {
                    return names;
                }
            }
        }

        /// <summary>
        /// 何人前なのかセットする。一人前タイプ以外ではServePeopleTextboxが表示されない
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServePeopleTextbox_Leave(object sender, EventArgs e)
        {
            if(ServePeopleTextbox.Text=="")
            {
                return;
            }

            if(int.TryParse(ServePeopleTextbox.Text, out int s))
            {
                MainForm.File.ServePeople = s;
            }
            else
            {
                ServePeopleTextbox.Text = "";
                MessageBox.Show("人数は半角整数を入力してください");
            }
        }

        private void SelectTypeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var _ = MainForm.UpdateMainFormAsync();
        }
    }   
}