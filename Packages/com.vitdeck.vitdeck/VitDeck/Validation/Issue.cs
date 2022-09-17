using UnityEngine;

namespace VitDeck.Validation
{
    public abstract class IssueBase : ScriptableObject
    {
        public abstract bool HasResolver { get; }
    }
}
