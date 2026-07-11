using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameSaveData
{
    public List<int> ownedCatIds = new List<int>();
    public List<int> ownedFurnitureIds = new List<int>();
    public List<int> ownedApplicantIds = new List<int>();
    public int coin = 0;
}
