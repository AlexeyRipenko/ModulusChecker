using System.Collections.Generic;
using System.Linq;
using ModulusChecking.Models;

namespace ModulusChecking.Loaders
{
    public class ModulusWeightTable : IModulusWeightTable
    {
        public List<IModulusWeightMapping> RuleMappings { get; private set; }

        public ModulusWeightTable(IRuleMappingSource ruleMappingSource)
        {
            RuleMappings = ruleMappingSource.GetModulusWeightMappings().ToList();
        }

        public IEnumerable<IModulusWeightMapping> GetRuleMappings(SortCode sortCode)
        {
            return RuleMappings.Where(rm => sortCode.DoubleValue >= rm.SortCodeStart.DoubleValue && sortCode.DoubleValue <= rm.SortCodeEnd.DoubleValue);
        }
    }
}