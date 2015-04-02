using ModulusChecking.Loaders;
using ModulusChecking.Models;

namespace ModulusChecking.Steps.Calculators
{
    public class StandardModulusExceptionFourteenCalculator : FirstStandardModulusElevenCalculator
    {
        public override bool Process(BankAccountDetails bankAccountDetails)
        {
            if (!bankAccountDetails.AccountNumber.IsValidCouttsNumber)
            {
                return false;
            }
            bankAccountDetails.AccountNumber.SetElementAt(7, '0');
            return base.Process(bankAccountDetails);
        }

        public StandardModulusExceptionFourteenCalculator(ISortCodeSubstitutionSource sortCodeSubstitutionSource)
            : base(sortCodeSubstitutionSource)
        {

        }

        public StandardModulusExceptionFourteenCalculator(FirstStandardModulusElevenCalculatorExceptionFive firstStandardModulusElevenCalculatorExceptionFive)
            : base(firstStandardModulusElevenCalculatorExceptionFive)
        {
        }
    }
}