using System.Collections.Generic;
using ModulusChecking.Models;
using ModulusChecking.ModulusChecks;

namespace ModulusChecking.Steps.Calculators
{
    public class SecondDoubleAlternateCalculator : DoubleAlternateCalculator
    {
        public SecondDoubleAlternateCalculator()
        {
            DoubleAlternateCalculatorExceptionFive = new SecondDoubleAlternateCalculatorExceptionFive();
        }

        public SecondDoubleAlternateCalculator(SecondDoubleAlternateCalculatorExceptionFive exceptionFive)
        {
            DoubleAlternateCalculatorExceptionFive = exceptionFive;
        }

        protected override int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings)
        {
            return weightMappings.Second().Exception;
        }

        protected override int GetWeightSumForStep(BankAccountDetails bankAccountDetails)
        {
            return new DoubleAlternateModulusCheck().GetModulusSum(bankAccountDetails,
                bankAccountDetails.WeightMappings
                    .Second());
        }
    }
}