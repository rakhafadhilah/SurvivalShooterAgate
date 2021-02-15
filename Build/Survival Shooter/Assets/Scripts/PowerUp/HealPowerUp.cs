using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            ApplyPowerUp();
            gameObject.SetActive(false);
        }
    }

    public void ApplyPowerUp()
    {
        playerHealth.HealPowerUp(30);
    }
}
