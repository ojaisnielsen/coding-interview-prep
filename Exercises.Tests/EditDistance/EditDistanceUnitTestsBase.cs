using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.EditDistance.Model;

namespace Exercises.Tests.EditDistance
{
    [TestClass]
    public abstract class EditDistanceUnitTestsBase
    {
        [TestMethod]
        public void Distance_OnNonNullStrings_Distance()
        {
            var s1 = "bonjour";
            var s2 = "bijour";
            Assert.AreEqual(2, this.CreateEditDistance().Distance(s1, s2));
        }

        protected abstract IEditDistance CreateEditDistance();
    }
}
