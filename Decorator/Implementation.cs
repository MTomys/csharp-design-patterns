namespace Decorator
{
    public interface IMailService
    {
        bool SendMail(string message);
    }

    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} send via {nameof(CloudMailService)}");
            return true;
        }
    }

    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"{message} send via {nameof(OnPremiseMailService)}");
            return true;
        }
    }

    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        protected MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        private readonly List<string> _sentMessages;
        public List<string> SentMessages => new(_sentMessages);

        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
            _sentMessages = new List<string>();
        }

        public override bool SendMail(string message)
        {
            var mailSent = base.SendMail(message);
            if (mailSent)
            {
                SentMessages.Add(message);
            }

            return mailSent;
        }
    }
}