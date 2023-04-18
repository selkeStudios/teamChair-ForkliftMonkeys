using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadingRectBehaviour : MonoBehaviour
{
    public GameObject winnerScreen;

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void setWinnerTextActive()
    {
        winnerScreen.SetActive(true);
    }
}
