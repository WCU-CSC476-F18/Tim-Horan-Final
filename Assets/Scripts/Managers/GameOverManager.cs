using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject gameOverText;
    Animator anim;
    private float timer = 0;
    private GameObject[] spawns;

    public GameObject slomoPrefab, sniperPrefab, minigunPrefab;

    void Awake()
    {
        anim = GetComponent<Animator>();

        spawns = GameObject.FindGameObjectsWithTag("Powerup");
        int loc = Random.Range(0, spawns.Length);
        int type = Random.Range(1, 4);
        if (type == 1)
        {
            GameObject newPowerup = Instantiate(slomoPrefab);
            newPowerup.transform.position = spawns[loc].transform.position;
        }
        else if (type == 2)
        {
            GameObject newPowerup = Instantiate(sniperPrefab);
            newPowerup.transform.position = spawns[loc].transform.position;
        }
        else
        {
            GameObject newPowerup = Instantiate(minigunPrefab);
            newPowerup.transform.position = spawns[loc].transform.position;
        }
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            gameOverText.SetActive(true);
            anim.SetTrigger("GameOver");
        }
        else
        {
            gameOverText.SetActive(false);

            timer += Time.deltaTime;
            if(timer >= 15)
            {
                timer = 0;
                int loc = Random.Range(0, spawns.Length);
                int type = Random.Range(1, 4);
                if(type == 1)
                {
                    GameObject newPowerup = Instantiate(slomoPrefab);
                    newPowerup.transform.position = spawns[loc].transform.position;
                }
                else if(type == 2)
                {
                    GameObject newPowerup = Instantiate(sniperPrefab);
                    newPowerup.transform.position = spawns[loc].transform.position;
                }
                else
                {
                    GameObject newPowerup = Instantiate(minigunPrefab);
                    newPowerup.transform.position = spawns[loc].transform.position;
                }
            }
        }
    }
}
