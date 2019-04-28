using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.StringMatching;
using Exercises.StringMatching.Implementations;
using Exercises.StringMatching.Model;

namespace Exercises.Tests.StringMatching
{
    [TestClass]
    public class AutomatonStringMatchUnitTests : StringMatchUnitTestsBase
    {
        protected override IStringMatch CreateStringMatch(params string[] strings)
        {
            return new AutomatonStringMatch(strings);
        }
    }
}
