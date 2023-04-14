using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    //Set the float to the max/min X/Z to have the boxes spawn somewhere on the
    //Stage still accessible for players to get
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;

    //How high the boxes will spawn to not conflict with players respawning
    public float spawnY;

    //chances for a box to spawn on a given second
    public int boxChance;

    //How many frames another box can't be spawned for after one is spawned
    public float boxCooldown;

    //The prefab box
    public GameObject powerUpBoxRef;

    public bool canSpawnBoxes;
    private UIUXCanvasScript ux;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(spawnBox());
        ux = FindObjectOfType<UIUXCanvasScript>();
    }

    private void Update()
    {
        if(ux.timer <= 0)
        {
            canSpawnBoxes = false;
        }
    }

    public IEnumerator spawnBox()
    {
        while (canSpawnBoxes == true)
        {
            if (boxChance == (int)(Random.Range(0.001f, boxChance - .0000000000001f) + 1))
            {
                Vector3 spawnLocation = new Vector3(Random.Range(minX, maxX), spawnY, Random.Range(minZ, maxZ));
                Instantiate(powerUpBoxRef, spawnLocation, Quaternion.Euler(0, 0, 0));
                yield return new WaitForSeconds(boxCooldown);
            }
            else
            {
                yield return null;
            }
        }
    }
}
