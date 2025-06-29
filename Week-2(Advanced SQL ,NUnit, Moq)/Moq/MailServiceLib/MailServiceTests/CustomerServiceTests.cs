using Moq;
using NUnit.Framework;
using MailServiceLib;

namespace MailServiceTests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<IEmailSender> _mockEmailSender;
        private CustomerService _customerService;

        [OneTimeSetUp]
        public void Setup()
        {
            _mockEmailSender = new Mock<IEmailSender>();
            _mockEmailSender.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            _customerService = new CustomerService(_mockEmailSender.Object);
        }

        [Test]
        public void SendEmailToCustomer_ReturnsTrue()
        {
            bool result = _customerService.SendEmailToCustomer();

            Assert.That(result, Is.True);

        }
    }
}
