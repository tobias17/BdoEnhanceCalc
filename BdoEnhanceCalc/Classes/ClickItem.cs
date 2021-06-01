using System;
using BdoEnhanceCalc.Classes;
using BdoEnhanceCalc.Interfaces;
using Newtonsoft.Json;

namespace BdoEnhanceCalc
{
    public class ClickItem : IItem
    {
        public ClickItem()
        {
            Guid = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Guid { get; set; }
        public double BaseChance { get; set; }
        public double ChancePer { get; set; }
        public int StackPer { get; set; }
        public bool UseClickItemToEnhance { get; set; } = false;
        public Guid? EnhancemeMat { get; set; } = null;
        public int MatsUsed { get; set; } = 1;
        public Guid? RepairItem { get; set; } = null;
        public int DurabilityLoss { get; set; } = 0;
        public Guid? FailureProd { get; set; } = null;
        public Guid? SucessProd { get; set; } = null;
        public bool HasSoftcap { get; set; } = false;
        public int ScStackStart { get; set; }
        public double ScChancePer { get; set; }
        public bool Sellable { get; set; } = false;
        public bool Marketplace { get; set; }
        public int SaleValue { get; set; }
        public int CronStones { get; set; }
        public string ImageName { get; set; }

        [JsonIgnore]
        public string[] SubItems => new string[] {
            Name,
            StackPer.ToString(),
            $"{Utils.ToPerc(BaseChance)}%",
            $"{Utils.ToPerc(ChancePer)}%",
            HasSoftcap ? ScStackStart.ToString() : "",
            HasSoftcap ? $"{Utils.ToPerc(ScChancePer)}%" : "",
            Sellable ? (Marketplace ? "Market" : Utils.CommaString(SaleValue)) : "",
            CronStones > 0 ? Utils.CommaString(CronStones) : "",
        };

        [JsonIgnore]
        public bool MapperIgnore => false;
    }
}
