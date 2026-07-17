using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    public CatDatabase Cats { get; private set; }
    public ItemDatabase Items { get; private set; }
    public ApplicantDatabase Applicants { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cats = JsonLoader.LoadData<CatDatabase>("CatData");
        Items = JsonLoader.LoadData<ItemDatabase>("FurnitureData");
        Applicants = JsonLoader.LoadData<ApplicantDatabase>("ApplicantData");
    }
}
