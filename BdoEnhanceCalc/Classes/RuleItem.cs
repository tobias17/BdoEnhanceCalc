using Newtonsoft.Json;
using System;

namespace BdoEnhanceCalc.Classes
{
    public class RuleItem
    {
        public Guid? ItemGuid { get; set; }
        public bool UseAmount { get; set; }
        public int Value { get; set; }

        [JsonIgnore]
        public static RuleItem Default => new RuleItem()
        {
            ItemGuid = null,
            UseAmount = true,
            Value = 1,
        };
    }
}
