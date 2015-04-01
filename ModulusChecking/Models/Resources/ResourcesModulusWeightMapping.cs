using System;

namespace ModulusChecking.Models.Resources
{
    public class ResourcesModulusWeightMapping : ModulusWeightMappingBase
    {
        public ResourcesModulusWeightMapping(string row)
        {
            WeightValues = new int[14];
            var items = row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SortCodeStart = new SortCode(items[0]);
            SortCodeEnd = new SortCode(items[1]);
            Algorithm = (ModulusAlgorithm)Enum.Parse(typeof(ModulusAlgorithm), items[2], true);
            for (var i = 3; i < 17; i++)
            {
                WeightValues[i - 3] = Int16.Parse(items[i]);
            }
            if (items.Length == 18)
            {
                Exception = Int16.Parse(items[17]);
            }
            else
            {
                Exception = -1;
            }
        }
    }
}