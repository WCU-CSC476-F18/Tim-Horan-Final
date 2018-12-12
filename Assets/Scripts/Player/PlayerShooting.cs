using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer, minigunTimer, sniperTimer, slomoTimer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    public bool minigun = false, sniper = false, slomo = false, hasGrenade = true, grenadeSpawned = false;

    public GameObject sniperText, minigunText, slomoText, grenadePrefab, spawnedGrenade;
    public Slider sniperSlider, minigunSlider, slomoSlider;

    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if (minigun)
            Minigun();
        else if (sniper)
            Sniper();
        else if (slomo)
            Slomo();

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(Input.GetButton("Fire2") && hasGrenade)
        {
            ThrowGrenade();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }

    private void ThrowGrenade()
    {
        hasGrenade = false;
        spawnedGrenade = Instantiate(grenadePrefab);
        spawnedGrenade.transform.position = transform.position;
        spawnedGrenade.transform.rotation = transform.rotation;
        spawnedGrenade.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        grenadeSpawned = true;
        Invoke("FocusPlayer", 3);
    }

    private void FocusPlayer()
    {
        grenadeSpawned = false;
    }

    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    private void Slomo()
    {
        if (slomoTimer >= 0)
        {
            slomoText.SetActive(true);
            slomoTimer -= Time.deltaTime;
            slomoSlider.value = slomoTimer;
        }
        else
        {
            slomoText.SetActive(false);
            slomo = false;
        }
    }

    public void ResetTimers()
    {
        minigunTimer = 10f;
        sniperTimer = 10f;
        slomoTimer = 10f;
    }

    private void Minigun()
    {
        if(minigunTimer >= 0)
        {
            minigunText.SetActive(true);
            timeBetweenBullets = 0.05f;
            minigunTimer -= Time.deltaTime;
            minigunSlider.value = minigunTimer;
        }
        else
        {
            timeBetweenBullets = 0.15f;
            minigunText.SetActive(false);
            minigun = false;
        }
    }

    private void Sniper()
    {
        if (sniperTimer >= 0)
        {
            sniperText.SetActive(true);
            timeBetweenBullets = 0.3f;
            damagePerShot = 60;
            sniperTimer -= Time.deltaTime;
            sniperSlider.value = sniperTimer;
        }
        else
        {
            timeBetweenBullets = 0.15f;
            damagePerShot = 20;
            sniperText.SetActive(false);
            sniper = false;
        }
    }

    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
