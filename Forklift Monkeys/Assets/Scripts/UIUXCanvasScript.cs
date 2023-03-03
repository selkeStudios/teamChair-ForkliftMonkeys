using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUXCanvasScript : MonoBehaviour
{
    public List<ForwardMovement> players = new List<ForwardMovement>();
    public TextMeshProUGUI[] powerUpTexts;
    public TextMeshProUGUI[] scoreTexts;

    public float timer;
    public TextMeshProUGUI timerText;

    public Image[] sRs;
    public TextMeshProUGUI[] textColors;

    public bool setScoresToZero;

    private void Start()
    {
        setScoresToZero = true;
    }

    void Update()
    {
        //print(players.Count);
        if(players.Count >= 4)
        {
            timer -= Time.deltaTime;
        }
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

            scoreTexts[players.IndexOf(fM)].text = fM.Score.ToString();

            if (setScoresToZero && players.Count >= 4)
            {
                fM.Score = 0;
                setScoresToZero = false;
            }
        }

        foreach(Image s in sRs)
        {
            if(players.Count >= 4)
            {
                s.color = new Color(1, 1, 1, 1);
            } else
            {
                s.color = new Color(1, 1, 1, 0);
            }
        }

        foreach (TextMeshProUGUI t in textColors)
        {
            if (players.Count >= 4)
            {
                t.color = new Color(1, 1, 1, 1);
            }
            else
            {
                t.color = new Color(1, 1, 1, 0);
            }
        }

    }
}
