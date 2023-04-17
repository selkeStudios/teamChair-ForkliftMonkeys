using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCautionTapeBehaviour : MonoBehaviour
{
    public float scrollingSpeed;

    public float xToResetAt;
    public float xToResetTo;

    public Vector3 newCautionTapePos;

    public bool isTopTape; //True = - // False = +

    // Start is called before the first frame update
    void Start()
    {
        xToResetTo = transform.position.x;
        newCautionTapePos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        newCautionTapePos.x += scrollingSpeed;

        if (newCautionTapePos.x <= xToResetAt && isTopTape)
        {
            newCautionTapePos.x = xToResetTo;
        }

        if (newCautionTapePos.x > xToResetAt && !isTopTape)
        {
            newCautionTapePos.x = xToResetTo;
        }

        transform.position = newCautionTapePos;
    }
}
