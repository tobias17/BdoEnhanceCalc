using BdoEnhanceCalc.Interfaces;
using System;
using System.Collections.Generic;

namespace BdoEnhanceCalc.Classes
{
    public class ClickRule
    {
        public ClickRule()
        {
            Guid = Guid.NewGuid();
            Items = new List<RuleItem>();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public List<RuleItem> Items { get; set; }
    }
}
