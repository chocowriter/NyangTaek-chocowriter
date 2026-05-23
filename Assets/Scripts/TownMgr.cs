using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TownMgr : MonoBehaviour
{
    public Button InterviewBtn;
    [Header("Cat List")]
    public Button CatListBtn;
    public GameObject CatListPanel;

    [Header("Cat List")]

    [Header("Furniture List")]
    public Button FurnitureListBtn;
    public GameObject FurnitureListPanel;

    [Header("Furniture List")]

    public GameObject TownMain;
    public GameObject ListItemPrefab;
    public static TownMgr Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InterviewBtn.onClick.AddListener(OnInterviewBtnClick);
        CatListBtn.onClick.AddListener(ShowCatList);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnInterviewBtnClick()
    {
        SceneManager.LoadScene("ResumeScene");
    }

    void ShowCatList()
    {
        TownMain.SetActive(false);
        RefreshCatList();
        CatListPanel.SetActive(true);
    }

    void RefreshCatList()
    {
        Transform content = CatListPanel.transform.Find("Content");
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
            item.transform.Find("Button/CatName").GetComponent<Text>().text = cat.name;
            /*item.transform.Find("Stability").GetComponent<Text>().text = "Stability: " + cat.stability;
            item.transform.Find("Activity").GetComponent<Text>().text = "Activity: " + cat.activity;
            item.transform.Find("Communion").GetComponent<Text>().text = "Communion: " + cat.communion;*/
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
        Transform content = FurnitureListPanel.transform.Find("Content");
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
    }
}
