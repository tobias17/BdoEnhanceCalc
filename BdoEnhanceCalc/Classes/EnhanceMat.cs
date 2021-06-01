using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using BdoEnhanceCalc.Interfaces;

namespace BdoEnhanceCalc.Classes
{
    public class EnhanceMat : IItem
    {
        public EnhanceMat()
        {
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public bool Marketplace { get; set; }
        public int SaleValue { get; set; }
        public bool Intermediate { get; set; }
        public bool UseOtherItems { get; set; }
        public List<(Guid, int)> OtherItems { get; set; }

        [JsonIgnore]
        public string[] SubItems => new string[] {
            Name,
            Marketplace ? "Market" : Utils.CommaString(SaleValue),
            Intermediate ? "Yes" : "No",
            UseOtherItems ? OtherItems.Count.ToString() : "",
        };

        [JsonIgnore]
        public bool MapperIgnore => Intermediate;
    }
}
