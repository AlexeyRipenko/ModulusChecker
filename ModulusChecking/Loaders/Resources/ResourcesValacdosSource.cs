using System;
using System.Collections.Generic;
using ModulusChecking.Models;
using ModulusChecking.Models.Resources;

namespace ModulusChecking.Loaders.Resources
{
    public class ResourcesValacdosSource : IRuleMappingSource
    {
        private static readonly string[] Rows = Properties.Resources.valacdos.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);

        public IEnumerable<IModulusWeightMapping> GetModulusWeightMappings()
        {
            foreach (var row in Rows)
            {
                if (row.Length > 0) yield return new ResourcesModulusWeightMapping(row);
            }
        }
    }
}