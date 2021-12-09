
namespace えいようちゃん
{
    partial class FoodForm
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
            this.TimingComboBox = new System.Windows.Forms.ComboBox();
            this.MealNameComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.FoodCompositionListBox = new System.Windows.Forms.ListBox();
            this.NameQuantityView = new System.Windows.Forms.DataGridView();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoodCompositionComboBox = new System.Windows.Forms.ComboBox();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameQuantityView)).BeginInit();
            this.SuspendLayout();
            // 
            // TimingComboBox
            // 
            this.TimingComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimingComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimingComboBox.FormattingEnabled = true;
            this.TimingComboBox.Items.AddRange(new object[] {
            "朝食",
            "昼食",
            "夕食",
            "間食"});
            this.TimingComboBox.Location = new System.Drawing.Point(3, 3);
            this.TimingComboBox.Name = "TimingComboBox";
            this.TimingComboBox.Size = new System.Drawing.Size(176, 38);
            this.TimingComboBox.TabIndex = 9;
            this.TimingComboBox.Text = "時間帯";
            this.TimingComboBox.SelectedIndexChanged += new System.EventHandler(this.TimingComboBox_SelectedIndexChanged);
            // 
            // MealNameComboBox
            // 
            this.MealNameComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MealNameComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MealNameComboBox.FormattingEnabled = true;
            this.MealNameComboBox.Location = new System.Drawing.Point(185, 3);
            this.MealNameComboBox.Name = "MealNameComboBox";
            this.MealNameComboBox.Size = new System.Drawing.Size(176, 38);
            this.MealNameComboBox.TabIndex = 10;
            this.MealNameComboBox.Text = "料理名";
            this.MealNameComboBox.SelectedIndexChanged += new System.EventHandler(this.MealNameComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.FoodCompositionListBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.MealNameComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TimingComboBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NameQuantityView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FoodCompositionComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogListBox, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.904905F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.09509F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1097, 999);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FoodCompositionListBox
            // 
            this.FoodCompositionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoodCompositionListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FoodCompositionListBox.FormattingEnabled = true;
            this.FoodCompositionListBox.HorizontalScrollbar = true;
            this.FoodCompositionListBox.ItemHeight = 30;
            this.FoodCompositionListBox.Location = new System.Drawing.Point(367, 52);
            this.FoodCompositionListBox.Name = "FoodCompositionListBox";
            this.FoodCompositionListBox.Size = new System.Drawing.Size(359, 944);
            this.FoodCompositionListBox.TabIndex = 16;
            this.FoodCompositionListBox.SelectedIndexChanged += new System.EventHandler(this.FoodCompositionListBox_Selected);
            // 
            // NameQuantityView
            // 
            this.NameQuantityView.AllowUserToAddRows = false;
            this.NameQuantityView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NameQuantityView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.NameQuantityView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NameQuantityView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodName,
            this.Quantity});
            this.tableLayoutPanel1.SetColumnSpan(this.NameQuantityView, 2);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NameQuantityView.DefaultCellStyle = dataGridViewCellStyle2;
            this.NameQuantityView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameQuantityView.Location = new System.Drawing.Point(3, 52);
            this.NameQuantityView.Name = "NameQuantityView";
            this.NameQuantityView.RowHeadersVisible = false;
            this.NameQuantityView.RowHeadersWidth = 62;
            this.NameQuantityView.RowTemplate.Height = 33;
            this.NameQuantityView.Size = new System.Drawing.Size(358, 944);
            this.NameQuantityView.TabIndex = 11;
            this.NameQuantityView.Visible = false;
            this.NameQuantityView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.NameQuantityView_CellMouseUp);
            this.NameQuantityView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.NameQuantityView_CellValueChanged);
            // 
            // FoodName
            // 
            this.FoodName.HeaderText = "食品名";
            this.FoodName.MinimumWidth = 8;
            this.FoodName.Name = "FoodName";
            this.FoodName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "純使用量(g)";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            // 
            // FoodCompositionComboBox
            // 
            this.FoodCompositionComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoodCompositionComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FoodCompositionComboBox.FormattingEnabled = true;
            this.FoodCompositionComboBox.Location = new System.Drawing.Point(367, 3);
            this.FoodCompositionComboBox.Name = "FoodCompositionComboBox";
            this.FoodCompositionComboBox.Size = new System.Drawing.Size(359, 38);
            this.FoodCompositionComboBox.TabIndex = 14;
            this.FoodCompositionComboBox.Text = "表示する分類の選択or食品名検索";
            this.FoodCompositionComboBox.SelectedIndexChanged += new System.EventHandler(this.FoodCompositionCombobox_Selected);
            this.FoodCompositionComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FoodCompositionComboBox_KeyDown);
            // 
            // LogListBox
            // 
            this.LogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.HorizontalScrollbar = true;
            this.LogListBox.ItemHeight = 30;
            this.LogListBox.Location = new System.Drawing.Point(732, 3);
            this.LogListBox.Name = "LogListBox";
            this.tableLayoutPanel1.SetRowSpan(this.LogListBox, 2);
            this.LogListBox.Size = new System.Drawing.Size(362, 993);
            this.LogListBox.TabIndex = 13;
            this.LogListBox.SelectedIndexChanged += new System.EventHandler(this.LogListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "料理名を選択してください";
            // 
            // FoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1097, 999);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FoodForm";
            this.Text = "食品を選ぶ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FoodForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameQuantityView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FoodCompositionListBox;
        private System.Windows.Forms.ComboBox TimingComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox MealNameComboBox;
        private System.Windows.Forms.DataGridView NameQuantityView;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.ComboBox FoodCompositionComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}