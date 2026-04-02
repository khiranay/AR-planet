using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionData {
        public string question;
        public string[] answers;
        public int correctAnswerIndex;
    }

    [Header("Quiz Data")]
    public List<QuestionData> questionList = new List<QuestionData>();
    private int currentQuestionIndex = 0;
    private int totalSkor = 0;
    private float currentTime;
    private bool isQuizActive = false;

    [Header("UI References")]
    public TMP_Text questionText;
    public TMP_Text questionNumberText;
    public TMP_Text scoreText;

    [Header("Answer Buttons")]
    public AnswerButton[] answerButtons; // Drag object Button yang punya script AnswerButton ke sini

    [Header("Panels")]
    public GameObject quizPanel;
    public GameObject resultPanel;
    public GameObject feedbackPanel; // Panel kecil "Benar/Salah" (Opsional)

    [Header("Feedback Settings")]
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public float delayAfterAnswer = 1.0f; // Jeda waktu (detik)

    [Header("Result UI")]
    public TMP_Text finalScoreText;

    [Header("Timer")]
    public Slider timerSlider;
    public float timePerQuestion = 15f;

    void Start()
    {
        if (resultPanel != null) resultPanel.SetActive(false);
        if (quizPanel != null) quizPanel.SetActive(true);
        if (feedbackPanel != null) feedbackPanel.SetActive(false);
        
        StartQuiz();
    }

    public void StartQuiz()
    {
        totalSkor = 0;
        currentQuestionIndex = 0;
        isQuizActive = true;
        DisplayQuestion();
    }

    void Update()
    {
        if (isQuizActive)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        currentTime -= Time.deltaTime;
        if (timerSlider != null) timerSlider.value = currentTime;

        if (currentTime <= 0)
        {
            StartCoroutine(ProcessAnswer(-1, null)); // Waktu habis dianggap salah
        }
    }

    void DisplayQuestion()
    {
        if (currentQuestionIndex < questionList.Count)
        {
            currentTime = timePerQuestion;
            if (timerSlider != null) timerSlider.maxValue = timePerQuestion;

            QuestionData data = questionList[currentQuestionIndex];
            questionText.text = data.question;
            questionNumberText.text = "Soal " + (currentQuestionIndex + 1) + "/" + questionList.Count;
            
            // Update teks pada setiap tombol
            for (int i = 0; i < answerButtons.Length; i++)
            {
                TMP_Text btnText = answerButtons[i].GetComponentInChildren<TMP_Text>();
                if (btnText != null) btnText.text = data.answers[i];
                
                // Reset warna ke putih setiap soal baru
                answerButtons[i].SetColor(Color.white);
            }
        }
        else
        {
            ShowResult();
        }
    }

    // Dipanggil oleh script AnswerButton
    public void OnAnswerSelected(int index, AnswerButton clickedBtn)
    {
        if (!isQuizActive) return;
        StartCoroutine(ProcessAnswer(index, clickedBtn));
    }

    IEnumerator ProcessAnswer(int index, AnswerButton clickedBtn)
    {
        isQuizActive = false; // Matikan timer & klik selama proses feedback

        int correctIdx = questionList[currentQuestionIndex].correctAnswerIndex;

        if (index == correctIdx)
        {
            if (clickedBtn != null) clickedBtn.SetColor(correctColor);
            totalSkor += 10;
            if (scoreText != null) scoreText.text = "Skor: " + totalSkor;
        }
        else
        {
            if (clickedBtn != null) clickedBtn.SetColor(wrongColor);
            // Tunjukkan jawaban yang benar
            answerButtons[correctIdx].SetColor(correctColor);
        }

        yield return new WaitForSeconds(delayAfterAnswer);

        currentQuestionIndex++;
        isQuizActive = true;
        DisplayQuestion();
    }

    void ShowResult()
    {
        isQuizActive = false;
        if (quizPanel != null) quizPanel.SetActive(false);
        if (resultPanel != null) resultPanel.SetActive(true);
        if (finalScoreText != null) finalScoreText.text = "Total Skor: " + totalSkor;
    }
}