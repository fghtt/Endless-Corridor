using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class EnableReadWrite : EditorWindow
{
    [MenuItem("Tools/Enable Read/Write for All Meshes")]
    static void EnableReadWriteMeshes()
    {
        string[] guids = AssetDatabase.FindAssets("t:Model");

        int count = 0;
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter importer = AssetImporter.GetAtPath(path) as ModelImporter;

            if (importer != null && !importer.isReadable)
            {
                importer.isReadable = true;
                importer.SaveAndReimport();
                UnityEngine.Debug.Log("Enabled Read/Write on: " + path);
                count++;
            }
        }

        UnityEngine.Debug.Log($"✅ Обработано {count} моделей. Read/Write Enabled установлен.");
    }
}