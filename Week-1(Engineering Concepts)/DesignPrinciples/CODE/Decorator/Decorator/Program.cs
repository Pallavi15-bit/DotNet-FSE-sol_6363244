using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    interface INotifier
    {
        void Send();
    }

    class EmailNotifier : INotifier
    {
        public void Send() => Console.WriteLine("Sending Email Notification");
    }

    abstract class NotifierDecorator : INotifier
    {
        protected INotifier _notifier;
        public NotifierDecorator(INotifier notifier) => _notifier = notifier;
        public virtual void Send() => _notifier.Send();
    }

    class SMSNotifier : NotifierDecorator
    {
        public SMSNotifier(INotifier notifier) : base(notifier) { }
        public override void Send()
        {
            base.Send();
            Console.WriteLine("Sending SMS Notification");
        }
    }

    class SlackNotifier : NotifierDecorator
    {
        public SlackNotifier(INotifier notifier) : base(notifier) { }
        public override void Send()
        {
            base.Send();
            Console.WriteLine("Sending Slack Notification");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            INotifier notifier = new SlackNotifier(new SMSNotifier(new EmailNotifier()));
            notifier.Send();
        }
    }
}
