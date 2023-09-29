using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField]private AudioSource ButtonClick;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ButtonClick.Play();
    }

    public void Settings()
    {
        SceneManager.LoadScene(5);
    }
    public void Quit()
    {
        ButtonClick.Play();
        Application.Quit();
    }
}
