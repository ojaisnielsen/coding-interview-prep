using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.StringMatching;
using Exercises.StringMatching.Model;

namespace Exercises.Tests.StringMatching
{
    [TestClass]
    public abstract class StringMatchUnitTestsBase
    {
        [TestMethod]
        public void Match_OnNonNullString_NoMatch()
        {
            var test = "wassup bitches!";
            var stringMatch = this.CreateStringMatch("salut", "coucou");
            Assert.AreEqual(-1, stringMatch.IndexOfFirst(test));
        }

        [TestMethod]
        public void Match_OnNonNullString_Match()
        {
            var test = "wassup salut bitches!";
            var stringMatch = this.CreateStringMatch("salut", "coucou");
            Assert.AreEqual(7, stringMatch.IndexOfFirst(test));
        }

        protected abstract IStringMatch CreateStringMatch(params string[] strings);
    }    
}
