using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Commands;
using PaymentsContext.Domain.Enums;

namespace PaymentsContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand(
                "Lucas",
                "Souza",
                "99999999999",
                "teste@teste.com",
                "13215646543",
                DateTime.Now,
                DateTime.Now.AddMonths(1),
                1000,
                1000,
                "40249696843",
                EDocumentType.CPF,
                "Lucas",
                "1231321321321321321321",
                "123132132",
                "djkashhdksa",
                "001",
                "dsajlkas",
                "dsakljdaskl",
                "sp",
                "13190000",
                "teste@teste.com"
            );
            
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }
}