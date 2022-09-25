using UnityEditor;
using UnityEngine;

namespace VitDeck.GUI
{
    public static class CreateWorkspaceMenu
    {
        [MenuItem("Assets/Create/VitDeck/Workspace")]
        public static void Create()
        {
            var workspace = ScriptableObject.CreateInstance<Workflow>();
            ProjectWindowUtil.CreateAsset(workspace, "New Workspace.asset");
        }
    }
}