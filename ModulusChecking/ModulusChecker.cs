using ModulusChecking.Loaders;
using ModulusChecking.Models;
using ModulusChecking.Steps;

namespace ModulusChecking
{
    public class ModulusChecker
    {
        private readonly IModulusWeightTable _weightTable;
        private readonly ISortCodeSubstitutionSource _sortCodeSubstitutionSource;

        public ModulusChecker(IModulusWeightTable weightTable, ISortCodeSubstitutionSource sortCodeSubstitutionSource)
        {
            _weightTable = weightTable;
            _sortCodeSubstitutionSource = sortCodeSubstitutionSource;
        }

        public bool CheckBankAccount(string sortCode, string accountNumber)
        {
            var bankAccountDetails = new BankAccountDetails(sortCode, accountNumber);
            bankAccountDetails.WeightMappings = _weightTable.GetRuleMappings(bankAccountDetails.SortCode);
            return new ConfirmDetailsAreValidForModulusCheck(_sortCodeSubstitutionSource).Process(bankAccountDetails);
        }
    }
}
