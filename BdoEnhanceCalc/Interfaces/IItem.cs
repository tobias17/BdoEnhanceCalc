using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BdoEnhanceCalc.Interfaces
{
    interface IItem
    {
        public string Name { get; }
        public Guid Guid { get; }
        public bool Marketplace { get; }
        public bool MapperIgnore { get; }
    }
}
