using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ZombieEntity.SO
{
    public class ZombieData : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}