using ModulusChecking.Loaders;
using ModulusChecking.Models;
using ModulusChecking.Steps;

namespace ModulusChecking
{
    public class ModulusChecker
    {
        private readonly IModulusWeightTable _weightTable;

        public ModulusChecker(IModulusWeightTable weightTable)
        {
            _weightTable = weightTable;
        }

        public bool CheckBankAccount(string sortCode, string accountNumber)
        {
            var bankAccountDetails = new BankAccountDetails(sortCode, accountNumber);
            bankAccountDetails.WeightMappings = _weightTable.GetRuleMappings(bankAccountDetails.SortCode);
            return new ConfirmDetailsAreValidForModulusCheck().Process(bankAccountDetails);
        }
    }
}
