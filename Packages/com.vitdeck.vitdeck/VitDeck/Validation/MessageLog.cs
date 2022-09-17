namespace VitDeck.Validation
{
    public class MessageLog : LogBase
    {
        private LogType type;
        public override LogType Type => type;

        private string message;
        public override string Message => message;
        public override bool HasInformation => false;
        public override bool HasSolution => false;

        public static MessageLog Create(LogType type, string message)
        {
            var instance = CreateInstance<MessageLog>();
            instance.type = type;
            instance.message = message;
            return instance;
        }
    }
}