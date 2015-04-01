using System.Collections.Generic;
using ModulusChecking.Models;

namespace ModulusChecking.Steps.Calculators
{
    public abstract class DoubleAlternateCalculator : BaseModulusCalculator
    {
        protected DoubleAlternateCalculatorExceptionFive DoubleAlternateCalculatorExceptionFive;

        protected abstract int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings);
        protected abstract int GetWeightSumForStep(BankAccountDetails bankAccountDetails);

        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            return GetMappingException(bankAccountDetails.WeightMappings) == 5
                       ? DoubleAlternateCalculatorExceptionFive.Process(bankAccountDetails)
                       : (GetWeightSumForStep(bankAccountDetails)%Modulus) == 0;
        }
    }
}