using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{

    public int objectType;

    private void Update()
    {
        if(objectType == 1)
        {
            //This is a bullet.
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        } else if (objectType == 2 )
        {
            //This is enemy type one.
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 3f);
        } else if (objectType == 3 )
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(3f, 8f));
        }

        if(transform.position.y > 11f || transform.position.y < -11f && objectType != 3)
        {
            Destroy(this.gameObject);
        }
    }

}
