using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<CatData> ownedCats = new List<CatData>();
    public List<ItemData> ownedItems = new List<ItemData>();
    public List<ApplicantData> ownedApplicants = new List<ApplicantData>();

    public List<int> ownedCatIds = new List<int>();
    public List<int> ownedItemIds = new List<int>();
    public List<int> ownedApplicantIds = new List<int>();
    public int coin = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ownedCats.Clear();
        ownedItems.Clear();
        ownedApplicants.Clear();
        GameDatabase gameDataBase = FindAnyObjectByType<GameDatabase>();
        foreach (int catId in ownedCatIds)
        {
            CatData cat = gameDataBase.Cats.cats.Find(c => c.id == catId);
            if (cat != null)
            {
                ownedCats.Add(cat);
            }
        }
        Debug.Log("Owned Cats: " + ownedCats.Count);
    }
}
