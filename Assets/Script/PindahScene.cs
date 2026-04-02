using UnityEngine;
using UnityEngine.SceneManagement; // Library wajib untuk pindah scene

public class PindahScene : MonoBehaviour
{
    // Fungsi untuk pindah ke scene Materi
    public void BukaMateri()
    {
        SceneManager.LoadScene("Materi_Home");
    }

    // Fungsi untuk pindah ke scene Quiz
    public void BukaQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

     public void BukaHome()
    {
        SceneManager.LoadScene("Home");
    }

     public void BukaMateriHome1()
    {
        SceneManager.LoadScene("Materi_Home");
    }

     public void BukaMateriHome2()
    {
        SceneManager.LoadScene("Materi_Home2");
    }

    public void BukaMateriSelesai()
    {
        SceneManager.LoadScene("MateriSelesai");
    }

    public void BukaARUranus()
    {
        SceneManager.LoadScene("AR_URANUS");
    }

    public void BukaAREarth()
    {
        SceneManager.LoadScene("AR_EARTH");
    }

    public void BukaARJupiter()
    {
        SceneManager.LoadScene("AR_JUPITER");
    }

    public void BukaARMars()
    {
        SceneManager.LoadScene("AR_MARS");
    }

    public void BukaARMerkurius()
    {
        SceneManager.LoadScene("AR_MERKURIUS");
    }

    public void BukaARNeptunus()
    {
        SceneManager.LoadScene("AR_NEPTUNUS");
    }
    public void BukaARSaturnus()
    {
        SceneManager.LoadScene("AR_SATURNUS");
    }

    public void BukaARVenus()
    {
        SceneManager.LoadScene("AR_VENUS");
    }

     public void BukaMateriUranus()
    {
        SceneManager.LoadScene("Materi_URANUS");
    }

    public void BukaMateriEarth()
    {
        SceneManager.LoadScene("Materi_Earth");
    }

    public void BukaMateriJupiter()
    {
        SceneManager.LoadScene("Materi_Jupiter");
    }

    public void BukaMateriMars()
    {
        SceneManager.LoadScene("Materi_Mars");
    }

    public void BukaMateriMerkurius()
    {
        SceneManager.LoadScene("Materi_Merkurius");
    }

    public void BukaMateriNeptunus()
    {
        SceneManager.LoadScene("Materi_Neptunus");
    }
    public void BukaMateriSaturnus()
    {
        SceneManager.LoadScene("Materi_Saturnus");
    }

    public void BukaMateriVenus()
    {
        SceneManager.LoadScene("Materi_Venus");
    }
}