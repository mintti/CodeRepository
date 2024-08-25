using System;
using System.Collections;
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

    
    public IEnumerator LoadAssetBundle(string bundleURL)
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

    public IEnumerator LoadCacheAssetBundle(string bundleURL, int version)
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
}