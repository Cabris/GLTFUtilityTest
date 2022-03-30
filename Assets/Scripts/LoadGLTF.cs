using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System.IO;
using System;

public class LoadGLTF : MonoBehaviour
{
    [SerializeField]
    string filename;

    // Start is called before the first frame update
    void Start()
    {
        ImportGLTFAsync(Path.Combine(Application.streamingAssetsPath, filename));
    }


    void ImportGLTFAsync(string filepath)
    {
        Importer.ImportGLTFAsync(filepath, new ImportSettings(), OnFinishAsync, OnProgress);
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
