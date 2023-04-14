using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraBehaviour : MonoBehaviour
{
    public GameObject parent;
    public bool isChilded;
    public Vector3 startPos;

    private void Start()
    {
        isChilded = true;
        parent = transform.parent.gameObject;
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChilded)
        {
            transform.parent = parent.GetComponent<Transform>();
            //transform.rotation = Quaternion.Euler(19, transform.rotation.y, transform.rotation.z);
        } else
        {
            transform.parent = null;
        }
    }
}
