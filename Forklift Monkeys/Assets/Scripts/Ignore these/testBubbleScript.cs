using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was just a testing script to see if transferring scripts and prefabs through Github would work or not ~ Scott

public class testBubbleScript : MonoBehaviour
{
    public float shrinkingValue = 0.25f;
    public float upSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 bubbleTransformPos = gameObject.GetComponent<Transform>().localPosition;
        bubbleTransformPos.y += upSpeed;
        gameObject.GetComponent<Transform>().localPosition = new Vector3(bubbleTransformPos.x, bubbleTransformPos.y, bubbleTransformPos.z);

        Vector3 bubbleTransformScale = gameObject.GetComponent<Transform>().localScale;
        bubbleTransformScale.x -= shrinkingValue;
        bubbleTransformScale.y -= shrinkingValue;
        bubbleTransformScale.z -= shrinkingValue;

        gameObject.GetComponent<Transform>().localScale = new Vector3(bubbleTransformScale.x, bubbleTransformScale.y, bubbleTransformScale.z);

        if (bubbleTransformScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
