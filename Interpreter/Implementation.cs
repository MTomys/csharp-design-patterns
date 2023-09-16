namespace Interpreter
{
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; } = string.Empty;

        public RomanContext(int input)
        {
            Input = input;
        }
    }

    public abstract class RomanExpression
    {
        public abstract void Interpret(RomanContext value);
    }

    public class RomanOneExpression : RomanExpression
    {
        public override void Interpret(RomanContext value)
        {
            throw new NotImplementedException();
        }
    }
}