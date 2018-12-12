using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    GameObject barrel;
    private float normalSpeed = -1;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        barrel = GameObject.Find("GunBarrelEnd");
    }


    void Update ()
    {
        if(barrel.GetComponent<PlayerShooting>().slomo == true)
        {
            if(normalSpeed == -1)
                normalSpeed = nav.speed;
            nav.speed = normalSpeed / 3;
        }
        else if(normalSpeed != -1)
        {
            nav.speed = normalSpeed;
        }

        if (barrel.GetComponent<PlayerShooting>().grenadeSpawned == true)
        {
            nav.SetDestination(barrel.GetComponent<PlayerShooting>().spawnedGrenade.transform.position);
        }
        else if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}