using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using BF = System.Reflection.BindingFlags;

namespace BdoEnhanceCalc.Classes
{
    public static class Utils
    {
        public const string CLICK_ITEM_STORE_FOLDER = "resources/click_items";
        public const string REPAIR_ITEM_STORE_FOLDER = "resources/repair_items";
        public const string ENHANCE_MAT_STORE_FOLDER = "resources/enhance_mats";
        public const string MARKET_PRICES_STORE_FOLDER = "resources";
        public const string MARKET_PRICES_FILE_NAME = "market_prices";
        public const string CLICK_RULES_STORE_FOLDER = "resources/click_rules";
        public const string ITEM_FILE_EXT = ".json";

        public static string ClickItemsPath(string filename) => $"{CLICK_ITEM_STORE_FOLDER}/{filename}{ITEM_FILE_EXT}";
        public static string RepairItemsPath(string filename) => $"{REPAIR_ITEM_STORE_FOLDER}/{filename}{ITEM_FILE_EXT}";
        public static string EnhanceMatsPath(string filename) => $"{ENHANCE_MAT_STORE_FOLDER}/{filename}{ITEM_FILE_EXT}";
        public static string MarketPricesPath => $"{MARKET_PRICES_STORE_FOLDER}/{MARKET_PRICES_FILE_NAME}{ITEM_FILE_EXT}";
        public static string ClickRulesPath(string filename) => $"{CLICK_RULES_STORE_FOLDER}/{filename}{ITEM_FILE_EXT}";

        public const string IMAGE_STORE_PATH = "resources/images";

        public static double ToPerc(double val, int decimalPlaces = 2)
        {
            return Math.Round(val * 100, decimalPlaces);
        }

        public static string CommaString(int val)
        {
            return String.Format("{0:n0}", val);
        }

        public static object CloneObject(object o)
        {
            if (o is Button ob)
            {
                Button b = new Button();
                b.Size = ob.Size;
                b.Location = ob.Location;
                b.Text = ob.Text;
                b.BackColor = ob.BackColor;
                b.Tag = ob.Tag;
                return b;
            }
            if (o is Label ol)
            {
                Label l = new Label();
                l.Size = ol.Size;
                l.Location = ol.Location;
                l.Text = ol.Text;
                l.BackColor = ol.BackColor;
                l.Tag = ol.Tag;
                return l;
            }
            if (o is ComboBox oc)
            {
                ComboBox c = new ComboBox();
                c.Size = oc.Size;
                c.Location = oc.Location;
                c.Text = oc.Text;
                c.DropDownStyle = oc.DropDownStyle;
                c.BackColor = oc.BackColor;
                c.Tag = oc.Tag;
                foreach (var item in oc.Items)
                {
                    c.Items.Add(item);
                }
                return c;
            }
            if (o is TextBox ot)
            {
                TextBox t = new TextBox();
                t.Size = ot.Size;
                t.Location = ot.Location;
                t.Text = "1";
                t.ReadOnly = ot.ReadOnly;
                t.TextAlign = ot.TextAlign;
                t.BackColor = ot.BackColor;
                t.Tag = ot.Tag;
                return t;
            }

            return null;
        }
    }
}
