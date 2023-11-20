using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
           if (collision.GetComponent<PlayerController>().shieldActive != true)
            {
                collision.GetComponent<PlayerController>().LoseLife();
                Destroy(gameObject);
            }
           else
            {
                Destroy(gameObject);
            }
        }
        else if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
