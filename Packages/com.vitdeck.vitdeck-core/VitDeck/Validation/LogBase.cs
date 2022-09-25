using UnityEngine;

namespace VitDeck.Validation
{
    public abstract class LogBase : ScriptableObject
    {
        public abstract LogType Type { get; }
        public abstract string Message { get; }
        public abstract bool HasInformation { get; }
        public abstract bool HasSolution { get; }
    }
}