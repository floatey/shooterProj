using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject soundPrefab;
    public float playerSpeed;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 4.1f;
    public int lives;
    public int score;
    public bool shieldActive;

    private void Start()
    {
        playerSpeed = 6f;
        lives = 3;
    }

    private void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        if (lives > 0) { }
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }

        if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        } else if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space) && lives > 0)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            Instantiate(soundPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    public void LoseLife()
    {
        lives--;
        gameObject.transform.GetChild(1).GetComponent<AudioSource>().Play();

        if (lives < 1)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject.GetComponent<AudioSource>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            score++;
            gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Shield")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Shield());
        }
    }

    IEnumerator Shield()
    {
        shieldActive = true; gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(4);
        gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1); //Dumb time.
        shieldActive = false;
    }

}
