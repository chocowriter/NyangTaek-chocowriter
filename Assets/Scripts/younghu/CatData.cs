using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatData : IData
{
    public int id;
    public string name;
    public int closeness;
    public int activity;
    public int independence;

    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
public class CatDatabase
{
    public List<CatData> cats;
}
