using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface IData
{
    string GetName();
}

public class TownMgr : MonoBehaviour
{
    public Button InterviewBtn;
    [Header("Cat List")]
    public Button CatListBtn;
    public GameObject CatListPanel;

    [Header("Furniture List")]
    public Button FurnitureListBtn;
    public GameObject FurnitureListPanel;


    [Header("Owner List")]
    public Button OwnerListBtn;
    public GameObject OwnerListPanel;
    List<int> OwnerList = new List<int>();

    public GameObject TownMain;
    public GameObject ListItemPrefab;
    public GameObject OwnerItemPrefab;

    GameState gameState;

    public static TownMgr Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameState = FindAnyObjectByType<GameState>();
        InterviewBtn.onClick.AddListener(OnInterviewBtnClick);
        /*CatListBtn.onClick.AddListener(ShowCatList);
        FurnitureListBtn.onClick.AddListener(ShowFurnitureList);
        OwnerListBtn.onClick.AddListener(ShowOwnerList);*/
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnInterviewBtnClick()
    {
        SceneManager.LoadScene("InterviewScene");
    }

    /*void ShowCatList()
    {
        TownMain.SetActive(false);
        RefreshCatList();
        CatListPanel.SetActive(true);
    }

    void RefreshCatList()
    {
        Transform content = CatListPanel.transform.Find("Scroll View/Viewport/Content");
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        FillCatList();
    }

    void FillCatList()
    {
        Transform content = CatListPanel.transform.Find("Scroll View/Viewport/Content");
        Debug.Log(content.name);
        foreach (var cat in JsonLoader.Instance.catsList.cats)
        {
            GameObject item = Instantiate(ListItemPrefab, content);
            item.transform.Find("Button/Name").GetComponent<Text>().text = cat.name;
            *//*item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + cat.stability;
            item.transform.Find("Activity").GetComponent<Text>().text = "Activity: " + cat.activity;
            item.transform.Find("Communion").GetComponent<Text>().text = "Communion: " + cat.communion;*//*
        }
    }
    public void CloseCatList()
    {
        CatListPanel.SetActive(false);
        TownMain.SetActive(true);
    }
    void ShowFurnitureList()
    {
        TownMain.SetActive(false);
        RefreshFurnitureList();
        FurnitureListPanel.SetActive(true);
    }

    void RefreshFurnitureList()
    {
        Transform content = FurnitureListPanel.transform.Find("Scroll View/Viewport/Content");
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        FillFurnitureList();
    }

    void FillFurnitureList()
    {
        Transform content = FurnitureListPanel.transform.Find("Scroll View/Viewport/Content");
        Debug.Log(content.name);
        foreach (var furniture in JsonLoader.Instance.furnitureList.furnitures)
        {
            GameObject item = Instantiate(ListItemPrefab, content);
            item.transform.Find("Button/Name").GetComponent<Text>().text = furniture.name;
            
        }
    }
    public void CloseFurnitureList()
    {
        FurnitureListPanel.SetActive(false);
        TownMain.SetActive(true);
    }
    void ShowOwnerList()
    {
        TownMain.SetActive(false);
        RefreshOwnerList();
        OwnerListPanel.SetActive(true);
    }

    void RefreshOwnerList()
    {
        Transform content = OwnerListPanel.transform.Find("Scroll View/Viewport/Content");
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        FillOwnerList();
    }

    void FillOwnerList()
    {
        Transform content = OwnerListPanel.transform.Find("Scroll View/Viewport/Content");
        Debug.Log(content.name);
        GetMyOwner();
        foreach (var owner in JsonLoader.Instance.applicantsList.applicants)
        {
            if (OwnerList.Contains(owner.id))
            {
                GameObject item = Instantiate(OwnerItemPrefab, content);
                item.transform.Find("Button/Name").GetComponent<Text>().text = owner.name;
            }
            

        }
    }
    public void CloseOwnerList()
    {
        OwnerListPanel.SetActive(false);
        TownMain.SetActive(true);
    }*/

    void GetMyOwner()
    {
        int i = 1;
        OwnerList.Clear();
        while (true) 
        {
            if (PlayerPrefs.HasKey("Applicant" + i))
            {
                if (PlayerPrefs.GetInt("Applicant" + i) == 1)
                    OwnerList.Add(i);
                Debug.Log(PlayerPrefs.GetInt("Applicant" + i));
            }
            else
            {
                break;
            }
            i++;
        }
    }

    public void ShowCatList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.catDataList, CatListPanel.transform.Find("Scroll View/Viewport/Content"), ListItemPrefab);
        CatListPanel.SetActive(true);
    }

    public void ShowOwnerList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.applicantDataList, OwnerListPanel.transform.Find("Scroll View/Viewport/Content"), OwnerItemPrefab);
        OwnerListPanel.SetActive(true);
    }

    public void ShowFurnitureList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.furnitureDataList, FurnitureListPanel.transform.Find("Scroll View/Viewport/Content"), ListItemPrefab);
        FurnitureListPanel.SetActive(true);
    }


    void RefreshList<T>(List<T> list, Transform content, GameObject listItemPrefab)
        where T : IData
    {
        if (content != null && content.childCount > 0)
        {
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }
        }
        FillList(list, content, listItemPrefab);
    }

    void FillList<T>(List<T> list, Transform content, GameObject listItemPrefab)
        where T : IData
    {
        Debug.Log(content.name);
        foreach (var cat in list)
        {
            GameObject item = Instantiate(ListItemPrefab, content);
            item.transform.Find("Button/Name").GetComponent<Text>().text = cat.GetName();
            /*item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + cat.stability;
            item.transform.Find("Activity").GetComponent<Text>().text = "Activity: " + cat.activity;
            item.transform.Find("Communion").GetComponent<Text>().text = "Communion: " + cat.communion;*/
        }
    }
    public void CloseList()
    {
        CatListPanel.SetActive(false);
        TownMain.SetActive(true);
    }
}
