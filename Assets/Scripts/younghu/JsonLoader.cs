using UnityEngine;

public static class JsonLoader
{
    public static T LoadData<T>(string path)
    {
        TextAsset json = Resources.Load<TextAsset>(path);

        if (json == null)
        {
            Debug.LogError($"Failed to load {path}");
            return default;
        }

        return JsonUtility.FromJson<T>(json.text);
    }
}