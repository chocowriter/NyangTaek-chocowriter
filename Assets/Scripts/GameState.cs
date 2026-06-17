using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public List<ApplicantData> applicantDataList = new List<ApplicantData>();
    public List<CatData> catDataList = new List<CatData>();
    public List<FurnitureData> furnitureDataList = new List<FurnitureData>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        JsonLoader.LoadData<List<CatData>>(ref catDataList, "CatData");
        JsonLoader.LoadData<List<FurnitureData>>(ref furnitureDataList, "FurnitureData");
        JsonLoader.LoadData<List<ApplicantData>>(ref applicantDataList, "ApplicantsData");
        
    }
}
