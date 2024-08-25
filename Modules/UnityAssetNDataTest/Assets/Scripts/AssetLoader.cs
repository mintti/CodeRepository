using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class AssetLoader : MonoBehaviour
{
    private AssetBundle _assetBundle;
    public AssetBundle AssetBundle
    {
        get
        {
            if (_assetBundle == null)
            {
                throw new Exception("로드된 에셋번들이 존재하지 않음");
            }

            return _assetBundle;
        }
    }

    private const string _materialName = "cat.mat";
    public Material CatMaterial { get; private set; }

    public IEnumerator LoadAsset(int version)
    {
#if  UNITY_EDITOR
        LoadCatMaterialAssetDatabase();
        yield break;
#else
        string bundleURL = "file:///" + Application.dataPath + "/AssetBundles/test";
        yield return LoadCacheAssetBundle(bundleURL, version);
        CatMaterial = AssetBundle.LoadAsset<Material>(_materialName);
#endif
    }

    #region Load Asset Bundle

    IEnumerator LoadAssetBundle(string bundleURL)
    {
        // AssetBundle 로드
        using (WWW www = new WWW(bundleURL))
        {
            yield return www;

            // 로드 실패 시 에러 처리
            if (www.error != null)
            {
                Debug.LogError("Failed to download AssetBundle!");
                yield break;
            }

            _assetBundle = www.assetBundle;
        }
    }

    IEnumerator LoadCacheAssetBundle(string bundleURL, int version)
    {
        // 캐시 시스템을 다운 or 캐시에서 로드
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL, (uint)version, 0);
        
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to download AssetBundle: " + request.error);
            yield break;
        }
        
        // 에셋 번들 로드
        _assetBundle = DownloadHandlerAssetBundle.GetContent(request);
    }

    public void Unload()
    {
        AssetBundle.Unload(false);
    }
    #endregion

    void LoadCatMaterialAssetDatabase()
    {
        string assetPath = "Assets/AssetBundles/Materials/" + _materialName;
        CatMaterial = AssetDatabase.LoadAssetAtPath<Material>(assetPath);
    }

    void LoadAllAsset()
    {
        string[] guids = AssetDatabase.FindAssets("t:Material");
        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Material material = AssetDatabase.LoadAssetAtPath<Material>(assetPath);
            // material 저장
        }
    }
}