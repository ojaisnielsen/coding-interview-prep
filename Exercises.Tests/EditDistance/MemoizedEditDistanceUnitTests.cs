using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.EditDistance.Implementations;
using Exercises.EditDistance.Model;

namespace Exercises.Tests.EditDistance
{
    [TestClass]
    public class MemoizedEditDistanceUnitTests : EditDistanceUnitTestsBase
    {
        protected override IEditDistance CreateEditDistance()
        {
            return new MemoizedEditDistance();
        }
    }
}
