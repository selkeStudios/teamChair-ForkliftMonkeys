using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    static PlayerInput Instantiate(GameObject PlayerPrefab, int playerIndex, string controlScheme = null, int splitScreenIndex = 0, InputDevice pairWithDevice = null)
    {
        return PlayerPrefab.GetComponent<PlayerInput>();
    }


    void Start()
    {
        Instantiate(PlayerPrefab, 0, null, 0, null);
    }

    //public PlayerInput JoinPlayer(int playerIndex, int splitScreenIndex, string controlScheme = null, params InputDevice[] pairWithDevices)
    //{
        //return GameObject;
    //}
  }