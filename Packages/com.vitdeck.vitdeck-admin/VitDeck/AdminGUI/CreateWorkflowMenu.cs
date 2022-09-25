using UnityEditor;
using UnityEngine;

namespace VitDeck.AdminGUI
{
    public static class CreateWorkflowMenu
    {
        [MenuItem("Assets/Create/VitDeck/Workflow")]
        private static void CreateWorkflow()
        {
            var workflow = ScriptableObject.CreateInstance<Workflow>();
            ProjectWindowUtil.CreateAsset(workflow, "New Workflow.asset");
        }
    }
}
