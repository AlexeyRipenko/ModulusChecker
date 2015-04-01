using System.Collections.Generic;
using System.Linq;
using ModulusChecking.Loaders;
using ModulusChecking.Loaders.Resources;
using ModulusChecking.Models;
using ModulusChecking.Models.Resources;
using ModulusChecking.Steps.Calculators;
using Moq;
using NUnit.Framework;

namespace ModulusCheckingTests.Rules.Calculators
{
    public class MockCalculatorTests
    {
        private Mock<IModulusWeightTable> _fakedModulusWeightTable;

        [SetUp]
        public void Before()
        {
            var mappingSource = new Mock<IRuleMappingSource>();
            mappingSource.Setup(ms => ms.GetModulusWeightMappings()).Returns(new List<IModulusWeightMapping>
                                                                                 {
                                                                                     new ResourcesModulusWeightMapping(
                                                                                         "000000 000100 MOD10 0 0 0 0 0 0 7 5 8 3 4 6 2 1 "),
                                                                                     new ResourcesModulusWeightMapping(
                                                                                         "499273 499273 DBLAL    0    0    2    1    2    1    2    1    2    1    2    1    2    1   1"),
                                                                                         new ResourcesModulusWeightMapping(
                                                                                         "200000 200002 DBLAL    2    1    2    1    2    1    2    1    2    1    2    1    2    1   6")
                                                                                 });
            _fakedModulusWeightTable = new Mock<IModulusWeightTable>();
            _fakedModulusWeightTable.Setup(fmwt => fmwt.RuleMappings).Returns(mappingSource.Object.GetModulusWeightMappings().ToList());
            _fakedModulusWeightTable.Setup(fmwt => fmwt.GetRuleMappings(new SortCode("000000")))
                .Returns(new List<IModulusWeightMapping>
                             {
                                 new ResourcesModulusWeightMapping("000000 000100 MOD10 0 0 0 0 0 0 7 5 8 3 4 6 2 1 "),
                             });
        }

        [Test]
        public void CanProcessStandardElevenCheck()
        {
            var accountDetails = new BankAccountDetails("000000", "58177632");
            accountDetails.WeightMappings = _fakedModulusWeightTable.Object.GetRuleMappings(accountDetails.SortCode);
            var result = new FirstStandardModulusElevenCalculator().Process(accountDetails);
            Assert.True(result);
        }

        [Test]
        //vocalink test case
        public void CanProcessVocalinkStandardTenCheck()
        {
            var accountDetails = new BankAccountDetails("089999", "66374958");
            accountDetails.WeightMappings = new ModulusWeightTable(new ResourcesValacdosSource()).GetRuleMappings(accountDetails.SortCode);
            var result = new FirstStandardModulusTenCalculator().Process(accountDetails);
            Assert.True(result);
        }

        [Test]
        public void CanProcessVocalinkStandardEleven()
        {
            var accountDetails = new BankAccountDetails("107999", "88837491");
            accountDetails.WeightMappings = new ModulusWeightTable(new ResourcesValacdosSource()).GetRuleMappings(accountDetails.SortCode);
            var result = new FirstStandardModulusElevenCalculator().Process(accountDetails);
            Assert.True(result);
        }

    }
}
