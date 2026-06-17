using UnityEngine;

[System.Serializable]
public class CatData : IData
{
    public int id;
    public string name;
    public int stability;
    public int activity;
    public int communion;

    public string GetName()
    {
        return name;
    }
}
