using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour
{
    public CatDataBase Cats { get; private set; }
    public ItemDataBase Items { get; private set; }
    public ApplicantDataBase Applicants { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cats = JsonLoader.LoadData<CatDataBase>("CatData");
        Items = JsonLoader.LoadData<ItemDataBase>("FurnitureData");
        Applicants = JsonLoader.LoadData<ApplicantDataBase>("ApplicantData");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
