using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : MonoBehaviour {

    private float timer = 20;

    void Update()
    {
        this.transform.Rotate(new Vector3(0, 1, 0));

        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;

            if (player.GetComponentInChildren<PlayerShooting>().minigun == false && player.GetComponentInChildren<PlayerShooting>().sniper == false && player.GetComponentInChildren<PlayerShooting>().slomo == false)
            {
                player.GetComponentInChildren<PlayerShooting>().ResetTimers();
                player.GetComponentInChildren<PlayerShooting>().sniper = true;

                Destroy(this.gameObject);
            }
        }
    }
}