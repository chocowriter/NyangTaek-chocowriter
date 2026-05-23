using System;
using System.IO;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public ApplicantsList applicantsList;
    public CatsList catsList;
    public static JsonLoader Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }


        LoadApplicantData();
        LoadCatsData();
    }

    private void LoadCatsData()
    {
        TextAsset json = Resources.Load<TextAsset>("CatData");
        CatsList data = JsonUtility.FromJson<CatsList>(json.text);
        catsList = data;
    }

    void LoadApplicantData()
    {
        TextAsset json = Resources.Load<TextAsset>("ApplicantsData");
        ApplicantsList data = JsonUtility.FromJson<ApplicantsList>(json.text);
        applicantsList = data;
    }
}