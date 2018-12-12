using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    public int damage = 100;
    public float detonationTime = 0;
    public Light bgLight;
    public GameObject explosionPrefab, explosion;

    public List<GameObject> AoE;

	// Update is called once per frame
	void Update () {
        detonationTime += Time.deltaTime;

        if (detonationTime >= 3)
            Explode();
        else if (detonationTime >= 2.9)
            LightOn();
        else if (detonationTime >= 2.8)
            LightOff();
        else if (detonationTime >= 2.7)
            LightOn();
        else if (detonationTime >= 2.6)
            LightOff();
        else if (detonationTime >= 2.5)
            LightOn();
        else if (detonationTime >= 2.4)
            LightOff();
        else if (detonationTime >= 2.2)
            LightOn();
        else if (detonationTime >= 2)
            LightOff();
        else if (detonationTime >= 1.75)
            LightOn();
        else if (detonationTime >= 1.5)
            LightOff();
        else if (detonationTime >= 1.25)
            LightOn();
        else if (detonationTime >= 1)
            LightOff();
        else 
            LightOn();
    }

    private void LightOn()
    {
        bgLight.enabled = true;
    }

    private void LightOff()
    {
        bgLight.enabled = false;
    }

    private void Explode()
    {
        explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        foreach (GameObject go in AoE)
        {
            go.GetComponent<EnemyHealth>().TakeDamage(damage, go.transform.position);
        }
        Invoke("KillExplosion", 1);
        Destroy(this.gameObject);
    }

    private void KillExplosion()
    {
        Destroy(explosion.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            AoE.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
            AoE.Remove(other.gameObject);
    }
}