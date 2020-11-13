namespace FrontEndSD
{
    partial class ManagePerformances
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
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.costLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.removeBtton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.dateLabel = new System.Windows.Forms.Label();
            this.dateCalendar = new System.Windows.Forms.MonthCalendar();
            this.showLabel = new System.Windows.Forms.Label();
            this.searchPerformancesComboBox = new System.Windows.Forms.ComboBox();
            this.showTextBox = new System.Windows.Forms.TextBox();
            this.performanceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(446, 115);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(60, 23);
            this.costTextBox.TabIndex = 49;
            this.costTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cost_KeyPress);
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(398, 118);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(48, 17);
            this.costLabel.TabIndex = 48;
            this.costLabel.Text = "Cost £";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cancelButton.Location = new System.Drawing.Point(412, 287);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 27);
            this.cancelButton.TabIndex = 46;
            this.cancelButton.Text = "Return";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Return_Click);
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.continueButton.Location = new System.Drawing.Point(412, 254);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(110, 27);
            this.continueButton.TabIndex = 45;
            this.continueButton.Text = "Insert";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.Continue_Click);
            // 
            // removeBtton
            // 
            this.removeBtton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.removeBtton.Location = new System.Drawing.Point(388, 12);
            this.removeBtton.Name = "removeBtton";
            this.removeBtton.Size = new System.Drawing.Size(100, 31);
            this.removeBtton.TabIndex = 44;
            this.removeBtton.Text = "REMOVE";
            this.removeBtton.UseVisualStyleBackColor = true;
            this.removeBtton.Click += new System.EventHandler(this.Remove_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.editButton.Location = new System.Drawing.Point(207, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(100, 31);
            this.editButton.TabIndex = 43;
            this.editButton.Text = "EDIT";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.Edit_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addButton.Location = new System.Drawing.Point(32, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 31);
            this.addButton.TabIndex = 42;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.Add_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateLabel.Location = new System.Drawing.Point(12, 118);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(42, 17);
            this.dateLabel.TabIndex = 41;
            this.dateLabel.Text = "Date:";
            // 
            // dateCalendar
            // 
            this.dateCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateCalendar.Location = new System.Drawing.Point(15, 140);
            this.dateCalendar.Name = "dateCalendar";
            this.dateCalendar.TabIndex = 40;
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLabel.Location = new System.Drawing.Point(12, 78);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(98, 16);
            this.showLabel.TabIndex = 38;
            this.showLabel.Text = "Selected Show";
            // 
            // searchPerformancesComboBox
            // 
            this.searchPerformancesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchPerformancesComboBox.FormattingEnabled = true;
            this.searchPerformancesComboBox.Location = new System.Drawing.Point(158, 115);
            this.searchPerformancesComboBox.Name = "searchPerformancesComboBox";
            this.searchPerformancesComboBox.Size = new System.Drawing.Size(348, 24);
            this.searchPerformancesComboBox.TabIndex = 47;
            this.searchPerformancesComboBox.Visible = false;
            this.searchPerformancesComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchPerformances_SelectedIndexChanged);
            // 
            // showTextBox
            // 
            this.showTextBox.Enabled = false;
            this.showTextBox.Location = new System.Drawing.Point(158, 78);
            this.showTextBox.Name = "showTextBox";
            this.showTextBox.Size = new System.Drawing.Size(348, 23);
            this.showTextBox.TabIndex = 39;
            // 
            // performanceLabel
            // 
            this.performanceLabel.AutoSize = true;
            this.performanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performanceLabel.Location = new System.Drawing.Point(12, 118);
            this.performanceLabel.Name = "performanceLabel";
            this.performanceLabel.Size = new System.Drawing.Size(140, 16);
            this.performanceLabel.TabIndex = 50;
            this.performanceLabel.Text = "Remove Performance";
            this.performanceLabel.Visible = false;
            // 
            // PerformanceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 331);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.removeBtton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateCalendar);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.showTextBox);
            this.Controls.Add(this.searchPerformancesComboBox);
            this.Controls.Add(this.performanceLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PerformanceManage";
            this.Text = "PerformanceManage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button removeBtton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.MonthCalendar dateCalendar;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.ComboBox searchPerformancesComboBox;
        private System.Windows.Forms.TextBox showTextBox;
        private System.Windows.Forms.Label performanceLabel;
    }
}