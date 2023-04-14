using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuBehaviour : MonoBehaviour
{
    public Animator monkeyTransition;

    public Animator tutorialAnim1;
    public Animator tutorialAnim2;

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
        StartCoroutine(tutorialOneShow());
    }

    public IEnumerator tutorialOneShow()
    {
        tutorialAnim1.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f);
        tutorialAnim1.SetTrigger("fadee");
        yield return new WaitForSeconds(1f);
        StartCoroutine(tutorialTwoShow());
    }

    public IEnumerator tutorialTwoShow()
    {
        tutorialAnim2.gameObject.SetActive(true);
        yield return new WaitForSeconds(8f);
        tutorialAnim2.SetTrigger("fadee");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Testing");
    }
}
