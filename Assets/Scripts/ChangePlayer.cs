using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePlayer : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject[] characters;
    public int playerChosen=0;
    #endregion
    #region Chosing character to play
    public void ChangeCharacter(string r)
    {
        characters[playerChosen].SetActive(false);
        if (r == "R" && playerChosen < characters.Length - 1)
        {
            playerChosen++;
        }
        else if (r == "L" && playerChosen > 0)
        {
            playerChosen--;
        }
        characters[playerChosen].SetActive(true);
        
    }
    #endregion
    #region Save character selection
    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("Player", playerChosen);
        PlayerPrefs.Save();
        Debug.Log("Chose " + playerChosen);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
}
