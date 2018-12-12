using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeStore : MonoBehaviour {
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
            if (player.GetComponentInChildren<PlayerShooting>().hasGrenade == false)
            {
                if (ScoreManager.score >= 300)
                {
                    text.text = "Press E To Buy Grenade\nCost: 300 Points";
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        player.GetComponentInChildren<PlayerShooting>().hasGrenade = true;
                        ScoreManager.score -= 300;
                    }
                }
                else
                {
                    text.text = "Not Enough Points!!!\nCost: 300 Points";
                }
            }
            else
            {
                text.text = "Only 1 Grenade Allowed";
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