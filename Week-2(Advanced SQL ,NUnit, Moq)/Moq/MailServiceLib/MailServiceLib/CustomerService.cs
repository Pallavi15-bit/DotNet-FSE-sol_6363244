namespace MailServiceLib
{
    public class CustomerService
    {
        private IEmailSender _emailSender;

        public CustomerService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public bool SendEmailToCustomer()
        {
            _emailSender.SendEmail("customer@abc.com", "Hello Customer, your order is confirmed.");
            return true;
        }
    }
}
