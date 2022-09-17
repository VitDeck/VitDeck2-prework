using UnityEditor;
using UnityEngine;
using VitDeck.Validation;
using Object = UnityEngine.Object;

namespace VitDeck.GUI
{
    public class ValidatorGUI : EditorWindow
    {
        [MenuItem("Window/VitDeck/Validator")]
        public static void GetWindow()
        {
            var window = GetWindow<ValidatorGUI>();
            window.titleContent = new GUIContent("VitDeck Validator");
        }

        private Object selectedRootObject = null;
        
        private Result lastResult = null;
        
        private Vector2 logScrollPosition = new Vector2();

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Validator", EditorStyles.boldLabel);

            selectedRootObject = EditorGUILayout.ObjectField("Root",selectedRootObject, typeof(Object), false);
            
            EditorGUI.BeginDisabledGroup(selectedRootObject == null);
            if (GUILayout.Button("Validate"))
            {
                var validator = new Validator();

                var result = validator.Validate(selectedRootObject);
                SetResult(result);
            }
            EditorGUI.EndDisabledGroup();

            if (lastResult != null)
            {
                DrawResult(lastResult);
            }
        }

        private void DrawResult(Result result)
        {
            EditorGUILayout.LabelField("Result", EditorStyles.boldLabel);
            EditorGUILayout.LabelField(result.Message);
            logScrollPosition = EditorGUILayout.BeginScrollView(logScrollPosition);
            foreach (var log in result.Logs)
            {
                DrawLog(log);
            }
            EditorGUILayout.EndScrollView();
        }
        
        private void DrawLog(LogBase log)
        {
            EditorGUILayout.LabelField(log.Message);
        }

        private void SetResult(Result result)
        {
            if (lastResult != null)
            {
                DestroyImmediate(lastResult);
                lastResult = null;
            }

            lastResult = result;
        }
    }
}