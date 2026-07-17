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
    GameDatabase gameDatabase;

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
        CatListBtn.onClick.AddListener(ShowCatList);
        FurnitureListBtn.onClick.AddListener(ShowItemList);
        OwnerListBtn.onClick.AddListener(ShowOwnerList);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnInterviewBtnClick()
    {
        SceneManager.LoadScene("InterviewScene");
    }

    public void ShowCatList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.ownedCats, CatListPanel.transform.Find("Scroll View/Viewport/Content"), OwnerItemPrefab);
        CatListPanel.SetActive(true);
    }

    public void ShowOwnerList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.ownedApplicants, OwnerListPanel.transform.Find("Scroll View/Viewport/Content"), OwnerItemPrefab);
        OwnerListPanel.SetActive(true);
    }

    public void ShowItemList()
    {
        TownMain.SetActive(false);
        RefreshList(gameState.ownedItems, FurnitureListPanel.transform.Find("Scroll View/Viewport/Content"), ListItemPrefab);
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
            GameObject item = Instantiate(listItemPrefab, content);
            item.transform.Find("Button/Name").GetComponent<Text>().text = cat.GetName();
            //item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + cat.stability;
            Debug.Log("Added item: " + cat.GetName());
        }
    }

    public void CloseList(GameObject listPanel)
    {
        listPanel.SetActive(false);
        TownMain.SetActive(true);
    }


}
