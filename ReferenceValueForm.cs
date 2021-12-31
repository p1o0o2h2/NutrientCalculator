using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace えいようちゃん
{
    /// <summary>
    /// 栄養素に目標値や基準値を設定する
    /// </summary>
    public partial class ReferenceValueForm : Form
    {
        public ReferenceValueForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 現在の設定を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferenceValueForm_Load(object sender, EventArgs e)
        {
            NutrientDataGridView.Rows.Clear();
            for (int i = 0; i < MainForm.File.IndicateNutrient.Count; i++)
            {
                if (i == (int)NutrientDataColumn.refuse) continue;
                if (MainForm.File.IndicateNutrient[i]==0)
                {
                    NutrientDataGridView.Rows.Add(i, NutrientsForm.NutrientsName[i], "なし");
                }
                else if (MainForm.File.IndicateNutrient[i]> 0)
                {
                    NutrientDataGridView.Rows.Add(i, NutrientsForm.NutrientsName[i], MainForm.File.IndicateNutrient[i]);
                }
            }
        }

        /// <summary>
        /// 入力情報を保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReferenceValueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(NutrientDataGridView.Rows.Count==0) return;//一列目はlabel

            foreach(var nutrient in NutrientDataGridView.Rows.Cast<DataGridViewRow>())
            {
                var index = int.Parse(nutrient.Cells[0].Value.ToString());//nutrient.Cells[0]=栄養素の食品成分表上の順番,Form上では非表示

                if (float.TryParse(nutrient.Cells[2].Value.ToString(), out float value))//nutrient.Cells[2]=入力内容
                {
                    MainForm.File.IndicateNutrient[index] = value;
                }
            }
            var _ = MainForm.UpdateMainFormAsync();
        }

        /// <summary>
        /// 入力内容が数字かどうかチェックする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NutrientDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var changeCell= dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var input = e.FormattedValue.ToString();

            if (changeCell.Value.ToString() == input) return;

            if(!float.TryParse(input,out float _))
            {
                MessageBox.Show("半角数字で入力してください");
                dgv.CancelEdit();
                e.Cancel=true;
                return;
            }
        }
    }
}
