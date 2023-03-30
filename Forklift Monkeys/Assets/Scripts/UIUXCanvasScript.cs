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
    public float[] playerRespawnRotationYValues;

    public float timer;
    public TextMeshProUGUI timerText;

    public bool setScoresToZero;

    private void Start()
    {
        setScoresToZero = true;
    }

    void Update()
    {
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

            fM.playerIndex = players.IndexOf(fM);

            scoreTexts[players.IndexOf(fM)].text = fM.Score.ToString();

            if (setScoresToZero && players.Count >= 4)
            {
                fM.Score = 0;
                setScoresToZero = false;
            }
        }

    }
}
