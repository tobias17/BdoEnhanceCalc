namespace BdoEnhanceCalc.Forms
{
    partial class RepairItemEditForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.RepairAmountTextBox = new System.Windows.Forms.TextBox();
            this.RepairAmountLabel = new System.Windows.Forms.Label();
            this.SaleValueTextBox = new System.Windows.Forms.TextBox();
            this.SaleValueLabel = new System.Windows.Forms.Label();
            this.MarketplaceCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(83, 127);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 33);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(176, 127);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 33);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(113, 11);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(150, 22);
            this.NameTextBox.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 14);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 16);
            this.NameLabel.TabIndex = 19;
            this.NameLabel.Text = "Name";
            // 
            // RepairAmountTextBox
            // 
            this.RepairAmountTextBox.Location = new System.Drawing.Point(113, 39);
            this.RepairAmountTextBox.Name = "RepairAmountTextBox";
            this.RepairAmountTextBox.Size = new System.Drawing.Size(150, 22);
            this.RepairAmountTextBox.TabIndex = 1;
            // 
            // RepairAmountLabel
            // 
            this.RepairAmountLabel.AutoSize = true;
            this.RepairAmountLabel.Location = new System.Drawing.Point(12, 42);
            this.RepairAmountLabel.Name = "RepairAmountLabel";
            this.RepairAmountLabel.Size = new System.Drawing.Size(97, 16);
            this.RepairAmountLabel.TabIndex = 25;
            this.RepairAmountLabel.Text = "Repair Amount";
            // 
            // SaleValueTextBox
            // 
            this.SaleValueTextBox.Location = new System.Drawing.Point(113, 67);
            this.SaleValueTextBox.Name = "SaleValueTextBox";
            this.SaleValueTextBox.Size = new System.Drawing.Size(150, 22);
            this.SaleValueTextBox.TabIndex = 2;
            // 
            // SaleValueLabel
            // 
            this.SaleValueLabel.AutoSize = true;
            this.SaleValueLabel.Location = new System.Drawing.Point(12, 70);
            this.SaleValueLabel.Name = "SaleValueLabel";
            this.SaleValueLabel.Size = new System.Drawing.Size(74, 16);
            this.SaleValueLabel.TabIndex = 27;
            this.SaleValueLabel.Text = "Sale Value";
            // 
            // MarketplaceCheckBox
            // 
            this.MarketplaceCheckBox.AutoSize = true;
            this.MarketplaceCheckBox.Location = new System.Drawing.Point(15, 97);
            this.MarketplaceCheckBox.Name = "MarketplaceCheckBox";
            this.MarketplaceCheckBox.Size = new System.Drawing.Size(102, 20);
            this.MarketplaceCheckBox.TabIndex = 3;
            this.MarketplaceCheckBox.Text = "Marketplace";
            this.MarketplaceCheckBox.UseVisualStyleBackColor = true;
            this.MarketplaceCheckBox.CheckedChanged += new System.EventHandler(this.MarketplaceCheckBox_CheckedChanged);
            // 
            // RepairItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 173);
            this.Controls.Add(this.SaleValueTextBox);
            this.Controls.Add(this.SaleValueLabel);
            this.Controls.Add(this.RepairAmountTextBox);
            this.Controls.Add(this.RepairAmountLabel);
            this.Controls.Add(this.MarketplaceCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RepairItemEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Repair Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox RepairAmountTextBox;
        private System.Windows.Forms.Label RepairAmountLabel;
        private System.Windows.Forms.TextBox SaleValueTextBox;
        private System.Windows.Forms.Label SaleValueLabel;
        private System.Windows.Forms.CheckBox MarketplaceCheckBox;
    }
}