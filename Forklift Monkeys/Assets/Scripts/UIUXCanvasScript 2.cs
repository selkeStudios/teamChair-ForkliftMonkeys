using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUXCanvasScript : MonoBehaviour
{
    public List<ForwardMovement> players = new List<ForwardMovement>();
    public TextMeshProUGUI[] powerUpTexts;

    public float timer;
    public TextMeshProUGUI timerText;

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("N0");

        if(timer <= 0)
        {
            timerText.color = Color.red;
            timer = 0;
        }

        foreach (ForwardMovement fM in players)
        {
            switch (fM.PowerUp)
            {
                case 1:
                    powerUpTexts[players.IndexOf(fM)].text = "Oil";
                    break;
                case 2:
                    powerUpTexts[players.IndexOf(fM)].text = "Anvil";
                    break;
                case 3:
                    powerUpTexts[players.IndexOf(fM)].text = "Boxing";
                    break;
                default:
                    powerUpTexts[players.IndexOf(fM)].text = "None";
                    break;
            }
        }

    }
}
