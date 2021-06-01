using BdoEnhanceCalc.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace BdoEnhanceCalc.Forms
{
    public partial class EnhanceMatEditForm : Form
    {
        public EnhanceMat Item { get; set; }

        private Dictionary<string, Guid> _guidNameMapper;
        private List<TabPage> otherItemsTabs;
        private List<int> otherItemsAmounts;

        public EnhanceMatEditForm(Dictionary<string, Guid> guidNameMapper, EnhanceMat item)
        {
            InitializeComponent();

            otherItemsTabs = new List<TabPage>();
            otherItemsAmounts = new List<int>();
            otherItemsTabs.Add(OtherItemsTab1);
            otherItemsAmounts.Add(1);

            _guidNameMapper = guidNameMapper;

            foreach (var name in guidNameMapper.Keys)
            {
                OtherItemComboBox.Items.Add(name);
            }
            if (item != null)
            {
                Item = item;

                NameTextBox.Text = item.Name;
                MarketplaceCheckBox.Checked = item.Marketplace;
                SaleValueTextBox.Enabled = !item.Marketplace;
                SaleValueTextBox.Text = item.SaleValue.ToString();
                IntermediateItemCheckBox.Checked = item.Intermediate;
                UseOtherItemsCheckBox.Enabled = !item.Intermediate;
                UseOtherItemsCheckBox.Checked = item.UseOtherItems;
                for (int i = 0; item.OtherItems != null && i < item.OtherItems.Count; i++)
                {
                    if (i > 0)
                    {
                        CreateTab();
                    }
                    foreach (var control in otherItemsTabs[i].Controls)
                    {
                        if (control is TextBox tb && (string)tb.Tag == "ItemAmountTag")
                        {
                            otherItemsAmounts[i] = item.OtherItems[i].Item2;
                            tb.Text = otherItemsAmounts[i].ToString();
                        }
                        if (control is ComboBox cb && (string)cb.Tag == "ItemComboBoxTag")
                        {
                            cb.SelectedIndex = GetIndexBasedOnGuid(item.OtherItems[i].Item1);
                        }
                    }
                }
            }
            else
            {
                Item = new EnhanceMat();
            }
            SetOtherItemSectionEnable(UseOtherItemsCheckBox.Checked);
        }

        private int GetIndexBasedOnGuid(Guid guid)
        {
            int cntr = 0;
            foreach (var key in _guidNameMapper.Keys)
            {
                if (_guidNameMapper[key] == guid)
                {
                    return cntr;
                }
                cntr += 1;
            }
            return -1;
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

            string name = NameTextBox.Text;

            int saleValue = 0;
            bool marketplace = MarketplaceCheckBox.Checked;
            if (!marketplace)
            {
                if (!TryConvertInt(SaleValueTextBox.Text, "Sale Value", out saleValue)) return false;
            }

            bool intermediate = IntermediateItemCheckBox.Checked;
            bool useOtherItems = UseOtherItemsCheckBox.Checked;
            var otherItems = new List<(Guid, int)>();
            if (!intermediate && useOtherItems)
            {
                for (int i = 0; i < otherItemsTabs.Count; i++)
                {
                    int amount = -1;
                    Guid? guid = null;
                    foreach (var control in otherItemsTabs[i].Controls)
                    {
                        if (control is TextBox tb && (string)tb.Tag == "ItemAmountTag")
                        {
                            if (!Int32.TryParse(tb.Text, out amount))
                            {
                                MessageBox.Show($"Other Item {i + 1} Amount conversion failed");
                                return false;
                            }
                        }
                        if (control is ComboBox cb && (string)cb.Tag == "ItemComboBoxTag")
                        {
                            if (String.IsNullOrEmpty(cb.Text))
                            {
                                MessageBox.Show($"Other Item {i + 1} needs an item selected");
                                return false;
                            }
                            if (!_guidNameMapper.ContainsKey(cb.Text))
                            {
                                MessageBox.Show($"Other Item {i + 1} could not find item in mapper");
                                return false;
                            }
                            guid = _guidNameMapper[cb.Text];
                        }
                    }
                    if (amount < 0)
                    {
                        MessageBox.Show($"Other Item {i + 1} could not find item amount element");
                        return false;
                    }
                    if (guid == null)
                    {
                        MessageBox.Show($"Other Item {i + 1} could not find other item element");
                        return false;
                    }
                    otherItems.Add(((Guid)guid, amount));
                }
            }

            Item.Name = name;
            Item.Marketplace = marketplace;
            if (!marketplace)
            {
                Item.SaleValue = saleValue;
            }
            Item.Intermediate = intermediate;
            Item.UseOtherItems = useOtherItems;
            Item.OtherItems = otherItems;

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

        private void IntermediateItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IntermediateItemCheckBox.Checked)
            {
                UseOtherItemsCheckBox.Checked = false;
            }
        }

        private void DeleteTabButton_Click(object sender, EventArgs e)
        {
            int tabIndex = OtherItemsTabControl.SelectedIndex;
            if (otherItemsTabs.Count > Math.Max(1, tabIndex))
            {
                if (tabIndex == otherItemsTabs.Count - 1)
                {
                    OtherItemsTabControl.SelectedIndex -= 1;
                }
                else
                {
                    OtherItemsTabControl.SelectedIndex += 1;
                }
                OtherItemsTabControl.TabPages.Remove(otherItemsTabs[tabIndex]);
                otherItemsTabs.RemoveAt(tabIndex);
                otherItemsAmounts.RemoveAt(tabIndex);
                LabelTabs();
            }
        }

        private void AddTabButton_Click(object sender, EventArgs e)
        {
            CreateTab();
        }

        private void CreateTab()
        {
            TabPage newPage = new TabPage();
            newPage.BackColor = System.Drawing.Color.White;
            foreach (var control in otherItemsTabs[0].Controls)
            {
                Control newControl = (Control)Utils.CloneObject(control);
                newPage.Controls.Add(newControl);
                if (newControl is Button b)
                {
                    if ((string)b.Tag == "DecrementItemAmountTag") b.Click += DecrementOtherItemAmountButton_Click;
                    if ((string)b.Tag == "IncrementItemAmountTag") b.Click += IncrementOtherItemAmountButton_Click;
                }
            }
            otherItemsTabs.Add(newPage);
            otherItemsAmounts.Add(1);
            OtherItemsTabControl.Controls.Add(newPage);
            LabelTabs();
        }

        private void LabelTabs()
        {
            for (int i = 0; i < otherItemsTabs.Count; i++)
            {
                otherItemsTabs[i].Text = $"Item {i + 1}";
            }
        }

        private void DecrementOtherItemAmountButton_Click(object sender, EventArgs e)
        {
            int tabIndex = OtherItemsTabControl.SelectedIndex;
            otherItemsAmounts[tabIndex] = Math.Max(1, otherItemsAmounts[tabIndex] - 1);
            WriteOtherItemAmount(tabIndex);
        }

        private void IncrementOtherItemAmountButton_Click(object sender, EventArgs e)
        {
            int tabIndex = OtherItemsTabControl.SelectedIndex;
            otherItemsAmounts[tabIndex] += 1;
            WriteOtherItemAmount(tabIndex);
        }

        private void WriteOtherItemAmount(int index)
        {
            foreach (var control in otherItemsTabs[index].Controls)
            {
                if (control is TextBox tb)
                {
                    tb.Text = otherItemsAmounts[index].ToString();
                }
            }
        }

        private void UseOtherItemsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetOtherItemSectionEnable(UseOtherItemsCheckBox.Checked);
            IntermediateItemCheckBox.Checked = false;
        }

        private void SetOtherItemSectionEnable(bool value)
        {
            DeleteTabButton.Enabled = value;
            AddTabButton.Enabled = value;
            OtherItemsTabControl.Enabled = value;
        }
    }
}
