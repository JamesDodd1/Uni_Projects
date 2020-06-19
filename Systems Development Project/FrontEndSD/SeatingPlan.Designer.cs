
namespace FrontEndSD
{
    partial class SeatingPlan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any image being used.
        /// </summary>
        /// <param name="disposing">true if managed image should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.seatingPanel = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.selectSeatsButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Continue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStage = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.seatingPanel.SuspendLayout();
            this.panelStage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // seatingPanel
            // 
            this.seatingPanel.Controls.Add(this.panelStage);
            this.seatingPanel.Location = new System.Drawing.Point(12, 84);
            this.seatingPanel.Name = "seatingPanel";
            this.seatingPanel.Size = new System.Drawing.Size(480, 395);
            this.seatingPanel.TabIndex = 12;
            // 
            // selectSeatsButton
            // 
            this.selectSeatsButton.Location = new System.Drawing.Point(352, 12);
            this.selectSeatsButton.Name = "selectSeatsButton";
            this.selectSeatsButton.Size = new System.Drawing.Size(140, 48);
            this.selectSeatsButton.TabIndex = 15;
            this.selectSeatsButton.Text = "Select Seats";
            this.selectSeatsButton.UseVisualStyleBackColor = true;
            this.selectSeatsButton.Click += new System.EventHandler(this.Select_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 48);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Continue
            // 
            this.Continue.Location = new System.Drawing.Point(774, 967);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(75, 23);
            this.Continue.TabIndex = 13;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "STAGE";
            // 
            // panelStage
            // 
            this.panelStage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelStage.Controls.Add(this.label1);
            this.panelStage.Location = new System.Drawing.Point(105, 420);
            this.panelStage.Name = "panelStage";
            this.panelStage.Size = new System.Drawing.Size(266, 42);
            this.panelStage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "STAGE";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(119, 489);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 42);
            this.panel1.TabIndex = 18;
            // 
            // SeatingPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 566);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.seatingPanel);
            this.Controls.Add(this.selectSeatsButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.Continue);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SeatingPlan";
            this.Text = "Seating Plan";
            this.seatingPanel.ResumeLayout(false);
            this.panelStage.ResumeLayout(false);
            this.panelStage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel seatingPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button selectSeatsButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Panel panelStage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
