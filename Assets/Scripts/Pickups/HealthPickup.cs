using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour {
    Text text;
	// Use this for initialization
	void Start () {
        text = GameObject.Find("PickupHealthText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(0, 1, 0));
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            if (player.GetComponent<PlayerHealth>().currentHealth < 100)
            {
                if (ScoreManager.points >= 100)
                {
                    player.GetComponent<PlayerHealth>().Heal();
                    ScoreManager.points -= 100;
                }
                else
                {
                    text.text = "Not Enough Points!!!\nCost: 100 Points";
                }
            }
            else
            {
                text.text = "Already At Full Health\nCost: 100 Points";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "";
        }
    }
}