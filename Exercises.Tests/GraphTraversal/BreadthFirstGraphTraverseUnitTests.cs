﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercises.GraphTraversal;
using Exercises.GraphTraversal.Implementations;
using Exercises.GraphTraversal.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exercises.Tests.GraphTraversal
{
    [TestClass]
    public class BreadthFirstGraphTraverseUnitTests : SimpleGraphTraverseUnitTestsBase
    {
        protected override IGraphTraverse<string> CreateTraverse()
        {
            return new BreadthFirstTraverse<string>();
        }

        protected override IList TargetOrder
        {
            get
            {
                return new List<string> { "6", "4", "3", "5", "2", "1" }.AsReadOnly();
            }
        }
    }
}
