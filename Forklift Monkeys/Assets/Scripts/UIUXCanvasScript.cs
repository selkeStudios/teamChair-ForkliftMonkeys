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

    public bool canCountDown;
    public float timeUntilBeginning;

    public AudioSource music;
    public float musicCountUp;

    public float timer;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI winnerText;
    public int winnerIndexValue = 0;

    public bool setScoresToZero;
    public Animator fadingRect;
    public bool haveScoresTied = false;

    private void Start()
    {
        setScoresToZero = true;
        music.volume = 0;
        StartCoroutine(playMusic());
    }

    void Update()
    {
        if(players.Count >= 4 && canCountDown)
        {
            timer -= Time.deltaTime;
            music.volume += musicCountUp;
            if(music.volume >= 1)
            {
                music.volume = 1;
            }
        }
        timerText.text = timer.ToString("N0");

        if(timer <= 0)
        {
            timerText.color = Color.red;
            timer = 0;
            StartCoroutine(fadeToBlack());
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

        for (int i = 0; i < players.Count; ++i)
        {
            int largestNumber = players[winnerIndexValue].Score;

            if (players[i].Score > largestNumber)
            {
                largestNumber = players[i].Score;
                winnerIndexValue = players.IndexOf(players[i]);
                //haveScoresTied = false;
                //print(largestNumber);
            }
            /*
            else if (players[i].Score == largestNumber)
            {
                haveScoresTied = true;
            }
            */
        }

        switch (winnerIndexValue)
        {
            case 0:
                winnerText.text = "Player 1 Wins!";
                break;
            case 1:
                winnerText.text = "Player 2 Wins!";
                break;
            case 2:
                winnerText.text = "Player 3 Wins!";
                break;
            case 3:
                winnerText.text = "Player 4 Wins!";
                break;
            default:
                winnerText.text = "Player 1 Wins!";
                break;
        }

        /*
        if (!haveScoresTied)
        {
            
        } else
        {
            winnerText.text = "Tie!";
        }
        */
    }

    IEnumerator fadeToBlack()
    {
        yield return new WaitForSeconds(2f);
        fadingRect.SetTrigger("fadeInTrans");
    }

    IEnumerator playMusic()
    {
        yield return new WaitForSeconds(timeUntilBeginning);
        canCountDown = true;
        music.Play();
    }
}
