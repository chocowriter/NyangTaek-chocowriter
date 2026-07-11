using UnityEngine;

public class ItemData : IData
{
    public int id;
    public string name;

    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
public class ItemDataBase
{
    public ItemData[] items;
}
