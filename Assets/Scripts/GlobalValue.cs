using System.Collections.Generic;
using UnityEngine;


public class GlobalValue : MonoBehaviour
{
    //public static int interviewIndex = 0;
    List<ApplicantData> applicantDataList = new List<ApplicantData>();
    List<CatData> catDataList = new List<CatData>();
    List<FurnitureData> furnitureDataList = new List<FurnitureData>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        JsonLoader.LoadData<List<ApplicantData>>(ref applicantDataList, "ApplicantsData.json");
        JsonLoader.LoadData<List<CatData>>(ref catDataList, "CatData.json");
        JsonLoader.LoadData<List<FurnitureData>>(ref furnitureDataList, "FurnitureData.json");
    }
}
