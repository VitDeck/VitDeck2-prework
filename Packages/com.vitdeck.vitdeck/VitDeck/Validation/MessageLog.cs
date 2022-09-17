namespace VitDeck.Validation
{
    public class MessageLog : LogBase
    {
        public override LogType Type => LogType.Info;
        
        private string message;
        public override string Message => message;
        public override bool HasInformation => false;
        public override bool HasSolution => false;
        
        public static MessageLog Create(LogType logType, string message)
        {
            var instance = CreateInstance<MessageLog>();
            instance.message = message;
            return instance;
        }
    }
}