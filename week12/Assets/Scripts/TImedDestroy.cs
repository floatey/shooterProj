using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float destroyDelay;
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
