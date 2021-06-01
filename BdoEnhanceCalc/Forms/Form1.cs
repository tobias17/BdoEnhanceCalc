using BdoEnhanceCalc.Classes;
using BdoEnhanceCalc.Forms;
using BdoEnhanceCalc.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BdoEnhanceCalc
{
    public partial class Form1 : Form
    {
        private List<ClickItem> clickItems;
        private List<RepairItem> repairItems;
        private List<EnhanceMat> enhanceMats;
        private Dictionary<Guid, int> marketPrices;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadClickItems();
            LoadRepairItems();
            LoadEnhanceMats();
            LoadClickRules();

            LoadMarketItems();
        }

        /*********************************
         **       CLICK ITEMS TAB       **
         *********************************/

        private void NewClickItemButton_Click(object sender, EventArgs e)
        {
            var itemForm = new ClickItemEditForm(
                    GetGuidNameMapper(clickItems.Select(x => (IItem)x).ToList()),
                    GetGuidNameMapper(repairItems.Select(x => (IItem)x).ToList()),
                    GetGuidNameMapper(enhanceMats.Select(x => (IItem)x).ToList()),
                    null);
            if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
            {
                clickItems.Add(itemForm.Item);
                SaveItem(itemForm.Item);
                ClickItemsListView.Items.Add(new ListViewItem(itemForm.Item.SubItems));
            }
        }

        private void EditClickItemButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedClickItemIndex();
            if (selectedIndex >= 0)
            {
                ClickItem selectedItem = clickItems[selectedIndex];
                var itemForm = new ClickItemEditForm(
                        GetGuidNameMapper(clickItems.Select(x => (IItem)x).ToList(), selectedItem.Guid),
                        GetGuidNameMapper(repairItems.Select(x => (IItem)x).ToList()),
                        GetGuidNameMapper(enhanceMats.Select(x => (IItem)x).ToList()),
                        selectedItem);
                if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
                {
                    clickItems[selectedIndex] = itemForm.Item;
                    SaveItem(itemForm.Item);
                    ClickItemsListView.Items.RemoveAt(selectedIndex);
                    ClickItemsListView.Items.Insert(selectedIndex, new ListViewItem(itemForm.Item.SubItems));
                }
            }
        }

        private void ClickItemListView_DoubleClick(object sender, MouseEventArgs e)
        {
            EditClickItemButton_Click(this, null);
        }

        private Dictionary<string, Guid> GetGuidNameMapper(List<IItem> itemList, Guid? ignoreGuid=null)
        {
            var mapper = new Dictionary<string, Guid>();
            foreach (var item in itemList)
            {
                if (item.Guid != ignoreGuid && !item.MapperIgnore)
                {
                    mapper[item.Name] = item.Guid;
                }
            }
            return mapper;
        }

        private void SaveItem(ClickItem item)
        {
            // create the folder directory if it does not exist
            if (!Directory.Exists(Utils.CLICK_ITEM_STORE_FOLDER))
            {
                Directory.CreateDirectory(Utils.CLICK_ITEM_STORE_FOLDER);
            }
            // create the file and save the item to it
            string filepath = Utils.ClickItemsPath(item.Guid.ToString());
            File.WriteAllText(filepath, JsonConvert.SerializeObject(item));
        }

        private void DeleteClickItemButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedClickItemIndex();
            if (selectedIndex >= 0)
            {
                ClickItem item = clickItems[selectedIndex];
                if (MessageBox.Show($"Are you sure you want to delete {item.Guid}?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clickItems.RemoveAt(selectedIndex);
                    ClickItemsListView.Items.RemoveAt(selectedIndex);
                    string filepath = Utils.ClickItemsPath(item.Guid.ToString());
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                }
            }
        }

        private int GetSelectedClickItemIndex()
        {
            if (ClickItemsListView.SelectedIndices.Count == 1 && ClickItemsListView.SelectedIndices[0] >= 0)
            {
                return ClickItemsListView.SelectedIndices[0];
            }
            return -1;
        }

        private void RefreshClickItemsButton_Click(object sender, EventArgs e)
        {
            LoadClickItems();
        }

        private void LoadClickItems()
        {
            clickItems = new List<ClickItem>();
            if (Directory.Exists(Utils.CLICK_ITEM_STORE_FOLDER))
            {
                foreach (string filepath in Directory.GetFiles(Utils.CLICK_ITEM_STORE_FOLDER))
                {
                    if (filepath.EndsWith(Utils.ITEM_FILE_EXT))
                    {
                        try
                        {
                            ClickItem newItem = JsonConvert.DeserializeObject<ClickItem>(File.ReadAllText(filepath));
                            clickItems.Add(newItem);
                        }
                        catch (Exception) { }
                    }
                }
            }
            clickItems = clickItems.OrderBy(x => x.Name).ToList();
            ClickItemsListView.Items.Clear();
            foreach (var item in clickItems)
            {
                ClickItemsListView.Items.Add(new ListViewItem(item.SubItems));
            }
        }

        /**********************************
         **       REPAIR ITEMS TAB       **
         **********************************/

        private void NewRepairItemButton_Click(object sender, EventArgs e)
        {
            var itemForm = new RepairItemEditForm(null);
            if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
            {
                repairItems.Add(itemForm.Item);
                SaveItem(itemForm.Item);
                RepairItemsListView.Items.Add(new ListViewItem(itemForm.Item.SubItems));
            }
        }

        private void EditRepairItemButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedRepairItemIndex();
            if (selectedIndex >= 0)
            {
                RepairItem selectedItem = repairItems[selectedIndex];
                var itemForm = new RepairItemEditForm(selectedItem);
                if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
                {
                    repairItems[selectedIndex] = itemForm.Item;
                    SaveItem(itemForm.Item);
                    RepairItemsListView.Items.RemoveAt(selectedIndex);
                    RepairItemsListView.Items.Insert(selectedIndex, new ListViewItem(itemForm.Item.SubItems));
                }
            }
        }

        private void RepairItemsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            EditRepairItemButton_Click(this, null);
        }

        private void SaveItem(RepairItem item)
        {
            // create the folder directory if it does not exist
            if (!Directory.Exists(Utils.REPAIR_ITEM_STORE_FOLDER))
            {
                Directory.CreateDirectory(Utils.REPAIR_ITEM_STORE_FOLDER);
            }
            // create the file and save the item to it
            string filepath = Utils.RepairItemsPath(item.Guid.ToString());
            File.WriteAllText(filepath, JsonConvert.SerializeObject(item));
        }

        private void DeleteRepairItemButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedRepairItemIndex();
            if (selectedIndex >= 0)
            {
                RepairItem item = repairItems[selectedIndex];
                if (MessageBox.Show($"Are you sure you want to delete {item.Guid}?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    repairItems.RemoveAt(selectedIndex);
                    RepairItemsListView.Items.RemoveAt(selectedIndex);
                    string filepath = Utils.RepairItemsPath(item.Guid.ToString());
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                }
            }
        }

        private int GetSelectedRepairItemIndex()
        {
            if (RepairItemsListView.SelectedIndices.Count == 1 && RepairItemsListView.SelectedIndices[0] >= 0)
            {
                return RepairItemsListView.SelectedIndices[0];
            }
            return -1;
        }

        private void RefreshRepairItemsButton_Click(object sender, EventArgs e)
        {
            LoadRepairItems();
        }

        private void LoadRepairItems()
        {
            repairItems = new List<RepairItem>();
            if (Directory.Exists(Utils.REPAIR_ITEM_STORE_FOLDER))
            {
                foreach (string filepath in Directory.GetFiles(Utils.REPAIR_ITEM_STORE_FOLDER))
                {
                    if (filepath.EndsWith(Utils.ITEM_FILE_EXT))
                    {
                        try
                        {
                            RepairItem newItem = JsonConvert.DeserializeObject<RepairItem>(File.ReadAllText(filepath));
                            repairItems.Add(newItem);
                        }
                        catch (Exception) { }
                    }
                }
            }
            repairItems = repairItems.OrderBy(x => x.Name).ToList();
            RepairItemsListView.Items.Clear();
            foreach (var item in repairItems)
            {
                RepairItemsListView.Items.Add(new ListViewItem(item.SubItems));
            }
        }

        /**********************************
         **       ENHANCE MATS TAB       **
         **********************************/

        private void NewEnhanceMatButton_Click(object sender, EventArgs e)
        {
            var itemForm = new EnhanceMatEditForm(GetGuidNameMapper(enhanceMats.Select(x => (IItem)x).ToList()), null);
            if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
            {
                enhanceMats.Add(itemForm.Item);
                SaveItem(itemForm.Item);
                EnhanceMatsListView.Items.Add(new ListViewItem(itemForm.Item.SubItems));
            }
        }

        private void EditEnhanceMatButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedEnhanceMatIndex();
            if (selectedIndex >= 0)
            {
                EnhanceMat selectedItem = enhanceMats[selectedIndex];
                var itemForm = new EnhanceMatEditForm(GetGuidNameMapper(enhanceMats.Select(x => (IItem)x).ToList(), selectedItem.Guid), selectedItem);
                if (itemForm.ShowDialog() == DialogResult.OK && itemForm.Item != null)
                {
                    enhanceMats[selectedIndex] = itemForm.Item;
                    SaveItem(itemForm.Item);
                    EnhanceMatsListView.Items.RemoveAt(selectedIndex);
                    EnhanceMatsListView.Items.Insert(selectedIndex, new ListViewItem(itemForm.Item.SubItems));
                }
            }
        }

        private void EnhanceMatsListView_DoubleClick(object sender, MouseEventArgs e)
        {
            EditEnhanceMatButton_Click(this, null);
        }

        private void SaveItem(EnhanceMat item)
        {
            // create the folder directory if it does not exist
            if (!Directory.Exists(Utils.ENHANCE_MAT_STORE_FOLDER))
            {
                Directory.CreateDirectory(Utils.ENHANCE_MAT_STORE_FOLDER);
            }
            // create the file and save the item to it
            string filepath = Utils.EnhanceMatsPath(item.Guid.ToString());
            File.WriteAllText(filepath, JsonConvert.SerializeObject(item));
        }

        private void DeleteEnhanceMatButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = GetSelectedEnhanceMatIndex();
            if (selectedIndex >= 0)
            {
                EnhanceMat item = enhanceMats[selectedIndex];
                if (MessageBox.Show($"Are you sure you want to delete {item.Name}?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    enhanceMats.RemoveAt(selectedIndex);
                    EnhanceMatsListView.Items.RemoveAt(selectedIndex);
                    string filepath = Utils.EnhanceMatsPath(item.Guid.ToString());
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                    }
                }
            }
        }

        private int GetSelectedEnhanceMatIndex()
        {
            if (EnhanceMatsListView.SelectedIndices.Count == 1 && EnhanceMatsListView.SelectedIndices[0] >= 0)
            {
                return EnhanceMatsListView.SelectedIndices[0];
            }
            return -1;
        }

        private void RefreshEnhanceMatsButton_Click(object sender, EventArgs e)
        {
            LoadEnhanceMats();
        }

        private void LoadEnhanceMats()
        {
            enhanceMats = new List<EnhanceMat>();
            if (Directory.Exists(Utils.ENHANCE_MAT_STORE_FOLDER))
            {
                foreach (string filepath in Directory.GetFiles(Utils.ENHANCE_MAT_STORE_FOLDER))
                {
                    if (filepath.EndsWith(Utils.ITEM_FILE_EXT))
                    {
                        try
                        {
                            EnhanceMat newItem = JsonConvert.DeserializeObject<EnhanceMat>(File.ReadAllText(filepath));
                            enhanceMats.Add(newItem);
                        }
                        catch (Exception) { }
                    }
                }
            }
            enhanceMats = enhanceMats.OrderBy(x => x.Name).ToList();
            EnhanceMatsListView.Items.Clear();
            foreach (var item in enhanceMats)
            {
                EnhanceMatsListView.Items.Add(new ListViewItem(item.SubItems));
            }
        }


        /*********************************
         **      MARKET PRICES TAB      **
         *********************************/

        private void LoadMarketItems()
        {
            // clear market prices
            marketPrices = new Dictionary<Guid, int>();

            // check to see if there is information on disk
            Dictionary<Guid, int> filePrices = null;
            string filepath = Utils.MarketPricesPath;
            if (File.Exists(filepath))
            {
                try
                {
                    filePrices = JsonConvert.DeserializeObject<Dictionary<Guid, int>>(File.ReadAllText(filepath));
                }
                catch (Exception) { }
            }

            // loop through all items and add them to market prices, loading disk saved prices when possible
            foreach (var itemList in new List<IItem>[] {
                clickItems.Select(x => (IItem)x).ToList(),
                repairItems.Select(x => (IItem)x).ToList(),
                enhanceMats.Select(x => (IItem)x).ToList() })
            {
                foreach (var item in itemList)
                {
                    if (item.Marketplace && !marketPrices.ContainsKey(item.Guid))
                    {
                        if (filePrices != null && filePrices.ContainsKey(item.Guid))
                        {
                            marketPrices[item.Guid] = filePrices[item.Guid];
                        }
                        else
                        {
                            marketPrices[item.Guid] = 0;
                        }
                    }
                }
            }

            // update the data grid view
            MarketPricesDataGridView.Rows.Clear();
            foreach (var key in marketPrices.Keys.OrderBy(x => GetName(x)))
            {
                MarketPricesDataGridView.Rows.Add(GetName(key), marketPrices[key], key);
            }
            MarketChangesLabel.Visible = false;
        }

        private string GetName(Guid guid)
        {
            foreach (var item in clickItems)
            {
                if (item.Guid == guid) return item.Name;
            }
            foreach (var item in repairItems)
            {
                if (item.Guid == guid) return item.Name;
            }
            foreach (var item in enhanceMats)
            {
                if (item.Guid == guid) return item.Name;
            }
            return "Name not found";
        }

        private void MarketPrices_TextChanged(object sender, DataGridViewCellEventArgs e)
        {
            MarketChangesLabel.Visible = true;
        }

        private void SaveMarketPricesButton_Click(object sender, EventArgs e)
        {
            var newPrices = new Dictionary<Guid, int>();
            for (int i = 0; i < MarketPricesDataGridView.Rows.Count; i++)
            {
                Guid guid = new Guid(MarketPricesDataGridView[2, i].Value.ToString());
                if (marketPrices.ContainsKey(guid))
                {
                    if (!Int32.TryParse(MarketPricesDataGridView[1, i].Value.ToString(), out int price))
                    {
                        MessageBox.Show($"Market Price for {MarketPricesDataGridView[0, i].Value} is not a valid number");
                        return;
                    }
                    newPrices[guid] = price;
                }
            }

            foreach (var key in marketPrices.Keys)
            {
                if (!newPrices.ContainsKey(key))
                {
                    MessageBox.Show("Not all values grabbed!");
                }
            }
            marketPrices = newPrices;

            string filepath = Utils.MarketPricesPath;
            if (Directory.Exists(Utils.MARKET_PRICES_STORE_FOLDER))
            {
                Directory.CreateDirectory(Utils.MARKET_PRICES_STORE_FOLDER);
            }
            File.WriteAllText(filepath, JsonConvert.SerializeObject(marketPrices));
            MarketChangesLabel.Visible = false;
        }

        private void ReloadMarketPricesButton_Click(object sender, EventArgs e)
        {
            LoadMarketItems();
        }


        /*********************************
         **       CLICK RULES TAB       **
         *********************************/

        private List<ClickRule> clickRules = null;
        private bool isEditingRule = false;

        private void LoadClickRules()
        {
            clickRules = new List<ClickRule>();
            if (Directory.Exists(Utils.CLICK_RULES_STORE_FOLDER))
            {
                foreach (var filepath in Directory.GetFiles(Utils.CLICK_RULES_STORE_FOLDER))
                {
                    if (filepath.EndsWith(Utils.ITEM_FILE_EXT))
                    {
                        try
                        {
                            var newItem = JsonConvert.DeserializeObject<ClickRule>(File.ReadAllText(filepath));
                            clickRules.Add(newItem);
                        }
                        catch (Exception) { }
                    }
                }
            }

            clickRules = clickRules.OrderBy(x => x.Name).ToList();

            ClickRuleComboBox.Items.Clear();
            ClickRuleComboBox.Items.Add("None");
            ClickRuleComboBox.SelectedIndex = 0;
            foreach (var rule in clickRules)
            {
                ClickRuleComboBox.Items.Add(rule.Name);
            }
        }

        private void NewClickRuleButton_Click(object sender, EventArgs e)
        {
            if (!isEditingRule)
            {
                string name = InputBox.Show("Click Rule Name");
                if (!String.IsNullOrWhiteSpace(name))
                {
                    if (clickRules.Select(x => x.Name).Contains(name))
                    {
                        MessageBox.Show("A rule with this name already exists");
                        return;
                    }

                    clickRules.Add(new ClickRule() { Name = name });
                    ClickRuleComboBox.Items.Add(name);
                    ClickRuleComboBox.SelectedIndex = ClickRuleComboBox.Items.Count - 1;
                    isEditingRule = true;
                }
            }
        }
    }
}
