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
        
        for (int i = 0; i < 4; i++)
        {
            PlayerInput.Instantiate(PlayerObject, i, null, -1, pairWithDevice: Keyboard.current);

            //places players at their respawn point 
            pIM.playerPrefab.transform.position = playerSpawnPts[i].position;
            pIM.playerPrefab.GetComponent<ForwardMovement>().RespawnPoint = playerSpawnPts[i].position;
        }
        
        //PlayerInput.Instantiate(PlayerObject, 0, null, -1, pairWithDevice: Keyboard.current);
        //PlayerInput.Instantiate(PlayerObject, 1, null, -1, pairWithDevice: Gamepad.all[0]);

        /*
        for (int i = 0; i < 4; i++)
        {
            //spawns in the four players paired to their device
            PlayerInput.Instantiate(PlayerObject, i, null, -1, pairWithDevice: Gamepad.all[i]);

            //places players at their respawn point 
            pIM.playerPrefab.transform.position = playerSpawnPts[i].position;
            pIM.playerPrefab.GetComponent<ForwardMovement>().RespawnPoint = playerSpawnPts[i].position;
        }
        */
    }
}