
namespace えいようちゃん
{
    partial class ReferenceValueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NutrientDataGridView = new System.Windows.Forms.DataGridView();
            this.NutrientIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NutrientColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefernceValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NutrientDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NutrientDataGridView
            // 
            this.NutrientDataGridView.AllowUserToAddRows = false;
            this.NutrientDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NutrientDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NutrientDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.NutrientDataGridView.ColumnHeadersHeight = 34;
            this.NutrientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NutrientIndex,
            this.NutrientColumn,
            this.RefernceValueColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NutrientDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.NutrientDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.NutrientDataGridView.Location = new System.Drawing.Point(0, 0);
            this.NutrientDataGridView.Name = "NutrientDataGridView";
            this.NutrientDataGridView.RowHeadersVisible = false;
            this.NutrientDataGridView.RowHeadersWidth = 62;
            this.NutrientDataGridView.Size = new System.Drawing.Size(417, 648);
            this.NutrientDataGridView.TabIndex = 0;
            this.NutrientDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.NutrientDataGridView_CellValidating);
            // 
            // NutrientIndex
            // 
            this.NutrientIndex.HeaderText = "Column1";
            this.NutrientIndex.MinimumWidth = 8;
            this.NutrientIndex.Name = "NutrientIndex";
            this.NutrientIndex.ReadOnly = true;
            this.NutrientIndex.Visible = false;
            // 
            // NutrientColumn
            // 
            this.NutrientColumn.HeaderText = "項目名";
            this.NutrientColumn.MinimumWidth = 8;
            this.NutrientColumn.Name = "NutrientColumn";
            this.NutrientColumn.ReadOnly = true;
            this.NutrientColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RefernceValueColumn
            // 
            this.RefernceValueColumn.HeaderText = "基準値";
            this.RefernceValueColumn.MinimumWidth = 8;
            this.RefernceValueColumn.Name = "RefernceValueColumn";
            // 
            // ReferenceValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(416, 648);
            this.Controls.Add(this.NutrientDataGridView);
            this.Name = "ReferenceValueForm";
            this.Text = "基準値選択";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReferenceValueForm_FormClosing);
            this.Load += new System.EventHandler(this.ReferenceValueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NutrientDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView NutrientDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NutrientIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn NutrientColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefernceValueColumn;
    }
}