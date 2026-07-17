using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ApplicantData : IData
{
    public int id;
    public string name;
    public string job;
    public string career;
    public string feature1;
    public string feature2;
    public string feature3;
    public string reaction_approach;
    public string reaction_approach_ex1;
    public string reaction_approach_ex2;
    public string reaction_stare;
    public string reaction_stare_ex1;
    public string reaction_stare_ex2;
    public string reaction_smell;
    public string reaction_smell_ex1;
    public string reaction_smell_ex2;
    public string reaction_ignore;
    public string reaction_ignore_ex1;
    public string reaction_ignore_ex2;
    public int closeness;
    public int activity;
    public int independence;
    public string image_url;

    public string GetName()
    {
        return name;
    }
}

[System.Serializable]
public class ApplicantDatabase
{
    public List<ApplicantData> applicants;
}
