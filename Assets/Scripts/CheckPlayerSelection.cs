using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] player;
    int playerSelected;

    void Start()
    {
        playerSelected = PlayerPrefs.GetInt("Player");
        for (int i = 0; i < player.Length; i++)
        {
            if (i != playerSelected)
                player[i].SetActive(false);
            else
                player[i].SetActive(true);
        }
    }
    
}
