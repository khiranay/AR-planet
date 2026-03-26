using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizUIManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionData
    {
        [TextArea(2, 10)]
        public string questionText;
        public Sprite questionSprite;
        public string[] options = new string[4];
        public int correctIndex;
    }

    [Header("Question List")]
    public QuestionData[] questions;

    [Header("UI References")]
    public TMP_Text questionNumberText;
    public TMP_Text uiQuestionText;
    public Image uiQuestionImage;

    public Button[] optionButtons;
    public TMP_Text[] optionButtonTexts;  // ← PASTIKAN INI ADA

    public GameObject quizPanel;
    public GameObject resultPanel;
    public TMP_Text scoreText;
    public ScrollRect scrollRect;

    private int currentQuestion = 0;
    private int score = 0;

    void Start()
    {
        resultPanel.SetActive(false);
        quizPanel.SetActive(true);
        LoadQuestion();
    }

    void LoadQuestion()
    {
        QuestionData q = questions[currentQuestion];

        questionNumberText.text = $"Soal {currentQuestion + 1}";
        uiQuestionText.text = q.questionText;

        if (q.questionSprite != null)
        {
            uiQuestionImage.gameObject.SetActive(true);
            uiQuestionImage.sprite = q.questionSprite;
            uiQuestionImage.preserveAspect = true;
        }
        else
        {
            uiQuestionImage.gameObject.SetActive(false);
        }

        string[] labels = { "A. ", "B. ", "C. ", "D. " };

        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtonTexts[i].text = labels[i] + q.options[i]; // line 58
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(index));
        }

        if (scrollRect != null)
            scrollRect.verticalNormalizedPosition = 1f;
    }

    void OnOptionSelected(int index)
    {
        if (index == questions[currentQuestion].correctIndex)
        {
            score += 10;
        }

        currentQuestion++;

        if (currentQuestion >= questions.Length)
        {
            ShowResult();
        }
        else
        {
            LoadQuestion();
        }
    }

    void ShowResult()
    {
        resultPanel.SetActive(true);
        quizPanel.SetActive(false);
        scoreText.text = $"Skor: {score} / 100";
    }

    public void RestartQuiz()
{
    currentQuestion = 0;
    score = 0;
    resultPanel.SetActive(false);
    quizPanel.SetActive(true);
    LoadQuestion();
}
}