using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    private int score=0;
    [SerializeField]private GameObject LostPanel;
    [SerializeField]private GameObject PausePanel;
    [SerializeField]private GameObject GameWon;
    [SerializeField]private TMP_Text scoreTxt;
    [SerializeField]private TMP_Text EndScore;
    private bool paused = false;

    [SerializeField]private AudioSource Collect;
    [SerializeField]private AudioSource Death;
    [SerializeField]private AudioSource Won;
    [SerializeField]private AudioSource BackgroundMusic;

    private bool firstTime = true;
    [SerializeField]private Animator MomAnimator;

    public MomMovement momScript;


    void Update()
    {
        scoreTxt.text = "Score : "+(score*10);

        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            paused = true;
            BackgroundMusic.Pause();
        } else if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            paused = false;
            BackgroundMusic.Play();
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        { 
            if (firstTime)
            {
                StartCoroutine(MomEnter());
                firstTime = false;
            } else 
            {
                Death.Play();
                Time.timeScale = 0;
                LostPanel.SetActive(true);
                BackgroundMusic.Stop();
                firstTime = true;
            }
        }
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            Collect.Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "END")
        {
            Won.Play();
            Time.timeScale = 0;
            GameWon.SetActive(true);
            BackgroundMusic.Stop();
            EndScore.text = "Score : "+score*10;
        }
    }
     IEnumerator MomEnter()
    {
        momScript.speedAuto = 3f;
        yield return new WaitForSeconds(1f);
        momScript.speedAuto = 0f;
        yield return new WaitForSeconds(2f);
        momScript.speedAuto = -3f;
        yield return new WaitForSeconds(1f);
        momScript.speedAuto = 0f;
        //momScript.GoBack();
        firstTime = true;

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1) ;
        Time.timeScale = 1;
    } 

    public void StartAgain()
    {
        LostPanel.SetActive(false);
        Time.timeScale = 1;
        score = 0;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
