using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUXCanvasScript : MonoBehaviour
{
    public List<ForwardMovement> players = new List<ForwardMovement>();
    //public TextMeshProUGUI[] powerUpTexts;
    public TextMeshProUGUI[] scoreTexts;
    public float[] playerRespawnRotationYValues;
    public List<Animator> individualFadingCameraRects = new List<Animator>();

    public Image winScreen;
    public Sprite[] potentialWinScreenSprites;

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
    public bool canCheckForTies = true;

    public float[] calculatedKnockBackToNeedleAmts;
    public Transform[] speedometerNeedleTransforms;
    public int highestPlayerScore = -1;
    public int playersWhoTied;

    private void Start()
    {
        setScoresToZero = true;
        music.volume = 0;
        StartCoroutine(playMusic());
    }

    void Update()
    {
        if (players.Count >= 4 && canCountDown)
        {
            timer -= Time.deltaTime;
            music.volume += musicCountUp;
            if (music.volume >= 1)
            {
                music.volume = 1;
            }
        }
        timerText.text = timer.ToString("N0");

        if (timer <= 0)
        {

            timerText.color = Color.red;
            timer = 0;
            checkForTies();
            StartCoroutine(fadeToBlack());
        }

        if (playersWhoTied > 1)
        {
            winnerIndexValue = 4;
        }

        foreach (ForwardMovement fM in players)
        {
            /*
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
            */

            fM.playerIndex = players.IndexOf(fM);

            fM.cameraRect = individualFadingCameraRects[fM.playerIndex];

            scoreTexts[players.IndexOf(fM)].text = fM.Score.ToString();

            if (setScoresToZero && players.Count >= 4)
            {
                fM.Score = 0;
                setScoresToZero = false;
            }

            for (int i = 0; i < players.Count; ++i)
            {
                calculatedKnockBackToNeedleAmts[i] = ((-players[i].knockBackAmt / 100 + 1) * 180) - 90;
                speedometerNeedleTransforms[i].rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, calculatedKnockBackToNeedleAmts[i]);
            }

            if (fM.Score > highestPlayerScore) //This part works, it's just the ties that don't
            {
                highestPlayerScore = fM.Score;
                winnerIndexValue = players.IndexOf(fM);
            }

            if(fM.isGrounded)
            {
                fM.GetComponent<BoxCollider>().material.dynamicFriction = fM.groundedFriction;
                fM.GetComponent<BoxCollider>().material.staticFriction = fM.groundedFriction;
            } else if(!fM.isGrounded)
            {
                fM.GetComponent<BoxCollider>().material.dynamicFriction = fM.notGroundedFriction;
                fM.GetComponent<BoxCollider>().material.staticFriction = fM.notGroundedFriction;
            }
        }

        switch (winnerIndexValue)
        {
            case 0:
                //winnerText.text = "Yellow Player Wins!";
                winScreen.sprite = potentialWinScreenSprites[0];
                break;
            case 1:
                //winnerText.text = "Red Player Wins!";
                winScreen.sprite = potentialWinScreenSprites[1];
                break;
            case 2:
                //winnerText.text = "Blue Player Wins!";
                winScreen.sprite = potentialWinScreenSprites[2];
                break;
            case 3:
                //winnerText.text = "Green Player Wins!";
                winScreen.sprite = potentialWinScreenSprites[3];
                break;
            default:
                //winnerText.text = "Tie!";
                winScreen.sprite = potentialWinScreenSprites[4];
                break;
        }
    }

    public void checkForTies()
    {
        if(canCheckForTies)
        {
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].Score == highestPlayerScore)
                {
                    playersWhoTied++;
                }
            }
            canCheckForTies = false;
        }
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
