using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraBehaviour : MonoBehaviour
{
    public GameObject parent;
    public bool isChilded;

    public bool resetPos;

    public Vector3 startPos;
    public Quaternion startRot;

    private void Start()
    {
        isChilded = true;
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChilded)
        {
            transform.parent = parent.GetComponent<Transform>();
            if(resetPos)
            {
                transform.SetLocalPositionAndRotation(startPos, startRot);
                resetPos = false;
            }
            //transform.rotation = Quaternion.Euler(19, transform.rotation.y, transform.rotation.z);
        } else
        {
            transform.parent = null;
            resetPos = true;
        }
    }
}
