namespace BdoEnhanceCalc.Forms
{
    partial class EnhanceMatEditForm
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
            this.SaleValueTextBox = new System.Windows.Forms.TextBox();
            this.SaleValueLabel = new System.Windows.Forms.Label();
            this.MarketplaceCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IntermediateItemCheckBox = new System.Windows.Forms.CheckBox();
            this.UseOtherItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.OtherItemLabel = new System.Windows.Forms.Label();
            this.OtherItemComboBox = new System.Windows.Forms.ComboBox();
            this.DecrementOtherItemAmountButton = new System.Windows.Forms.Button();
            this.IncrementOtherItemAmountButton = new System.Windows.Forms.Button();
            this.OtherItemAmountTextBox = new System.Windows.Forms.TextBox();
            this.OtherItemAmountLabel = new System.Windows.Forms.Label();
            this.OtherItemsTabControl = new System.Windows.Forms.TabControl();
            this.OtherItemsTab1 = new System.Windows.Forms.TabPage();
            this.DeleteTabButton = new System.Windows.Forms.Button();
            this.AddTabButton = new System.Windows.Forms.Button();
            this.OtherItemsTabControl.SuspendLayout();
            this.OtherItemsTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaleValueTextBox
            // 
            this.SaleValueTextBox.Location = new System.Drawing.Point(113, 39);
            this.SaleValueTextBox.Name = "SaleValueTextBox";
            this.SaleValueTextBox.Size = new System.Drawing.Size(150, 22);
            this.SaleValueTextBox.TabIndex = 30;
            // 
            // SaleValueLabel
            // 
            this.SaleValueLabel.AutoSize = true;
            this.SaleValueLabel.Location = new System.Drawing.Point(12, 42);
            this.SaleValueLabel.Name = "SaleValueLabel";
            this.SaleValueLabel.Size = new System.Drawing.Size(74, 16);
            this.SaleValueLabel.TabIndex = 37;
            this.SaleValueLabel.Text = "Sale Value";
            // 
            // MarketplaceCheckBox
            // 
            this.MarketplaceCheckBox.AutoSize = true;
            this.MarketplaceCheckBox.Location = new System.Drawing.Point(15, 69);
            this.MarketplaceCheckBox.Name = "MarketplaceCheckBox";
            this.MarketplaceCheckBox.Size = new System.Drawing.Size(102, 20);
            this.MarketplaceCheckBox.TabIndex = 31;
            this.MarketplaceCheckBox.Text = "Marketplace";
            this.MarketplaceCheckBox.UseVisualStyleBackColor = true;
            this.MarketplaceCheckBox.CheckedChanged += new System.EventHandler(this.MarketplaceCheckBox_CheckedChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(370, 156);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 33);
            this.SaveButton.TabIndex = 32;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(463, 156);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 33);
            this.CancelButton.TabIndex = 33;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(113, 11);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(150, 22);
            this.NameTextBox.TabIndex = 28;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 14);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 16);
            this.NameLabel.TabIndex = 34;
            this.NameLabel.Text = "Name";
            // 
            // IntermediateItemCheckBox
            // 
            this.IntermediateItemCheckBox.AutoSize = true;
            this.IntermediateItemCheckBox.Location = new System.Drawing.Point(15, 97);
            this.IntermediateItemCheckBox.Name = "IntermediateItemCheckBox";
            this.IntermediateItemCheckBox.Size = new System.Drawing.Size(129, 20);
            this.IntermediateItemCheckBox.TabIndex = 38;
            this.IntermediateItemCheckBox.Text = "Intermediate Item";
            this.IntermediateItemCheckBox.UseVisualStyleBackColor = true;
            this.IntermediateItemCheckBox.CheckedChanged += new System.EventHandler(this.IntermediateItemCheckBox_CheckedChanged);
            // 
            // UseOtherItemsCheckBox
            // 
            this.UseOtherItemsCheckBox.AutoSize = true;
            this.UseOtherItemsCheckBox.Location = new System.Drawing.Point(295, 13);
            this.UseOtherItemsCheckBox.Name = "UseOtherItemsCheckBox";
            this.UseOtherItemsCheckBox.Size = new System.Drawing.Size(129, 20);
            this.UseOtherItemsCheckBox.TabIndex = 40;
            this.UseOtherItemsCheckBox.Text = "Uses Other Items";
            this.UseOtherItemsCheckBox.UseVisualStyleBackColor = true;
            this.UseOtherItemsCheckBox.CheckedChanged += new System.EventHandler(this.UseOtherItemsCheckBox_CheckedChanged);
            // 
            // OtherItemLabel
            // 
            this.OtherItemLabel.AutoSize = true;
            this.OtherItemLabel.Location = new System.Drawing.Point(7, 11);
            this.OtherItemLabel.Name = "OtherItemLabel";
            this.OtherItemLabel.Size = new System.Drawing.Size(33, 16);
            this.OtherItemLabel.TabIndex = 14;
            this.OtherItemLabel.Text = "Item";
            // 
            // OtherItemComboBox
            // 
            this.OtherItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OtherItemComboBox.FormattingEnabled = true;
            this.OtherItemComboBox.Location = new System.Drawing.Point(104, 8);
            this.OtherItemComboBox.Name = "OtherItemComboBox";
            this.OtherItemComboBox.Size = new System.Drawing.Size(150, 24);
            this.OtherItemComboBox.TabIndex = 13;
            this.OtherItemComboBox.Tag = "ItemComboBoxTag";
            // 
            // DecrementOtherItemAmountButton
            // 
            this.DecrementOtherItemAmountButton.Location = new System.Drawing.Point(103, 36);
            this.DecrementOtherItemAmountButton.Name = "DecrementOtherItemAmountButton";
            this.DecrementOtherItemAmountButton.Size = new System.Drawing.Size(50, 26);
            this.DecrementOtherItemAmountButton.TabIndex = 37;
            this.DecrementOtherItemAmountButton.Tag = "DecrementItemAmountTag";
            this.DecrementOtherItemAmountButton.Text = "-";
            this.DecrementOtherItemAmountButton.UseVisualStyleBackColor = true;
            this.DecrementOtherItemAmountButton.Click += new System.EventHandler(this.DecrementOtherItemAmountButton_Click);
            // 
            // IncrementOtherItemAmountButton
            // 
            this.IncrementOtherItemAmountButton.Location = new System.Drawing.Point(205, 36);
            this.IncrementOtherItemAmountButton.Name = "IncrementOtherItemAmountButton";
            this.IncrementOtherItemAmountButton.Size = new System.Drawing.Size(50, 26);
            this.IncrementOtherItemAmountButton.TabIndex = 36;
            this.IncrementOtherItemAmountButton.Tag = "IncrementItemAmountTag";
            this.IncrementOtherItemAmountButton.Text = "+";
            this.IncrementOtherItemAmountButton.UseVisualStyleBackColor = true;
            this.IncrementOtherItemAmountButton.Click += new System.EventHandler(this.IncrementOtherItemAmountButton_Click);
            // 
            // OtherItemAmountTextBox
            // 
            this.OtherItemAmountTextBox.Location = new System.Drawing.Point(158, 38);
            this.OtherItemAmountTextBox.Name = "OtherItemAmountTextBox";
            this.OtherItemAmountTextBox.ReadOnly = true;
            this.OtherItemAmountTextBox.Size = new System.Drawing.Size(43, 22);
            this.OtherItemAmountTextBox.TabIndex = 35;
            this.OtherItemAmountTextBox.Tag = "ItemAmountTag";
            this.OtherItemAmountTextBox.Text = "1";
            this.OtherItemAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OtherItemAmountLabel
            // 
            this.OtherItemAmountLabel.AutoSize = true;
            this.OtherItemAmountLabel.Location = new System.Drawing.Point(7, 41);
            this.OtherItemAmountLabel.Name = "OtherItemAmountLabel";
            this.OtherItemAmountLabel.Size = new System.Drawing.Size(53, 16);
            this.OtherItemAmountLabel.TabIndex = 34;
            this.OtherItemAmountLabel.Text = "Amount";
            // 
            // OtherItemsTabControl
            // 
            this.OtherItemsTabControl.Controls.Add(this.OtherItemsTab1);
            this.OtherItemsTabControl.Location = new System.Drawing.Point(281, 39);
            this.OtherItemsTabControl.Name = "OtherItemsTabControl";
            this.OtherItemsTabControl.SelectedIndex = 0;
            this.OtherItemsTabControl.Size = new System.Drawing.Size(273, 98);
            this.OtherItemsTabControl.TabIndex = 0;
            // 
            // OtherItemsTab1
            // 
            this.OtherItemsTab1.Controls.Add(this.OtherItemComboBox);
            this.OtherItemsTab1.Controls.Add(this.DecrementOtherItemAmountButton);
            this.OtherItemsTab1.Controls.Add(this.OtherItemLabel);
            this.OtherItemsTab1.Controls.Add(this.OtherItemAmountLabel);
            this.OtherItemsTab1.Controls.Add(this.IncrementOtherItemAmountButton);
            this.OtherItemsTab1.Controls.Add(this.OtherItemAmountTextBox);
            this.OtherItemsTab1.Location = new System.Drawing.Point(4, 25);
            this.OtherItemsTab1.Name = "OtherItemsTab1";
            this.OtherItemsTab1.Padding = new System.Windows.Forms.Padding(3);
            this.OtherItemsTab1.Size = new System.Drawing.Size(265, 69);
            this.OtherItemsTab1.TabIndex = 0;
            this.OtherItemsTab1.Text = "Item 1";
            this.OtherItemsTab1.UseVisualStyleBackColor = true;
            // 
            // DeleteTabButton
            // 
            this.DeleteTabButton.Location = new System.Drawing.Point(444, 9);
            this.DeleteTabButton.Name = "DeleteTabButton";
            this.DeleteTabButton.Size = new System.Drawing.Size(50, 26);
            this.DeleteTabButton.TabIndex = 38;
            this.DeleteTabButton.Text = "-";
            this.DeleteTabButton.UseVisualStyleBackColor = true;
            this.DeleteTabButton.Click += new System.EventHandler(this.DeleteTabButton_Click);
            // 
            // AddTabButton
            // 
            this.AddTabButton.Location = new System.Drawing.Point(500, 9);
            this.AddTabButton.Name = "AddTabButton";
            this.AddTabButton.Size = new System.Drawing.Size(50, 26);
            this.AddTabButton.TabIndex = 38;
            this.AddTabButton.Text = "+";
            this.AddTabButton.UseVisualStyleBackColor = true;
            this.AddTabButton.Click += new System.EventHandler(this.AddTabButton_Click);
            // 
            // EnhanceMatEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 201);
            this.Controls.Add(this.AddTabButton);
            this.Controls.Add(this.DeleteTabButton);
            this.Controls.Add(this.OtherItemsTabControl);
            this.Controls.Add(this.UseOtherItemsCheckBox);
            this.Controls.Add(this.IntermediateItemCheckBox);
            this.Controls.Add(this.SaleValueTextBox);
            this.Controls.Add(this.SaleValueLabel);
            this.Controls.Add(this.MarketplaceCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EnhanceMatEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Mat";
            this.OtherItemsTabControl.ResumeLayout(false);
            this.OtherItemsTab1.ResumeLayout(false);
            this.OtherItemsTab1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SaleValueTextBox;
        private System.Windows.Forms.Label SaleValueLabel;
        private System.Windows.Forms.CheckBox MarketplaceCheckBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.CheckBox IntermediateItemCheckBox;
        private System.Windows.Forms.CheckBox UseOtherItemsCheckBox;
        private System.Windows.Forms.Label OtherItemLabel;
        private System.Windows.Forms.ComboBox OtherItemComboBox;
        private System.Windows.Forms.Button DecrementOtherItemAmountButton;
        private System.Windows.Forms.Button IncrementOtherItemAmountButton;
        private System.Windows.Forms.TextBox OtherItemAmountTextBox;
        private System.Windows.Forms.Label OtherItemAmountLabel;
        private System.Windows.Forms.TabControl OtherItemsTabControl;
        private System.Windows.Forms.TabPage OtherItemsTab1;
        private System.Windows.Forms.Button DeleteTabButton;
        private System.Windows.Forms.Button AddTabButton;
    }
}