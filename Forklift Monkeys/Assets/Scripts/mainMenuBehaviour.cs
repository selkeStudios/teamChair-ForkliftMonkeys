using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuBehaviour : MonoBehaviour
{
    public Animator monkeyTransition;

    public void buttonClicked()
    {
        monkeyTransition.SetTrigger("monkeyCanTransition");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Testing");
    }
}
