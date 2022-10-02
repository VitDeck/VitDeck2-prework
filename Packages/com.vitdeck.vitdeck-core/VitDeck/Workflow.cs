using UnityEngine;
using VitDeck.Localization;

namespace VitDeck
{
    public class Workflow : ScriptableObject
    {
        [SerializeField]
        private string hash;

        [SerializeField] private LocalizeDictionary localize;
    }

    public interface IWorkflowContext
    {
        
    }
}
