using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private int _version;
    [SerializeField] private AssetLoader _loader;
    
    [SerializeField] private MeshRenderer _renderer;
    
    private void Start()
    {
        if (_version == 2)
        {
            StartCoroutine(nameof(SetVer2));
        }
    }

    IEnumerator SetVer2()
    {
        string bundleURL = "file:///" + Application.dataPath + "/AssetBundles/test";
        
        yield return _loader.LoadCacheAssetBundle(bundleURL, _version);

        var mat = _loader.AssetBundle.LoadAsset<Material>("cat.mat");
        _renderer.material = mat;
    }
}
