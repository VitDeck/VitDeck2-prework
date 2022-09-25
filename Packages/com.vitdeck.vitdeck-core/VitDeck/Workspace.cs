using System;
using UnityEditor;
using UnityEngine;
using VitDeck.Validation;

namespace VitDeck
{
    public class Workspace : ScriptableObject
    {
        [SerializeField] private Workflow workflow;

        [SerializeField] private Result lastValidationResult;

        private void Reset()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Unityの不具合によりScriptableObjectのResetボタンが有効にならないのでこのメソッドで上書き
        /// https://issuetracker.unity3d.com/issues/reset-option-is-greyed-out-for-scriptable-objects
        /// </summary>
        /// <param name="command"></param>
        [MenuItem ("CONTEXT/Workspace/Reset")]
        static void ResetMenuItem (MenuCommand command)
        {
            Workspace thisObj = (Workspace) command.context;
            thisObj.Reset();
        }
    }
}