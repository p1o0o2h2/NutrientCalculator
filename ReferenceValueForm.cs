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
            foreach(var ir in MainForm.File.Indicate_ReferenceNutrient)
            {
                if (ir.ColumnIndex == (int)NutrientDataColumn.refuse - 1) continue;
                if(ir.ReferenceValue==0)
                {
                    NutrientDataGridView.Rows.Add(ir.ColumnIndex,MainForm.FoodCompositionItems.NutrientsNames[ir.ColumnIndex], "なし");
                }
                else
                {
                    NutrientDataGridView.Rows.Add(ir.ColumnIndex,MainForm.FoodCompositionItems.NutrientsNames[ir.ColumnIndex], ir.ReferenceValue);
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

            for(int i=0;i< NutrientDataGridView.Rows.Count;i++)
            {
                var cellStr = NutrientDataGridView.Rows[i].Cells[2].Value.ToString();
                if (cellStr!="なし")
                {
                    MainForm.File.Indicate_ReferenceNutrient[i] =  new NutrientColumn(int.Parse(NutrientDataGridView.Rows[i].Cells[0].Value.ToString()), float.Parse(cellStr));
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
