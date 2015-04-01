using ModulusChecking.Models;

namespace ModulusChecking.ModulusChecks
{
    public interface IModulusCheck
    {
        int GetModulusSum(BankAccountDetails bankAccountDetails, IModulusWeightMapping weightMapping);
    }
}