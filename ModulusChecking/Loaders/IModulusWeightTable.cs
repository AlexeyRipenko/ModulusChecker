using System.Collections.Generic;
using ModulusChecking.Models;

namespace ModulusChecking.Loaders
{
    public interface IModulusWeightTable
    {
        List<IModulusWeightMapping> RuleMappings { get; }
        IEnumerable<IModulusWeightMapping> GetRuleMappings(SortCode sortCode);
    }
}