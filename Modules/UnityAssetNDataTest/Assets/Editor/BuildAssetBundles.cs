using UnityEditor;
using UnityEngine;

public class BuildAssetBundles : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        // AssetBundle을 저장할 폴더 경로 설정
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!System.IO.Directory.Exists(assetBundleDirectory))
        {
            System.IO.Directory.CreateDirectory(assetBundleDirectory);
        }

        // AssetBundle 빌드
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
            BuildAssetBundleOptions.None, 
            BuildTarget.StandaloneWindows);
    }
}
