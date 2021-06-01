using Newtonsoft.Json;
using System;
using BdoEnhanceCalc.Interfaces;

namespace BdoEnhanceCalc.Classes
{
    public class RepairItem : IItem
    {
        public RepairItem()
        {
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int RepairAmount { get; set; }
        public bool Marketplace { get; set; }
        public int SaleValue { get; set; }

        [JsonIgnore]
        public string[] SubItems => new string[] {
            Name,
            RepairAmount.ToString(),
            Marketplace ? "Market" : Utils.CommaString(SaleValue),
        };

        [JsonIgnore]
        public bool MapperIgnore => false;
    }
}
