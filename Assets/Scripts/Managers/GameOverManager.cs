using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject gameOverText;
    Animator anim;
    private float timer = 0;
    private GameObject[] spawns;

    public GameObject slomoPrefab, sniperPrefab, minigunPrefab;
    private bool waves;
    private int maxEnemies = 20;
    public static bool play = true;
    private float downTimer = 0;
    public static int waveNumber = 1, enemiesLeft = 20;

    void Awake()
    {
        waves = MainMenuController.waves;

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
        if(waves)
        {
            if(EnemyManager.enemiesSpawned < maxEnemies)
            {
                play = true;
            }
            else
            {
                play = false;
                if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
                {
                    downTimer += Time.deltaTime;
                    if(downTimer >= 5)
                    {
                        play = true;
                        EnemyManager.enemiesSpawned = 0;
                        maxEnemies = (int) (maxEnemies * 1.75f);
                        enemiesLeft = maxEnemies;
                        downTimer = 0;
                    }
                }
            }
        }

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
