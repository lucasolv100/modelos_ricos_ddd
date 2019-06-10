using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentsContext.Domain.Commands;

namespace PaymentsContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }
}