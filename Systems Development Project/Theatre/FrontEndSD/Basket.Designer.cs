namespace FrontEndSD
{
    partial class Basket
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
            this.basketTitle = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.ticketCostLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buyButton = new System.Windows.Forms.Button();
            this.basketPanel = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // basketTitle
            // 
            this.basketTitle.AutoSize = true;
            this.basketTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.basketTitle.Location = new System.Drawing.Point(12, 9);
            this.basketTitle.Name = "basketTitle";
            this.basketTitle.Size = new System.Drawing.Size(98, 31);
            this.basketTitle.TabIndex = 12;
            this.basketTitle.Text = "Basket";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(247, 313);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 24);
            this.totalLabel.TabIndex = 11;
            // 
            // ticketCostLabel
            // 
            this.ticketCostLabel.AutoSize = true;
            this.ticketCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketCostLabel.Location = new System.Drawing.Point(113, 313);
            this.ticketCostLabel.Name = "ticketCostLabel";
            this.ticketCostLabel.Size = new System.Drawing.Size(108, 24);
            this.ticketCostLabel.TabIndex = 10;
            this.ticketCostLabel.Text = "Total Cost : ";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(12, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 37);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // buyButton
            // 
            this.buyButton.Enabled = false;
            this.buyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyButton.Location = new System.Drawing.Point(374, 358);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(150, 37);
            this.buyButton.TabIndex = 8;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.Buy_Click);
            // 
            // basketPanel
            // 
            this.basketPanel.AutoScroll = true;
            this.basketPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.basketPanel.Location = new System.Drawing.Point(12, 57);
            this.basketPanel.Name = "basketPanel";
            this.basketPanel.Size = new System.Drawing.Size(512, 233);
            this.basketPanel.TabIndex = 7;
            // 
            // clearButton
            // 
            this.clearButton.Enabled = false;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(374, 313);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(150, 37);
            this.clearButton.TabIndex = 9;
            this.clearButton.Text = "Clear Basket";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 411);
            this.ControlBox = false;
            this.Controls.Add(this.basketTitle);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.ticketCostLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.basketPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Basket";
            this.Text = "Basket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label basketTitle;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label ticketCostLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Panel basketPanel;
        private System.Windows.Forms.Button clearButton;
    }
}