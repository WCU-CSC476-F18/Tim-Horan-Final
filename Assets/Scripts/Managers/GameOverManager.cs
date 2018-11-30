using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject gameOverText;
    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
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
        }
    }
}
