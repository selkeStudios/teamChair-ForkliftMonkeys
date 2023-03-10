using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public static InputUser PerformPairingWithDevice(InputDevice device, InputUser user = default(InputUser), InputUserPairingOptions options = InputUserPairingOptions.None)
    {
        return ;
    }

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