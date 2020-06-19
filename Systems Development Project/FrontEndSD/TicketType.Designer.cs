namespace FrontEndSD
{
    partial class TicketType
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
            this.priceLabel = new System.Windows.Forms.Label();
            this.selectMsgLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.ticketTypeLabel = new System.Windows.Forms.Label();
            this.ticketTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.ticketTypeTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(101, 144);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(32, 17);
            this.priceLabel.TabIndex = 15;
            this.priceLabel.Text = "+£0";
            // 
            // selectMsgLabel
            // 
            this.selectMsgLabel.AutoSize = true;
            this.selectMsgLabel.Location = new System.Drawing.Point(13, 112);
            this.selectMsgLabel.Name = "selectMsgLabel";
            this.selectMsgLabel.Size = new System.Drawing.Size(194, 17);
            this.selectMsgLabel.TabIndex = 14;
            this.selectMsgLabel.Text = "Please Select your ticket type";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(13, 60);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 17);
            this.messageLabel.TabIndex = 13;
            // 
            // ticketTypeLabel
            // 
            this.ticketTypeLabel.AutoSize = true;
            this.ticketTypeLabel.Location = new System.Drawing.Point(13, 144);
            this.ticketTypeLabel.Name = "ticketTypeLabel";
            this.ticketTypeLabel.Size = new System.Drawing.Size(82, 17);
            this.ticketTypeLabel.TabIndex = 12;
            this.ticketTypeLabel.Text = "Ticket Type";
            // 
            // ticketTypeComboBox
            // 
            this.ticketTypeComboBox.FormattingEnabled = true;
            this.ticketTypeComboBox.Items.AddRange(new object[] {
            "Adult",
            "Senior",
            "Child"});
            this.ticketTypeComboBox.Location = new System.Drawing.Point(138, 141);
            this.ticketTypeComboBox.Name = "ticketTypeComboBox";
            this.ticketTypeComboBox.Size = new System.Drawing.Size(156, 24);
            this.ticketTypeComboBox.TabIndex = 11;
            this.ticketTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TicketType_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 185);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(125, 42);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(13, 185);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(125, 42);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // ticketTypeTitle
            // 
            this.ticketTypeTitle.AutoSize = true;
            this.ticketTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketTypeTitle.Location = new System.Drawing.Point(13, 13);
            this.ticketTypeTitle.Name = "ticketTypeTitle";
            this.ticketTypeTitle.Size = new System.Drawing.Size(165, 24);
            this.ticketTypeTitle.TabIndex = 8;
            this.ticketTypeTitle.Text = "Select Ticket Type";
            // 
            // TicketType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 239);
            this.ControlBox = false;
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.selectMsgLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.ticketTypeLabel);
            this.Controls.Add(this.ticketTypeComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.ticketTypeTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicketType";
            this.Text = "Ticket Type";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label selectMsgLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label ticketTypeLabel;
        private System.Windows.Forms.ComboBox ticketTypeComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label ticketTypeTitle;
    }
}