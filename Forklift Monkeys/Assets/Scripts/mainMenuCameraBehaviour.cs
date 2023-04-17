using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCameraBehaviour : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, rotateSpeed, 0f);
    }
}
