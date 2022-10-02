using UnityEditor;
using UnityEngine;
using VitDeck.Localization;

namespace VitDeck.AdminGUI
{
    public static class CreateLocalizeDictionaryMenu
    {
        [MenuItem("Assets/Create/VitDeck/LocalizeDictionary")]
        private static void CreateLocalizeDictionary()
        {
            var workflow = ScriptableObject.CreateInstance<LocalizeDictionary>();
            ProjectWindowUtil.CreateAsset(workflow, "New Localize Dictionary.asset");
        }
    }
}