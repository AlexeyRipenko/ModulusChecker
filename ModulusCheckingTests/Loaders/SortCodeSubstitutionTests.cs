﻿using ModulusChecking.Loaders;
using ModulusChecking.Loaders.Resources;
using NUnit.Framework;

namespace ModulusCheckingTests.Loaders
{ 
    public class SortCodeSubstitutionTests
    {
        
        private readonly ResourcesSortCodeSubstitutionSource _substituter = new ResourcesSortCodeSubstitutionSource();

        [Test]
        [TestCase("938289","938068")]
        [TestCase("938297","938076")]
        [TestCase("938600","938611")]
        [TestCase("938602","938343")]
        [TestCase("938604","938603")]
        [TestCase("938608","938408")]
        [TestCase("938609","938424")]
        [TestCase("938613","938017")]
        [TestCase("938616","938068")]
        [TestCase("123456","123456")]
        public void CanCorrectlySubstituteSortCodes(string orig, string sub)
        {
            Assert.AreEqual(sub, _substituter.GetSubstituteSortCode(orig));
        }
    }
}
