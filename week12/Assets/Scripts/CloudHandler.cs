using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloudHandler : MonoBehaviour
{

    private float cloudSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cloudSpeed = Random.Range(0.2f, 1f);
        float tempValue = Random.Range(1, 3.5f);
        transform.localScale = new Vector3(1,1,1) * tempValue;
        tempValue = Random.Range(0.1f, 0.6f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, tempValue);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0)* Time.deltaTime * cloudSpeed);
        if (transform.position.y < -11f)
        {
            transform.position = new Vector3(Random.Range(-11f, 11f), 7.5f, 0);
        }
    }
}
