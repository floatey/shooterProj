using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cloudPrefab;
    public GameObject enemyOnePrefab;
    public GameObject coinPrefab;
    public GameObject shieldPrefab;
    public GameObject livesDisplay;
    public GameObject coinsDisplay;
    public GameObject gameOverScreen;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CreateSky();
        player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        InvokeRepeating("SpawnCoins", 3f, 5f);
        InvokeRepeating("SpawnShield", 15f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        int temp1 = player.GetComponent<PlayerController>().lives;
        livesDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = ("Lives: " + temp1);

        if (temp1 < 1)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(false);
        }

        int temp2 = player.GetComponent<PlayerController>().score;
        coinsDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = ("Score: " + temp2);

    }

    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8,8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void SpawnCoins()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 0), 0), Quaternion.identity);
    }

    void SpawnShield()
    {
        Instantiate(shieldPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 0), 0), Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
