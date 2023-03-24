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
        //PlayerInput.Instantiate(PlayerObject, 1, null, -1, pairWithDevice: Keyboard.current);

        for (int i = 0; i < 4; i++)
        {
            //spawns in the four players paired to their device
            PlayerInput.Instantiate(PlayerObject, i, null, -1, pairWithDevice: Gamepad.all[i]);

            //places players at their respawn point 
            pIM.playerPrefab.transform.position = playerSpawnPts[i].position;
            pIM.playerPrefab.GetComponent<ForwardMovement>().RespawnPoint = playerSpawnPts[i].position;
        }
    }
}