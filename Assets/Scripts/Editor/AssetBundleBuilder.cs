using UnityEngine;
using UnityEditor;

public class AssetBundleBuilder : Editor
{
    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundles()
    {
        // Укажите путь, куда будут сохранены AssetBundles
        string outputPath = "Assets/AssetBundles";

        // Создайте папку, если она не существует
        if (!System.IO.Directory.Exists(outputPath))
        {
            System.IO.Directory.CreateDirectory(outputPath);
        }

        // Постройте все AssetBundles
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, BuildTarget.WebGL);

        Debug.Log("AssetBundles успешно построены и сохранены в: " + outputPath);
    }
}