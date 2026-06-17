using System;
using System.IO;
using UnityEngine;

public static class JsonLoader
{
    public static void LoadData<T>(ref T data, string path)
    {
        TextAsset json = Resources.Load<TextAsset>(path);
        Debug.Log($"Loaded data from {path} ");
        T loadedData = JsonUtility.FromJson<T>(json.text);
        
        data = loadedData;
    }
}