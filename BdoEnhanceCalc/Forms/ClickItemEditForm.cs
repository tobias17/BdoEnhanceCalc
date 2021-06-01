using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BdoEnhanceCalc.Forms
{
    public partial class ClickItemEditForm : Form
    {
        public ClickItem Item { get; set; }

        private readonly Dictionary<string, Guid> _clickGuidNameMapper;
        private readonly Dictionary<string, Guid> _repairGuidNameMapper;
        private readonly Dictionary<string, Guid> _matGuidNameMapper;
        private readonly string _incomingName;
        private int _matsUsed = 1;

        public ClickItemEditForm(Dictionary<string, Guid> clickGuidNameMapper, Dictionary<string, Guid> repairGuidNameMapper, Dictionary<string, Guid> matGuidNameMapper, ClickItem item)
        {
            InitializeComponent();

            _clickGuidNameMapper = clickGuidNameMapper;
            _repairGuidNameMapper = repairGuidNameMapper;
            _matGuidNameMapper = matGuidNameMapper;

            foreach (string name in clickGuidNameMapper.Keys)
            {
                SuccessProdComboBox.Items.Add(name);
                FailureProdComboBox.Items.Add(name);
            }
            foreach (string name in repairGuidNameMapper.Keys)
            {
                RepairItemComboBox.Items.Add(name);
            }
            RepairItemComboBox.SelectedIndex = 0;
            foreach (string name in (item.UseClickItemToEnhance ? clickGuidNameMapper.Keys : matGuidNameMapper.Keys))
            {
                EnhanceMatComboBox.Items.Add(name);
            }
            if (item != null)
            {
                _incomingName = item.Name;
                Item = item;

                // left side
                NameTextBox.Text = item.Name;
                BaseChanceTextBox.Text = $"{Math.Round(item.BaseChance * 100, 2)}%";
                ChancePerTextBox.Text = $"{Math.Round(item.ChancePer * 100, 2)}%";
                StackPerTextBox.Text = item.StackPer.ToString();
                UseClickItemCheckBox.Checked = item.UseClickItemToEnhance;
                if (item.UseClickItemToEnhance)
                    SetComboBoxToGuid(EnhanceMatComboBox, item.EnhancemeMat, _matGuidNameMapper, 0);
                else
                    SetComboBoxToGuid(EnhanceMatComboBox, item.EnhancemeMat, _clickGuidNameMapper, 0);
                _matsUsed = item.MatsUsed;
                MatsUsedTextBox.Text = _matsUsed.ToString();
                SetComboBoxToGuid(RepairItemComboBox, item.RepairItem, _repairGuidNameMapper, 0);
                DurabilityLossTextBox.Text = item.DurabilityLoss.ToString();
                SetComboBoxToGuid(SuccessProdComboBox, item.SucessProd, _clickGuidNameMapper, 1);
                SetComboBoxToGuid(FailureProdComboBox, item.FailureProd, _clickGuidNameMapper, 1);

                // right side
                InputSoftcapCheckBox.Checked = item.HasSoftcap;
                ScStatsGroupBox.Enabled = item.HasSoftcap;
                if (item.HasSoftcap)
                {
                    ScStackStartTextBox.Text = item.ScStackStart.ToString();
                    ScChancePerTextBox.Text = $"{Math.Round(item.ScChancePer * 100, 2)}%";
                }
                SellableCheckBox.Checked = item.Sellable;
                if (item.Sellable)
                {
                    SellMarketplaceCheckBox.Checked = item.Marketplace;
                    if (item.SaleValue != 0)
                    {
                        SaleValueTextBox.Text = item.SaleValue.ToString();
                    }
                }
                SellableCheckBox_CheckedChanged(this, null);
                if (item.CronStones > 0)
                {
                    CronStonesTextBox.Text = item.CronStones.ToString();
                }
                ImageNameTextBox.Text = item.ImageName;
            }
            else
            {
                _incomingName = "";
                Item = new ClickItem();
            }
        }

        private void SetComboBoxToGuid(ComboBox cb, Guid? guid, Dictionary<string, Guid> guidNameMapper, int startIndex)
        {
            if (guid == null)
            {
                cb.SelectedIndex = 0;
            }
            else
            {
                if (guid == Item.Guid)
                {
                    cb.SelectedIndex = 1;
                }
                int cntr = startIndex;
                foreach (var key in guidNameMapper.Keys)
                {
                    cntr += 1;
                    if (guidNameMapper[key] == (Guid)guid)
                    {
                        cb.SelectedIndex = cntr;
                    }
                }
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
            // left side
            if (!CheckTextBox(NameTextBox, "Name")) return false;
            if (!CheckTextBox(BaseChanceTextBox, "Base Chance")) return false;
            if (!CheckTextBox(ChancePerTextBox, "Chance Per")) return false;
            if (!CheckTextBox(StackPerTextBox, "Stack Per")) return false;
            if (!CheckTextBox(DurabilityLossTextBox, "Durability Loss")) return false;

            string name = NameTextBox.Text;
            if (name != _incomingName && _clickGuidNameMapper.ContainsKey(name))
            {
                MessageBox.Show("Item Name already in use");
                return false;
            }

            if (!TryConvertPercent(BaseChanceTextBox.Text, "Base Chance", out double baseChance)) return false;

            if (!TryConvertPercent(ChancePerTextBox.Text, "Chance Per", out double chancePer)) return false;

            if (!TryConvertInt(StackPerTextBox.Text, "Stack Per", out int stackPer)) return false;
            if (stackPer < 0)
            {
                MessageBox.Show($"Item Stack Per must be greater than 0");
                return false;
            }

            bool useClickItem = UseClickItemCheckBox.Checked;
            if (!TryConvertEnhanceMat(EnhanceMatComboBox, "Enhancement Mat", out Guid? enhancementMatGuid)) return false;

            if (!TryConvertRepairItem(RepairItemComboBox, "Repair Item", out Guid? repairItemGuid)) return false;

            if (!TryConvertInt(DurabilityLossTextBox.Text, "Durability Loss", out int durabilityLoss)) return false;

            if (!TryConvertProd(FailureProdComboBox, "Failure Prod", out Guid? failureProdGuid)) return false;

            if (!TryConvertProd(SuccessProdComboBox, "Success Prod", out Guid? successProdGuid)) return false;

            // right side
            int scStackStart = 0;
            double scChancePer = 0;
            bool hasSoftcap = InputSoftcapCheckBox.Checked;
            if (hasSoftcap)
            {
                if (!CheckTextBox(ScStackStartTextBox, "Softcap Stack Start")) return false;
                if (!CheckTextBox(ScChancePerTextBox, "Softcap Chance Per")) return false;

                if (!TryConvertInt(ScStackStartTextBox.Text, "Softcap Stack Start", out scStackStart)) return false;
                if (!TryConvertPercent(ScChancePerTextBox.Text, "Softcap Chance Per", out scChancePer)) return false;
            }
            bool sellable = SellableCheckBox.Checked;
            bool marketplace = false;
            int saleValue = 0;
            if (sellable)
            {
                marketplace = SellMarketplaceCheckBox.Checked;
                if (!marketplace)
                {
                    if (!TryConvertInt(SaleValueTextBox.Text, "Sell Amount", out saleValue)) return false;
                }
            }

            int cronStones = 0;
            if (!String.IsNullOrEmpty(CronStonesTextBox.Text))
            {
                if (!TryConvertInt(CronStonesTextBox.Text, "Cron Stones", out cronStones)) return false;
                if (cronStones < 1)
                {
                    MessageBox.Show("Item Cron Stones must be greater than 0");
                }
            }

            string imageName = ImageNameTextBox.Text;

            // set item properties
            Item.Name = name;
            Item.BaseChance = baseChance;
            Item.ChancePer = chancePer;
            Item.StackPer = stackPer;
            Item.EnhancemeMat = enhancementMatGuid;
            Item.MatsUsed = _matsUsed;
            Item.RepairItem = repairItemGuid;
            Item.DurabilityLoss = durabilityLoss;
            Item.FailureProd = failureProdGuid;
            Item.SucessProd = successProdGuid;

            Item.HasSoftcap = hasSoftcap;
            if (hasSoftcap)
            {
                Item.ScStackStart = scStackStart;
                Item.ScChancePer = scChancePer;
            }
            Item.Sellable = sellable;
            if (sellable)
            {
                Item.Marketplace = marketplace;
                if (!marketplace)
                {
                    Item.SaleValue = saleValue;
                }
            }
            Item.CronStones = cronStones;
            Item.ImageName = imageName;
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

        private bool TryConvertPercent(string text, string name, out double perc)
        {
            bool divide = text.EndsWith("%");
            if (divide)
            {
                text = text.Substring(0, text.Length - 1);
            }
            if (!Double.TryParse(text, out perc))
            {
                MessageBox.Show($"Item {name} must be a valid percent");
                return false;
            }
            if (divide)
            {
                perc /= 100.0;
            }
            if (perc < 0.0)
            {
                MessageBox.Show($"Item {name} must be greater than 0%");
                return false;
            }
            if (perc > 1.0)
            {
                MessageBox.Show($"Item {name} must be less than 100%");
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

        private bool TryConvertProd(ComboBox cb, string name, out Guid? guid)
        {
            if (cb.SelectedIndex == 0)
            {
                guid = null;
                return true;
            }
            if (cb.SelectedIndex == 1)
            {
                guid = Item.Guid;
                return true;
            }
            if (_clickGuidNameMapper.ContainsKey(cb.Text))
            {
                guid = _clickGuidNameMapper[cb.Text];
                return true;
            }
            guid = null;
            MessageBox.Show($"An Item {name} must be selected");
            return false;
        }

        private bool TryConvertRepairItem(ComboBox cb, string name, out Guid? guid)
        {
            if (cb.SelectedIndex == 0)
            {
                guid = null;
                return true;
            }
            if (_repairGuidNameMapper.ContainsKey(cb.Text))
            {
                guid = _repairGuidNameMapper[cb.Text];
                return true;
            }
            guid = null;
            MessageBox.Show($"An Item {name} must be selected");
            return false;
        }

        private bool TryConvertEnhanceMat(ComboBox cb, string name, out Guid? guid)
        {
            if (cb.SelectedIndex == 0)
            {
                guid = null;
                return true;
            }
            if (_matGuidNameMapper.ContainsKey(cb.Text))
            {
                guid = _matGuidNameMapper[cb.Text];
                return true;
            }
            guid = null;
            MessageBox.Show($"An Item {name} must be selected");
            return false;
        }

        private void InputSoftcapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ScStatsGroupBox.Enabled = InputSoftcapCheckBox.Checked;
        }

        private void SellableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SellMarketplaceCheckBox.Enabled = SellableCheckBox.Checked;
            SaleValueTextBox.Enabled = SellableCheckBox.Checked ? !SellMarketplaceCheckBox.Checked : false;
        }

        private void SellMarketplaceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaleValueTextBox.Enabled = !SellMarketplaceCheckBox.Checked;
        }

        private void MatsUsedDecrementButton_Click(object sender, EventArgs e)
        {
            _matsUsed = Math.Max(1, _matsUsed - 1);
            MatsUsedTextBox.Text = _matsUsed.ToString();
        }

        private void MatsUsedIncrementButton_Click(object sender, EventArgs e)
        {
            _matsUsed += 1;
            MatsUsedTextBox.Text = _matsUsed.ToString();
        }

        private void UseClickItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            EnhanceMatComboBox.Items.Clear();
            EnhanceMatComboBox.Items.Add("None");
            foreach (string name in (UseClickItemCheckBox.Checked ? _clickGuidNameMapper.Keys : _matGuidNameMapper.Keys))
            {
                EnhanceMatComboBox.Items.Add(name);
            }
            EnhanceMatComboBox.SelectedIndex = 0;
        }
    }
}
