
namespace えいようちゃん
{
    partial class SetDishMealForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TypeSelectComboBox = new System.Windows.Forms.ComboBox();
            this.StanderdListBox = new System.Windows.Forms.ListBox();
            this.BreakFastListBox = new System.Windows.Forms.ListBox();
            this.LunchListBox = new System.Windows.Forms.ListBox();
            this.DinnerListBox = new System.Windows.Forms.ListBox();
            this.SnackListBox = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.BreakFastLabel = new System.Windows.Forms.Label();
            this.LunchLabel = new System.Windows.Forms.Label();
            this.DinnerLabel = new System.Windows.Forms.Label();
            this.SnackLabel = new System.Windows.Forms.Label();
            this.CutLabel1 = new System.Windows.Forms.Label();
            this.CutLabel2 = new System.Windows.Forms.Label();
            this.ServePeopleTextbox = new System.Windows.Forms.TextBox();
            this.MealTypeLabel = new System.Windows.Forms.Label();
            this.MealTypeBox = new System.Windows.Forms.ComboBox();
            this.SetDishButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TimingLabel = new System.Windows.Forms.Label();
            this.TimingComboBox = new System.Windows.Forms.ComboBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SelectliftButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(36, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "単位";
            // 
            // TypeSelectComboBox
            // 
            this.TypeSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeSelectComboBox.FormattingEnabled = true;
            this.TypeSelectComboBox.Location = new System.Drawing.Point(136, 48);
            this.TypeSelectComboBox.Name = "TypeSelectComboBox";
            this.TypeSelectComboBox.Size = new System.Drawing.Size(210, 33);
            this.TypeSelectComboBox.TabIndex = 1;
            this.TypeSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeSelectCombobox_SelectedIndexChanged);
            // 
            // StanderdListBox
            // 
            this.StanderdListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StanderdListBox.FormattingEnabled = true;
            this.StanderdListBox.ItemHeight = 30;
            this.StanderdListBox.Location = new System.Drawing.Point(432, 12);
            this.StanderdListBox.Name = "StanderdListBox";
            this.StanderdListBox.Size = new System.Drawing.Size(518, 724);
            this.StanderdListBox.TabIndex = 4;
            this.StanderdListBox.Visible = false;
            this.StanderdListBox.SelectedIndexChanged += new System.EventHandler(this.StanderdListBox_SelectedIndexChanged);
            // 
            // BreakFastListBox
            // 
            this.BreakFastListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BreakFastListBox.FormattingEnabled = true;
            this.BreakFastListBox.ItemHeight = 30;
            this.BreakFastListBox.Location = new System.Drawing.Point(432, 39);
            this.BreakFastListBox.Name = "BreakFastListBox";
            this.BreakFastListBox.Size = new System.Drawing.Size(518, 154);
            this.BreakFastListBox.TabIndex = 5;
            this.BreakFastListBox.Visible = false;
            this.BreakFastListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeOnedayListaboxesSelect);
            // 
            // LunchListBox
            // 
            this.LunchListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LunchListBox.FormattingEnabled = true;
            this.LunchListBox.ItemHeight = 30;
            this.LunchListBox.Location = new System.Drawing.Point(432, 224);
            this.LunchListBox.Name = "LunchListBox";
            this.LunchListBox.Size = new System.Drawing.Size(518, 154);
            this.LunchListBox.TabIndex = 6;
            this.LunchListBox.Visible = false;
            this.LunchListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeOnedayListaboxesSelect);
            // 
            // DinnerListBox
            // 
            this.DinnerListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DinnerListBox.FormattingEnabled = true;
            this.DinnerListBox.ItemHeight = 30;
            this.DinnerListBox.Location = new System.Drawing.Point(432, 427);
            this.DinnerListBox.Name = "DinnerListBox";
            this.DinnerListBox.Size = new System.Drawing.Size(518, 154);
            this.DinnerListBox.TabIndex = 7;
            this.DinnerListBox.Visible = false;
            this.DinnerListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeOnedayListaboxesSelect);
            // 
            // SnackListBox
            // 
            this.SnackListBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SnackListBox.FormattingEnabled = true;
            this.SnackListBox.ItemHeight = 30;
            this.SnackListBox.Location = new System.Drawing.Point(431, 612);
            this.SnackListBox.Name = "SnackListBox";
            this.SnackListBox.Size = new System.Drawing.Size(518, 154);
            this.SnackListBox.TabIndex = 8;
            this.SnackListBox.Visible = false;
            this.SnackListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeOnedayListaboxesSelect);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 25;
            this.listBox3.Location = new System.Drawing.Point(337, 276);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(232, 104);
            this.listBox3.TabIndex = 10;
            // 
            // BreakFastLabel
            // 
            this.BreakFastLabel.AutoSize = true;
            this.BreakFastLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BreakFastLabel.Location = new System.Drawing.Point(442, 12);
            this.BreakFastLabel.Name = "BreakFastLabel";
            this.BreakFastLabel.Size = new System.Drawing.Size(48, 25);
            this.BreakFastLabel.TabIndex = 9;
            this.BreakFastLabel.Text = "朝食";
            this.BreakFastLabel.Visible = false;
            // 
            // LunchLabel
            // 
            this.LunchLabel.AutoSize = true;
            this.LunchLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LunchLabel.Location = new System.Drawing.Point(442, 196);
            this.LunchLabel.Name = "LunchLabel";
            this.LunchLabel.Size = new System.Drawing.Size(48, 25);
            this.LunchLabel.TabIndex = 10;
            this.LunchLabel.Text = "昼食";
            this.LunchLabel.Visible = false;
            // 
            // DinnerLabel
            // 
            this.DinnerLabel.AutoSize = true;
            this.DinnerLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DinnerLabel.Location = new System.Drawing.Point(442, 399);
            this.DinnerLabel.Name = "DinnerLabel";
            this.DinnerLabel.Size = new System.Drawing.Size(48, 25);
            this.DinnerLabel.TabIndex = 11;
            this.DinnerLabel.Text = "夕食";
            this.DinnerLabel.Visible = false;
            // 
            // SnackLabel
            // 
            this.SnackLabel.AutoSize = true;
            this.SnackLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnackLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SnackLabel.Location = new System.Drawing.Point(442, 584);
            this.SnackLabel.Name = "SnackLabel";
            this.SnackLabel.Size = new System.Drawing.Size(50, 27);
            this.SnackLabel.TabIndex = 12;
            this.SnackLabel.Text = "間食";
            this.SnackLabel.Visible = false;
            // 
            // CutLabel1
            // 
            this.CutLabel1.AutoSize = true;
            this.CutLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CutLabel1.Location = new System.Drawing.Point(36, 116);
            this.CutLabel1.Name = "CutLabel1";
            this.CutLabel1.Size = new System.Drawing.Size(57, 30);
            this.CutLabel1.TabIndex = 13;
            this.CutLabel1.Text = "人数";
            this.CutLabel1.Visible = false;
            // 
            // CutLabel2
            // 
            this.CutLabel2.AutoSize = true;
            this.CutLabel2.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CutLabel2.Location = new System.Drawing.Point(311, 112);
            this.CutLabel2.Name = "CutLabel2";
            this.CutLabel2.Size = new System.Drawing.Size(57, 30);
            this.CutLabel2.TabIndex = 14;
            this.CutLabel2.Text = "人前";
            this.CutLabel2.Visible = false;
            // 
            // ServePeopleTextbox
            // 
            this.ServePeopleTextbox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServePeopleTextbox.Location = new System.Drawing.Point(186, 109);
            this.ServePeopleTextbox.Name = "ServePeopleTextbox";
            this.ServePeopleTextbox.Size = new System.Drawing.Size(84, 37);
            this.ServePeopleTextbox.TabIndex = 15;
            this.ServePeopleTextbox.Visible = false;
            this.ServePeopleTextbox.Leave += new System.EventHandler(this.ServePeopleTextbox_Leave);
            // 
            // MealTypeLabel
            // 
            this.MealTypeLabel.AutoSize = true;
            this.MealTypeLabel.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MealTypeLabel.Location = new System.Drawing.Point(234, 513);
            this.MealTypeLabel.Name = "MealTypeLabel";
            this.MealTypeLabel.Size = new System.Drawing.Size(57, 30);
            this.MealTypeLabel.TabIndex = 16;
            this.MealTypeLabel.Text = "種類";
            this.MealTypeLabel.Visible = false;
            // 
            // MealTypeBox
            // 
            this.MealTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MealTypeBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MealTypeBox.FormattingEnabled = true;
            this.MealTypeBox.Location = new System.Drawing.Point(234, 573);
            this.MealTypeBox.Name = "MealTypeBox";
            this.MealTypeBox.Size = new System.Drawing.Size(147, 38);
            this.MealTypeBox.TabIndex = 17;
            this.MealTypeBox.Visible = false;
            // 
            // SetDishButton
            // 
            this.SetDishButton.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SetDishButton.Location = new System.Drawing.Point(311, 703);
            this.SetDishButton.Name = "SetDishButton";
            this.SetDishButton.Size = new System.Drawing.Size(99, 60);
            this.SetDishButton.TabIndex = 18;
            this.SetDishButton.Text = "登録";
            this.SetDishButton.UseVisualStyleBackColor = true;
            this.SetDishButton.Visible = false;
            this.SetDishButton.Click += new System.EventHandler(this.SetDishButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(26, 348);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(95, 30);
            this.NameLabel.TabIndex = 19;
            this.NameLabel.Text = "メニュー名";
            this.NameLabel.Visible = false;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameTextBox.Location = new System.Drawing.Point(26, 415);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(342, 37);
            this.NameTextBox.TabIndex = 20;
            this.NameTextBox.Visible = false;
            // 
            // TimingLabel
            // 
            this.TimingLabel.AutoSize = true;
            this.TimingLabel.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimingLabel.Location = new System.Drawing.Point(26, 513);
            this.TimingLabel.Name = "TimingLabel";
            this.TimingLabel.Size = new System.Drawing.Size(79, 30);
            this.TimingLabel.TabIndex = 21;
            this.TimingLabel.Text = "時間帯";
            this.TimingLabel.Visible = false;
            // 
            // TimingComboBox
            // 
            this.TimingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimingComboBox.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimingComboBox.FormattingEnabled = true;
            this.TimingComboBox.Location = new System.Drawing.Point(26, 573);
            this.TimingComboBox.Name = "TimingComboBox";
            this.TimingComboBox.Size = new System.Drawing.Size(150, 38);
            this.TimingComboBox.TabIndex = 22;
            this.TimingComboBox.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DeleteButton.Location = new System.Drawing.Point(12, 703);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(109, 60);
            this.DeleteButton.TabIndex = 23;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SelectliftButton
            // 
            this.SelectliftButton.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SelectliftButton.Location = new System.Drawing.Point(161, 703);
            this.SelectliftButton.Name = "SelectliftButton";
            this.SelectliftButton.Size = new System.Drawing.Size(117, 60);
            this.SelectliftButton.TabIndex = 24;
            this.SelectliftButton.Text = "選択解除";
            this.SelectliftButton.UseVisualStyleBackColor = true;
            this.SelectliftButton.Visible = false;
            this.SelectliftButton.Click += new System.EventHandler(this.SelectLiftButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(171, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 62);
            this.button1.TabIndex = 25;
            this.button1.Text = "献立データベース";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // SetDishMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(962, 775);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SelectliftButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.TimingComboBox);
            this.Controls.Add(this.TimingLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.SetDishButton);
            this.Controls.Add(this.MealTypeBox);
            this.Controls.Add(this.MealTypeLabel);
            this.Controls.Add(this.ServePeopleTextbox);
            this.Controls.Add(this.CutLabel2);
            this.Controls.Add(this.CutLabel1);
            this.Controls.Add(this.SnackLabel);
            this.Controls.Add(this.DinnerLabel);
            this.Controls.Add(this.LunchLabel);
            this.Controls.Add(this.BreakFastLabel);
            this.Controls.Add(this.SnackListBox);
            this.Controls.Add(this.DinnerListBox);
            this.Controls.Add(this.LunchListBox);
            this.Controls.Add(this.BreakFastListBox);
            this.Controls.Add(this.StanderdListBox);
            this.Controls.Add(this.TypeSelectComboBox);
            this.Controls.Add(this.label1);
            this.Name = "SetDishMealForm";
            this.Text = "表の種類";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectTypeForm_FormClosed);
            this.Load += new System.EventHandler(this.SelectTypeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TypeSelectComboBox;
        private System.Windows.Forms.ListBox StanderdListBox;
        private System.Windows.Forms.ListBox BreakFastListBox;
        private System.Windows.Forms.ListBox LunchListBox;
        private System.Windows.Forms.ListBox DinnerListBox;
        private System.Windows.Forms.ListBox SnackListBox;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label BreakFastLabel;
        private System.Windows.Forms.Label LunchLabel;
        private System.Windows.Forms.Label DinnerLabel;
        private System.Windows.Forms.Label SnackLabel;
        private System.Windows.Forms.Label CutLabel1;
        private System.Windows.Forms.Label CutLabel2;
        private System.Windows.Forms.TextBox ServePeopleTextbox;
        private System.Windows.Forms.Label MealTypeLabel;
        private System.Windows.Forms.ComboBox MealTypeBox;
        private System.Windows.Forms.Button SetDishButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label TimingLabel;
        private System.Windows.Forms.ComboBox TimingComboBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SelectliftButton;
        private System.Windows.Forms.Button button1;
    }
}

