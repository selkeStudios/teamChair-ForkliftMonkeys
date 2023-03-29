using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuBehaviour : MonoBehaviour
{
    public Animator monkeyTransition;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            buttonClicked();
        }
    }

    public void buttonClicked()
    {
        monkeyTransition.SetTrigger("monkeyCanTransition");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Testing");
    }
}
