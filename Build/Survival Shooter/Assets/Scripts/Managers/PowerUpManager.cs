using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;

    public GameObject heal;
    public GameObject speed;
    public float spawnTime = 30f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnType = Random.Range(0, 2);

        if (spawnType == 0 && !speed.activeSelf)
        {
            speed.SetActive(true);
        }
        else if (spawnType == 1 && !heal.activeSelf)
        {
            heal.SetActive(true);
        }

    }
}
