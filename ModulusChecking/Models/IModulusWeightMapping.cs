namespace ModulusChecking.Models
{
    /// <summary>
    /// Interface of modulus weight mapping
    /// </summary>
    public interface IModulusWeightMapping
    {
        SortCode SortCodeStart { get; }
        SortCode SortCodeEnd { get; }
        ModulusAlgorithm Algorithm { get; }
        int[] WeightValues { get; set; }
        int Exception { get; }
    }
}