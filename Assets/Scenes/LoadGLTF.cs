using UnityEngine;
using Siccity.GLTFUtility;
using System.IO;

public class LoadGLTF : MonoBehaviour
{
    [SerializeField]
    string filename;

    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "gltf", filename);
        //android
#if UNITY_ANDROID&&!UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "gltf", filename);
#endif
        ImportGLTFAsync(path);
    }

    void ImportGLTFAsync(string filepath)
    {
        Importer.ImportGLBAsync(filepath, new ImportSettings(), OnFinishAsync, OnProgress);
    }

    private void OnProgress(float progress)
    {
        Debug.Log("importing :progress: " + progress);
    }

    private void OnFinishAsync(GameObject result, AnimationClip[] anis)
    {
        Debug.Log("Finished importing :result: " + result.name + ", anis: " + anis.Length);
    }
}
