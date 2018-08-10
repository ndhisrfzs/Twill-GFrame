using GFrame;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SpriteCreater
{
    [MenuItem("Assets/GFrame/Sprite Create")]
    static public void CreatePoolCode()
    {
        m_Instance.Create(Selection.activeObject);
    }

    private void Create(UnityEngine.Object go)
    {
        if (go != null && go.GetType() == typeof(DefaultAsset))
        {
            m_SelectObject = go;

            IOUtil.CreateDirIfNotExists(spriteDir);

            string path = AssetDatabase.GetAssetPath(m_SelectObject);
            string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                Debug.Log(files[i]);
                string allPath = files[i];
                string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                GameObject go_sprite = new GameObject(sprite.name);
                go_sprite.AddComponent<SpriteRenderer>().sprite = sprite;
                allPath = spriteDir + "/" + sprite.name + ".prefab";
                string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                PrefabUtility.CreatePrefab(prefabPath, go_sprite);
                GameObject.DestroyImmediate(go_sprite);
            }

            AssetDatabase.Refresh();
        }
    }

    string spriteDir = Application.dataPath + "/Project/Resources/Sprite";
    UnityEngine.Object m_SelectObject = null;
    static SpriteCreater m_Instance = new SpriteCreater();
}