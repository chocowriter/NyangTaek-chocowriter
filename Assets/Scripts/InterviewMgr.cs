using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterviewMgr : MonoBehaviour
{
    int Index = 0;
    int questionCount = 0;
    int maxQuestionCount = 3;

    [Header("Interview")]
    // 기본 행동 버튼들
    public Button ApproachBtn;
    public Button StareBtn;
    public Button SmellBtn;
    public Button IgnoreBtn;
    public Button DecideBtn;
    public Button AcceptBtn;
    public Button RejectBtn;

    public GameObject ExActPanel; // 추가 행동 패널

    public Text CountText;

    [Header("Result")]
    public Text ResultText;
    public Button NextBtn;
    public Button TownBtn;

    public Image applicantImage;

    public GameObject GanteakPanel;
    public GameObject ResultPanel;
    public GameObject DialogBox;

    public GameObject textPrefab;

    public GameObject memoPanel;
    public GameObject documentPanel;

    string catName = "고양이";

    bool hasApproached = false;
    bool hasStared = false;
    bool hasSmelled = false;
    bool hasIgnored = false;

    GameState gameState;
    GameDataBase gameDataBase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Index = 0; // 현재 면접 보고 있는 지원자의 인덱스
        gameState = FindAnyObjectByType<GameState>();
        gameDataBase = FindAnyObjectByType<GameDataBase>();
        ApproachBtn.onClick.AddListener(Approach);
        StareBtn.onClick.AddListener(Stare);
        SmellBtn.onClick.AddListener(Smell);
        IgnoreBtn.onClick.AddListener(Ignore);

        GanteakPanel.SetActive(false);
        DecideBtn.onClick.AddListener(Decide);
        AcceptBtn.onClick.AddListener(() => ShowResult(true));
        RejectBtn.onClick.AddListener(() => ShowResult(false));
        //NextBtn.onClick.AddListener(Next);
        TownBtn.onClick.AddListener(Town);

        //StartInterview();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCount();
    }

    void StartInterview()
    {
        //
        questionCount = 0;
        string spriteURL = gameDataBase.Applicants.applicants[Index].image_url;
        if (spriteURL != null)
            applicantImage.sprite = Resources.Load<Sprite>("Images/" + spriteURL);
    }
    void Approach()
    {
        //
        if (hasApproached)
            return;     // 이미 다가간 경우 무시

        hasApproached = true;

        if (questionCount >= maxQuestionCount)
            return;     // 최대 질문 수를 초과한 경우 무시

        questionCount++;
        AddLog(catName, "다가간다");
        AddLog(gameDataBase.Applicants.applicants[Index].name, gameDataBase.Applicants.applicants[Index].reaction_approach);

        ExActPanel.transform.Find("Ex1Button").GetComponent<Button>().onClick.AddListener(() => AddLog(gameDataBase.Applicants.applicants[Index].reaction_approach_ex1));
        ExActPanel.transform.Find("Ex2Button").GetComponent<Button>().onClick.AddListener(() => AddLog(gameDataBase.Applicants.applicants[Index].reaction_approach_ex2));
        ExActPanel.SetActive(true);
        
    }

    void Stare()
    {
        //
        if (hasStared)
            return;     // 이미 노려본 경우 무시

        hasStared = true;

        if (questionCount >= maxQuestionCount)
            return;     // 최대 질문 수를 초과한 경우 무시

        questionCount++;
        AddLog(catName,"노려본다");
        AddLog(gameDataBase.Applicants.applicants[Index].name, gameDataBase.Applicants.applicants[Index].reaction_stare);
    }

    void Smell()
    {
        //
        if (hasSmelled)
            return;     // 이미 냄새 맡은 경우 무시

        hasSmelled = true;

        if (questionCount >= maxQuestionCount)
            return;     // 최대 질문 수를 초과한 경우 무시

        questionCount++;
        AddLog(catName, "냄새 맡는다");
        AddLog(gameDataBase.Applicants.applicants[Index].name, gameDataBase.Applicants.applicants[Index].reaction_smell);
    }

    void Ignore()
    {
        //
        if (hasIgnored)
            return;     // 이미 무시한 경우 무시

        hasIgnored = true;

        if (questionCount >= maxQuestionCount)
            return;     // 최대 질문 수를 초과한 경우 무시

        questionCount++;
        AddLog(catName, "무시한다");
        AddLog(gameDataBase.Applicants.applicants[Index].name, gameDataBase.Applicants.applicants[Index].reaction_ignore);
    }

    void Decide()
    {
        GanteakPanel.SetActive(true);
        
    }

    void ShowResult(bool isPassed)
    {
        if (isPassed)
        {
            ResultText.text = "합격입니다!";
            gameState.ownedApplicantIds.Add(gameDataBase.Applicants.applicants[Index].id);
        }
        else
        {
            ResultText.text = "불합격입니다!";
            gameState.ownedApplicantIds.Remove(gameDataBase.Applicants.applicants[Index].id);    // 불합격 저장 (1은 합격, 0은 불합격)
        }

        GanteakPanel.SetActive(false);
        ResultPanel.SetActive(true);
    }

    /*void Next()
    {
        if (Index >= gameState.applicantDataList.Count)
            return;

        GlobalValue.interviewIndex++;
        ResultPanel.SetActive(false);
        SceneManager.LoadScene("ResumeScene");
        
    }*/

    void Town()
    {
        SceneManager.LoadScene("TownScene");
    }

    void AddLog(string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform);
        logText.GetComponent<Text>().text = log;
    }

    void AddLog(string name, string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform);
        logText.GetComponent<Text>().text = name + ":" + log;
    }

    void ShowCount()
    {
        CountText.text = "남은 행동\n" + (maxQuestionCount - questionCount) + "/" + maxQuestionCount;
    }

    public void ShowMemo()
    {
        // 메모 보여주는 함수
        memoPanel.SetActive(true);
    }

    public void HideMemo()
    {
        // 메모 숨기는 함수
        memoPanel.SetActive(false);
    }

    public void ShowDocument()
    {
        documentPanel.SetActive(true);
    }

    public void HideDocument()
    {
        documentPanel.SetActive(false);
    }
}
