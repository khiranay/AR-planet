using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [Tooltip("0=A, 1=B, 2=C, 3=D")]
    public int buttonIndex;

    private QuizManager quizManager;
    private Button button;
    private Image buttonImage;

    void Start()
    {
        // Mencari QuizManager di Scene
        quizManager = Object.FindFirstObjectByType<QuizManager>();
        
        // Mengambil komponen Button dan Image dari object ini
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        if (quizManager != null && button != null)
        {
            button.onClick.RemoveAllListeners();
            // Mengirim index dan referensi script ini (this) ke Manager
            button.onClick.AddListener(() => quizManager.OnAnswerSelected(buttonIndex, this));
        }
    }

    // Fungsi untuk mengubah warna tombol dari script Manager
    public void SetColor(Color color)
    {
        if (buttonImage != null)
        {
            buttonImage.color = color;
        }
    }
}