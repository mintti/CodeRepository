using System;
using System.Collections;
using UnityEngine;

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
        set => _assetBundle = value;
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

            AssetBundle bundle = www.assetBundle;

            if (bundle != null)
            {
                AssetBundle = bundle;
            }
        }
    }

    public void Unload()
    {
        AssetBundle.Unload(false);
    }
}