
namespace えいようちゃん
{
    partial class MenuDatabaseForm
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
            this.MyMenuFgCheckBox = new System.Windows.Forms.CheckBox();
            this.ConditionComboBox = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.FoodDataGridView = new System.Windows.Forms.DataGridView();
            this.AddSetDishButton = new System.Windows.Forms.Button();
            this.DeleteMenuButton = new System.Windows.Forms.Button();
            this.MenuListBox = new System.Windows.Forms.ListBox();
            this.ConditionTextBox = new System.Windows.Forms.TextBox();
            this.RegisterMenuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FoodDataGridView)).BeginInit();
            this.SuspendLayout();
            //
            // MyMenuFgCheckBox
            //
            this.MyMenuFgCheckBox.AutoSize = true;
            this.MyMenuFgCheckBox.Location = new System.Drawing.Point(585, 27);
            this.MyMenuFgCheckBox.Name = "MyMenuFgCheckBox";
            this.MyMenuFgCheckBox.Size = new System.Drawing.Size(206, 29);
            this.MyMenuFgCheckBox.TabIndex = 0;
            this.MyMenuFgCheckBox.Text = "自分のメニューのみ表示";
            this.MyMenuFgCheckBox.UseVisualStyleBackColor = true;
            this.MyMenuFgCheckBox.CheckedChanged += new System.EventHandler(this.MyMenuFgCheckBox_CheckedChanged);
            //
            // ConditionComboBox
            //
            this.ConditionComboBox.FormattingEnabled = true;
            this.ConditionComboBox.Location = new System.Drawing.Point(12, 26);
            this.ConditionComboBox.Name = "ConditionComboBox";
            this.ConditionComboBox.Size = new System.Drawing.Size(152, 33);
            this.ConditionComboBox.TabIndex = 1;
            //
            // SearchButton
            //
            this.SearchButton.Location = new System.Drawing.Point(422, 18);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(112, 44);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "検索";
            this.SearchButton.UseVisualStyleBackColor = true;
            //
            // FoodDataGridView
            //
            this.FoodDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoodDataGridView.Location = new System.Drawing.Point(411, 89);
            this.FoodDataGridView.Name = "FoodDataGridView";
            this.FoodDataGridView.RowHeadersWidth = 62;
            this.FoodDataGridView.RowTemplate.Height = 33;
            this.FoodDataGridView.Size = new System.Drawing.Size(331, 398);
            this.FoodDataGridView.TabIndex = 3;
            //
            // AddSetDishButton
            //
            this.AddSetDishButton.Location = new System.Drawing.Point(199, 515);
            this.AddSetDishButton.Name = "AddSetDishButton";
            this.AddSetDishButton.Size = new System.Drawing.Size(119, 44);
            this.AddSetDishButton.TabIndex = 4;
            this.AddSetDishButton.Text = "献立に追加";
            this.AddSetDishButton.UseVisualStyleBackColor = true;
            //
            // DeleteMenuButton
            //
            this.DeleteMenuButton.Location = new System.Drawing.Point(656, 515);
            this.DeleteMenuButton.Name = "DeleteMenuButton";
            this.DeleteMenuButton.Size = new System.Drawing.Size(119, 44);
            this.DeleteMenuButton.TabIndex = 5;
            this.DeleteMenuButton.Text = "削除";
            this.DeleteMenuButton.UseVisualStyleBackColor = true;
            //
            // MenuListBox
            //
            this.MenuListBox.FormattingEnabled = true;
            this.MenuListBox.ItemHeight = 25;
            this.MenuListBox.Location = new System.Drawing.Point(12, 89);
            this.MenuListBox.Name = "MenuListBox";
            this.MenuListBox.Size = new System.Drawing.Size(334, 404);
            this.MenuListBox.TabIndex = 6;
            //
            // ConditionTextBox
            //
            this.ConditionTextBox.Location = new System.Drawing.Point(199, 25);
            this.ConditionTextBox.Name = "ConditionTextBox";
            this.ConditionTextBox.Size = new System.Drawing.Size(178, 31);
            this.ConditionTextBox.TabIndex = 7;
            //
            // RegisterMenuButton
            //
            this.RegisterMenuButton.Location = new System.Drawing.Point(505, 515);
            this.RegisterMenuButton.Name = "RegisterMenuButton";
            this.RegisterMenuButton.Size = new System.Drawing.Size(119, 44);
            this.RegisterMenuButton.TabIndex = 8;
            this.RegisterMenuButton.Text = "登録";
            this.RegisterMenuButton.UseVisualStyleBackColor = true;
            //
            // MenuDatabaseForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 583);
            this.Controls.Add(this.RegisterMenuButton);
            this.Controls.Add(this.ConditionTextBox);
            this.Controls.Add(this.MenuListBox);
            this.Controls.Add(this.DeleteMenuButton);
            this.Controls.Add(this.AddSetDishButton);
            this.Controls.Add(this.FoodDataGridView);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ConditionComboBox);
            this.Controls.Add(this.MyMenuFgCheckBox);
            this.Name = "MenuDatabaseForm";
            this.Text = "MenuDatabaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.FoodDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox MyMenuFgCheckBox;
        private System.Windows.Forms.ComboBox ConditionComboBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView FoodDataGridView;
        private System.Windows.Forms.Button AddSetDishButton;
        private System.Windows.Forms.Button DeleteMenuButton;
        private System.Windows.Forms.ListBox MenuListBox;
        private System.Windows.Forms.TextBox ConditionTextBox;
        private System.Windows.Forms.Button RegisterMenuButton;
    }
}