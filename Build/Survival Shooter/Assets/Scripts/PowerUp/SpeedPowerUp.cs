using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public GameObject player;
    public float speedPower = 2f;
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
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
        playerMovement.SpeedPowerUp(speedPower);
    }
}
