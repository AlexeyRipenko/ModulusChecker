using System.Linq;
using ModulusChecking.Loaders;
using ModulusChecking.Loaders.Resources;
using ModulusChecking.Models;
using ModulusChecking.Models.Resources;
using NUnit.Framework;

namespace ModulusCheckingTests.Loaders
{
    public class ModulusWeightTests
    {
        [Test]
        public void CanReadWeightFileResource()
        {
            var weightFile = ModulusChecking.Properties.Resources.valacdos;
            Assert.NotNull(weightFile);
            Assert.IsInstanceOf(typeof(string), weightFile);
        }

        [Test]
        public void CanLoadWeightFileRows()
        {
            var modulusWeight = new ModulusWeightTable(new ResourcesValacdosSource());
            Assert.AreEqual(987, modulusWeight.RuleMappings.Count());
        }

        [Test]
        public void CanGetRuleMappings()
        {
            var modulusWeight = new ModulusWeightTable(new ResourcesValacdosSource());
            Assert.NotNull(modulusWeight.RuleMappings);
            Assert.AreEqual(modulusWeight.RuleMappings.Count, 987);
            Assert.IsInstanceOf<ResourcesModulusWeightMapping>(modulusWeight.RuleMappings.ElementAt(0));
        }

        [Test]
        public void ThereAreNoMod10MappingsWithExceptionFive()
        {
            var modulusWeight = new ModulusWeightTable(new ResourcesValacdosSource());
            Assert.IsFalse(modulusWeight.RuleMappings.Any(rm => rm.Exception == 5 && rm.Algorithm == ModulusAlgorithm.Mod10));
        }

        [Test]
        public void AllExceptionNineRowsAreModEleven()
        {
            var modulusWeight = new ModulusWeightTable(new ResourcesValacdosSource());
            var exceptionNineRows = modulusWeight.RuleMappings.Where(rm => rm.Exception == 9).ToList();
            Assert.IsTrue(exceptionNineRows.All(r => r.Algorithm == ModulusAlgorithm.Mod11));
        }
    }
}
