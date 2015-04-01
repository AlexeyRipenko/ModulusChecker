using System.Collections.Generic;
using System.Linq;
using ModulusChecking.Models;
using ModulusChecking.ModulusChecks;

namespace ModulusChecking.Steps.Calculators
{
    public class FirstDoubleAlternateCalculator : DoubleAlternateCalculator
    {
        public FirstDoubleAlternateCalculator()
        {
            DoubleAlternateCalculatorExceptionFive = new FirstDoubleAlternateCalculatorExceptionFive();
        }

        public FirstDoubleAlternateCalculator(FirstDoubleAlternateCalculatorExceptionFive exceptionFive)
        {
            DoubleAlternateCalculatorExceptionFive = exceptionFive;
        }

        protected override int GetMappingException(IEnumerable<IModulusWeightMapping> weightMappings)
        {
            return weightMappings.First().Exception;
        }

        protected override int GetWeightSumForStep(BankAccountDetails bankAccountDetails)
        {
            return new DoubleAlternateModulusCheck().GetModulusSum(bankAccountDetails,
                bankAccountDetails.WeightMappings
                    .First());
        }
    }
}