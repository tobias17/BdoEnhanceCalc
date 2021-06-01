using BdoEnhanceCalc.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BdoEnhanceCalc.Forms
{
    public partial class RepairItemEditForm : Form
    {
        public RepairItem Item { get; set; }

        public RepairItemEditForm(RepairItem item)
        {
            InitializeComponent();

            if (item != null)
            {
                Item = item;

                NameTextBox.Text = item.Name;
                RepairAmountTextBox.Text = item.RepairAmount.ToString();
                MarketplaceCheckBox.Checked = item.Marketplace;
                SaleValueTextBox.Enabled = !item.Marketplace;
                if (item.SaleValue != 0)
                {
                    SaleValueTextBox.Text = item.SaleValue.ToString();
                }
            }
            else
            {
                Item = new RepairItem();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateItem())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateItem()
        {
            if (!CheckTextBox(NameTextBox, "Name")) return false;
            if (!CheckTextBox(RepairAmountTextBox, "Repair Amount")) return false;

            string name = NameTextBox.Text;

            if (!TryConvertInt(RepairAmountTextBox.Text, "Repair Amount", out int repairAmount)) return false;
            if (repairAmount < 1)
            {
                MessageBox.Show("Item Repair Amount must be greater than 0");
                return false;
            }

            int saleValue = 0;
            bool marketplace = MarketplaceCheckBox.Checked;
            if (!marketplace)
            {
                if (!TryConvertInt(SaleValueTextBox.Text, "Sale Value", out saleValue)) return false;
            }

            Item.Name = name;
            Item.RepairAmount = repairAmount;
            Item.Marketplace = marketplace;
            if (!marketplace)
            {
                Item.SaleValue = saleValue;
            }

            return true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckTextBox(TextBox tb, string name)
        {
            if (String.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"Item {name} must have value and not be white space");
                return false;
            }
            return true;
        }

        private bool TryConvertInt(string text, string name, out int amount)
        {
            if (!Int32.TryParse(text, out amount))
            {
                MessageBox.Show($"Item {name} must be a valid number");
                return false;
            }
            return true;
        }

        private void MarketplaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaleValueTextBox.Enabled = !MarketplaceCheckBox.Checked;
        }
    }
}
