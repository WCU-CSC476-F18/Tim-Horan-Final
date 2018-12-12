using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlomoPickup : MonoBehaviour {

    private float timer = 10;
    public Light bgLight;

    void Update()
    {
        this.transform.Rotate(new Vector3(0, 1, 0));

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer >= 5)
            LightOn();
        else if (timer >= 4)
            LightOff();
        else if (timer >= 3.5)
            LightOn();
        else if (timer >= 3)
            LightOff();
        else if (timer >= 2.5)
            LightOn();
        else if (timer >= 2)
            LightOff();
        else if (timer >= 1.75)
            LightOn();
        else if (timer >= 1.5)
            LightOff();
        else if (timer >= 1.25)
            LightOn();
        else if (timer >= 1)
            LightOff();
        else if (timer >= .9)
            LightOn();
        else if (timer >= .8)
            LightOff();
        else if (timer >= .7)
            LightOn();
        else if (timer >= .6)
            LightOff();
        else if (timer >= .5)
            LightOn();
        else if (timer >= .4)
            LightOff();
        else if (timer >= .3)
            LightOn();
        else if (timer >= .2)
            LightOff();
        else if (timer >= .1)
            LightOn();
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void LightOn()
    {
        bgLight.enabled = true;
    }

    private void LightOff()
    {
        bgLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;

            if (player.GetComponentInChildren<PlayerShooting>().minigun == false && player.GetComponentInChildren<PlayerShooting>().sniper == false && player.GetComponentInChildren<PlayerShooting>().slomo == false)
            {
                player.GetComponentInChildren<PlayerShooting>().ResetTimers();
                player.GetComponentInChildren<PlayerShooting>().slomo = true;

                Destroy(this.gameObject);
            }
        }
    }
}