using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;
    void Start()
    {
        JoinPlayer(0, 0);
    }

    public PlayerInput JoinPlayer(int playerIndex, int splitScreenIndex, string controlScheme = null, params InputDevice[] pairWithDevices)
    {
        return PlayerObject;
    }
}