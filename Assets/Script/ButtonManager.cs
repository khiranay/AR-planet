using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class ButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Materi()
    {
        SceneManager.LoadScene("mufti_informasi");
    }
    public void Video()
    {
        SceneManager.LoadScene("video");
    }
    public void simulasi()
    {
        SceneManager.LoadScene("simulasi");
    }

}
