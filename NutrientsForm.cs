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
        List<CheckBox> CheckBoxes= new List<CheckBox>();

        public NutrientsForm()
        {
            InitializeComponent();
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
            if(MainForm.File.Indicate_ReferenceNutrient.Count==0) return;

            var ir = MainForm.File.Indicate_ReferenceNutrient.Select(ir=>ir.ColumnIndex).ToList();

            foreach(var indicate in ir)
            {
                CheckBoxes[indicate + 1].Checked = true;
            }
        }

        /// <summary>
        /// データベースから各栄養素の名前や単位を取得し、ソフト内での表記を決める、TextMoldに一部引っ越し？
        /// </summary>
        
        /// <summary>
        /// チェックボックス生成
        /// </summary>
        /// <param name="checkboxTexts"></param>
        void CreatecheckBoxes()
        {
            int posX = 10;
            int posY = 10;

            var checkboxTexts = new List<string>{ "粗使用量(g)"};
            checkboxTexts.AddRange(MainForm.FoodCompositionItems.NutrientsNames);

            int boxCount = 0;
            int textCount = 0;
            while(textCount<checkboxTexts.Count)
            {
                if(!checkboxTexts[textCount].Contains('('))
                {
                    CheckBoxes.Add(null);
                    textCount++;
                    continue;
                }

                CheckBox checkBox = new CheckBox();
                checkBox.Text = checkboxTexts[textCount];
                checkBox.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
                checkBox.Location = new Point(posX, posY);
                checkBox.Checked = false;
                checkBox.AutoSize = true;
                CheckBoxes.Add(checkBox);
                this.Controls.Add(CheckBoxes.Last());

                textCount++;
                boxCount++;
                if (boxCount % 11 == 0)
                {
                    posX = boxCount / 10 * 280 + 10;
                    posY = 10;
                }               
                else
                {
                    posY += 70;
                }

                if (checkboxTexts.Count>textCount&&checkboxTexts[textCount].Contains("\n"))
                {
                    posY -= 8;
                }                
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNutrientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.File.IsDisplayMaterialQuanatity = CheckBoxes[0].Checked;
            var ir = MainForm.File.Indicate_ReferenceNutrient;

            for (int i=1;i<CheckBoxes.Count; i++)
            {
                if (CheckBoxes[i] == null) continue;
                bool iscontain = ir.Any(irr => irr.ColumnIndex == i-1);
                if (CheckBoxes[i].Checked && !iscontain)//新しく追加
                {
                    ir.Add(new NutrientColumn(i-1,0));
                }
                else if (!CheckBoxes[i].Checked && iscontain)//削除
                {
                   ir.Remove(ir.Where(irr => irr.ColumnIndex == i-1).First());
                }
            }
            ir.Sort((a, b) => a.ColumnIndex - b.ColumnIndex);
            var _=MainForm.UpdateMainFormAsync();
            this.Visible = false;
            e.Cancel = true;
        }
    }
}
