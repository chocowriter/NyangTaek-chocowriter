using UnityEngine;

[System.Serializable]
public class FurnitureData : IData
{
    public int id;
    public string name;

    public string GetName()
    {
        return name;
    }
}
