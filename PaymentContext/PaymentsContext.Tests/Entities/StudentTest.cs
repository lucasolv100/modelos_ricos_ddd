using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Lucas", "Souza");
        }
    }
}