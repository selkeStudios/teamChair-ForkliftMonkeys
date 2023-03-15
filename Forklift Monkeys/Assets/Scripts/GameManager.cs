using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;
    public PlayerInputManager pIM;
    public Transform[] playerSpawnPts;

    void Start()
    {
        joinANewPlayer();
        /*
        for (int i = 0; i < 4; ++i)
        {
            joinANewPlayer();
            //The first parameter controls which screen the respective player is on

            //print(i);
        }
        */
        //pIM.JoinPlayer(1, 1, null);
        /*
        for (int i = 0; i < 2; i++)
        {
            pIM.JoinPlayer(i, i, "test", inputDevice);
            //pIM.playerPrefab.transform.position = playerSpawnPts[i].position;
        }
        */
        //JoinPlayer(0, 0, );
    }

    private void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.L))
        {
            joinANewPlayer();
        }
        */
    }

    public void joinANewPlayer()
    {
        if(pIM.playerCount < pIM.maxPlayerCount)
        {
            int playerIndex = pIM.playerCount;
            pIM.JoinPlayer(playerIndex);

            pIM.playerPrefab.gameObject.transform.position = playerSpawnPts[playerIndex].position;
        }
    }

    //public PlayerInput JoinPlayer(int playerIndex, int splitScreenIndex, string controlScheme = null, params InputDevice[] pairWithDevices)
    //{
    //return GameObject;
    //}
}