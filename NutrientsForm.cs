using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace えいようちゃん
{
    /// <summary>
    /// 表示する栄養素を設定する
    /// </summary>
    public partial class NutrientsForm : Form
    {
        /// <summary>
        /// 栄養素の名前と単位、順番はデータベースのカラム順
        /// </summary>
        public static List<string> NutrientsName = new List<string>();        
        List<CheckBox> CheckBoxes= new List<CheckBox>();

        public NutrientsForm()
        {
            InitializeComponent();
            CreateNutrientNames();
            CreatecheckBoxes();             
        }

        /// <summary>
        /// 表示栄養素が設定済みの場合、フォームに反映させる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NutrientsForm_Activated(object sender, EventArgs e)
        {
            CheckBoxes[0].Checked = MainForm.File.IsDisplayMaterialQuanatity;
            if(MainForm.File.IndicateNutrient.Count==0) return;

            int checkBoxesIndex = 1;
            int indicateIndex = NutrientsName.Count - (CheckBoxes.Count - 1);

            while(indicateIndex<NutrientsName.Count)
            {
                if(MainForm.File.IndicateNutrient[indicateIndex] >= 0)//
                {
                    CheckBoxes[checkBoxesIndex].Checked = true;
                }
                indicateIndex++;
                checkBoxesIndex++;
            }
        }

        /// <summary>
        /// データベースから各栄養素の名前や単位を取得し、ソフト内での表記を決める、TextMoldに一部引っ越し？
        /// </summary>
        void CreateNutrientNames()
        {
            var dataTabel = ConnectSQL.GetCompositionName();

            for (int i = 0; i < dataTabel.Rows.Count; i++)
            {
                var datarow = dataTabel.Rows[i].ItemArray;

                if (datarow[^1].GetType() == typeof(DBNull))//単位がない
                {
                    NutrientsName.Add(datarow[0].ToString());
                }
                else if (datarow[2].GetType() == typeof(DBNull))//詳細2がない
                {
                    var dr1 = ConvertNO_NIYORU(datarow[1].ToString());
                    NutrientsName.Add($"{dr1}({datarow[^2]})");
                }
                else if (datarow[3].GetType() == typeof(DBNull))//詳細3がない
                {
                    var dr2 = ConvertNO_NIYORU(datarow[2].ToString());
                    NutrientsName.Add($"{dr2}({datarow[^2]})");
                }
                else
                {
                    var dr2 = ConvertNO_NIYORU(datarow[2].ToString());
                    var dr3 = ConvertNO_NIYORU(datarow[3].ToString().Replace(datarow[2].ToString(), ""));
                    NutrientsName.Add($"{dr2}\n{dr3}({datarow[^2]})");
                }
            }

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

        /// <summary>
        /// チェックボックス生成
        /// </summary>
        /// <param name="checkboxTexts"></param>
        void CreatecheckBoxes()
        {
            int posX = 10;
            int posY = 10;

            var checkboxTexts = new List<string>{ "粗使用量(g)"};
            checkboxTexts.AddRange(NutrientsName);

            for(int i=0;i<checkboxTexts.Count;i++)
            {
                if(!checkboxTexts[i].Contains('('))
                {
                    continue;
                }

                CheckBox checkBox = new CheckBox();
                checkBox.Text = checkboxTexts[i];
                checkBox.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                checkBox.Location = new Point(posX, posY);
                checkBox.Checked = false;
                checkBox.AutoSize = true;
                CheckBoxes.Add(checkBox);
                this.Controls.Add(CheckBoxes.Last());

                if (CheckBoxes.Count!= 0&& CheckBoxes.Count % 11 == 0)
                {
                    posX = CheckBoxes.Count / 10 * 280 + 10;
                    posY = 10;
                }               
                else
                {
                    posY += 70;
                }

                if (i < CheckBoxes.Count - 2 && (checkboxTexts.Count>i+1&&checkboxTexts[i+1].Contains("\n")))
                {
                    posY -= 8;
                }
            }
        }

        /// <summary>
        /// 非栄養素=-2、非表示=-1、表示=0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNutrientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.File.IsDisplayMaterialQuanatity = CheckBoxes[0].Checked;

           while (NutrientsName.Count> MainForm.File.IndicateNutrient.Count)
           {
                MainForm.File.IndicateNutrient.Add(0);
           }

            int indicateIndex = 0;

            while(indicateIndex< NutrientsName.Count - (CheckBoxes.Count-1))//粗使用量はNutrientNameと無関係
            {
                MainForm.File.IndicateNutrient[indicateIndex] = -2;
                indicateIndex++;
            }

            int checkBoxesIndex = 1;
            while (indicateIndex<MainForm.File.IndicateNutrient.Count)
            {
                if (MainForm.File.IndicateNutrient[indicateIndex] > 0) { /*なし*/}
                else if (CheckBoxes[checkBoxesIndex].Checked)
                {
                    MainForm.File.IndicateNutrient[indicateIndex] = 0;
                }
                else
                {
                    MainForm.File.IndicateNutrient[indicateIndex] = -1;
                }
                indicateIndex++;
                checkBoxesIndex++;
            }

            var _=MainForm.UpdateMainFormAsync();
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
