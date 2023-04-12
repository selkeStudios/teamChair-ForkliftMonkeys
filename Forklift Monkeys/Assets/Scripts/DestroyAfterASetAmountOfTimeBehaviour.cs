using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterASetAmountOfTimeBehaviour : MonoBehaviour
{
    public float destroyAfterThisTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfterThisTime);
    }
}
