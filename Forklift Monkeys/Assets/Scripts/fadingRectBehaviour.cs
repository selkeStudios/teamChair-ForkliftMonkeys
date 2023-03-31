using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadingRectBehaviour : MonoBehaviour
{
    public GameObject winnerText;

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void setWinnerTextActive()
    {
        winnerText.SetActive(true);
    }
}
