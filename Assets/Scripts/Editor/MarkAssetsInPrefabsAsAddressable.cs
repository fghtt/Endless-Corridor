using UnityEditor;
using UnityEngine;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets;
using System.Collections.Generic;

public class MarkAssetsInPrefabsAsAddressable
{
    [MenuItem("Tools/Mark Assets in Addressable Prefabs as Addressable")]
    public static void MarkAssetsInAddressablePrefabs()
    {
        // Получаем настройки Addressables
        AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;

        // Получаем все группы адресуемых ассетов
        List<AddressableAssetGroup> groups = new List<AddressableAssetGroup>(settings.groups);

        // Хранит пути всех ассетов, которые нужно пометить как адресуемые
        HashSet<string> usedAssetPaths = new HashSet<string>();

        // Проходим по всем группам
        foreach (var group in groups)
        {
            foreach (var entry in group.entries)
            {
                if (entry.AssetPath.EndsWith(".prefab"))
                {
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(entry.AssetPath);
                    if (prefab != null)
                    {
                        CollectUsedAssetsFromPrefab(prefab, usedAssetPaths);
                    }
                }
            }
        }

        // Помечаем ассеты как адресуемые
        foreach (var assetPath in usedAssetPaths)
        {
            var guid = AssetDatabase.AssetPathToGUID(assetPath);
            var entry = settings.FindAssetEntry(guid);
            if (entry == null)
            {
                settings.CreateOrMoveEntry(guid, settings.DefaultGroup);
                Debug.Log($"Marked {assetPath} as addressable.");
            }
            else
            {
                Debug.Log($"{assetPath} is already addressable.");
            }
        }

        // Сохраняем изменения в настройках Addressables
        EditorUtility.SetDirty(settings);
        AssetDatabase.SaveAssets();
    }

    private static void CollectUsedAssetsFromPrefab(GameObject prefab, HashSet<string> usedAssetPaths)
    {
        // Сбор ассетов из компонентов
        var components = prefab.GetComponentsInChildren<Component>(true);
        foreach (var component in components)
        {
            SerializedObject serializedObject = new SerializedObject(component);
            SerializedProperty property = serializedObject.GetIterator();
            while (property.Next(true))
            {
                if (property.propertyType == SerializedPropertyType.ObjectReference)
                {
                    if (property.objectReferenceValue != null)
                    {
                        string assetPath = AssetDatabase.GetAssetPath(property.objectReferenceValue);
                        if (!string.IsNullOrEmpty(assetPath) && !usedAssetPaths.Contains(assetPath))
                        {
                            usedAssetPaths.Add(assetPath);
                        }
                    }
                }
            }
        }
    }
}