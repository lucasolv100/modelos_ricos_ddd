using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Entities;
using PaymentsContext.Domain.Enums;
using PaymentsContext.Domain.ValueObjects;

namespace PaymentsContext.Tests.Entities
{
    //TODO: revisar
    [TestClass]
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;

        public StudentTest()
        {
            _name = new Name("Lucas", "Souza");
            _document = new Document("26353245068", EDocumentType.CPF);
            _email = new Email("teste@teste.com");

            _address = new Address("rua teste", "123", "teste", "teste", "sp", "12356-456");
            
           _student = new Student(_name, _document, _email);
           _subscription = new Subscription(null);
           
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new BoletoPayment("123132132", _email, "12131321", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Lucas Souza");
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenHadActiveSubscription()
        {
             var payment = new BoletoPayment("123132132", _email, "12131321", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _address, _document, "Lucas Souza");
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}