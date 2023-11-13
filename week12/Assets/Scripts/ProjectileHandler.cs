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
        }

        if(transform.position.y > 11f)
        {
            Destroy(this.gameObject);
        }
    }

}
