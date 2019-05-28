using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Entities;

namespace PaymentsContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription(null);
            var student = new Student(
                firstName:"Lucas",
                lastName:"Souza",
                document:"402.496.968-43",
                email:"lucasolv.souza@gmail.com"
            );
        }

        
    }
}