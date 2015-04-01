using System;

namespace ModulusChecking.Models
{
    public class ModulusWeightMappingBase : IModulusWeightMapping
    {
        public SortCode SortCodeStart { get; set; }
        public SortCode SortCodeEnd { get; set; }
        public ModulusAlgorithm Algorithm { get; set; }
        public int[] WeightValues { get; set; }
        public int Exception { get; set; }

        public ModulusWeightMappingBase()
        {
            
        }

        public ModulusWeightMappingBase(IModulusWeightMapping original)
        {
            WeightValues = new int[14];
            Array.Copy(original.WeightValues, WeightValues, 14);
            Algorithm = original.Algorithm;
            SortCodeStart = original.SortCodeStart;
            SortCodeEnd = original.SortCodeEnd;
            Exception = original.Exception;
        }
    }
}