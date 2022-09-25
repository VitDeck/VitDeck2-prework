using UnityEditor;
using UnityEngine;

namespace VitDeck.GUI
{
    public class VitDeckGUI : EditorWindow
    {
        [MenuItem("VitDeck/Show VitDeck GUI")]
        public static void ShowWindow()
        {
            GetWindow<VitDeckGUI>("VitDeck GUI");
        }
    
        private void OnGUI()
        {
            GUILayout.Label("VitDeck GUI", EditorStyles.boldLabel);
        
        
        }
    }
}
