namespace TemplateMethod
{
    public abstract class MailParser
    {
        public virtual void FindServer()
        {
            Console.WriteLine("Finding server...");
        }

        public abstract void AuthenticateToServer();

        public string ParseHtmlMailBody(string identifier)
        {
            FindServer();
            Console.WriteLine("Parsing HTML mail body");
            return $"This is the body of mail with id {identifier}";
        }
    }

    public class ExchangeMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to exchange");
        }
    }

    public class ApacheMailParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("finding eudora server through a custom algorithm");
        }

        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to apache");
        }
    }
}