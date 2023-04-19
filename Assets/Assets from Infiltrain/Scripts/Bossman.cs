using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Bossman : MonoBehaviour
{
    private Image healthBar;
    public TextMeshProUGUI healthtext;
    public float healthnumtext;


    public int numCollisions = 0;
    private float minUpSpeed = 2;
    private float maxUpSpeed = 3;
    private float minLeftSpeed = 2;
    private float maxLeftSpeed = 3;
    private float maxTorque = 1;
    public float forcemultiplier = 20f;
    public bool bossD = false;
    public float health;
    public bool klum = false;
    public int joe = 0;
    private GameManager gameManager;
    public GameObject rocket;
    private float spawnInterval = 2f;
    private bool firstRocket = true;
    private bool spawnPosPositive;

    private Rigidbody enemyRb;
    public List<AudioClip> DeadAudio; // list of audio clips to choose from for hogrider dying
    private AudioSource audioSource; // audio source component
    private BoxCollider boxCollider;
    private BossSounds bossSounds;
    public List<ParticleSystem> particleSystems;
    public ParticleSystem particle;

    public GameObject explosion;
    public BossExplosion bossExplosion;

    public float bosShp;
    // Start is called before the first frame update
    void Start()
    {

        explosion = GameObject.Find("BossExplosion");
        if(explosion != null)
        {
            bossExplosion = GameObject.Find("BossExplosion").GetComponent<BossExplosion>();
        }
        bossExplosion.audioSource.Stop();
        bossExplosion.particle.Stop();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        enemyRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bossD = false;
        numCollisions = 0;
        
        StartCoroutine(SpawnObject());
        bossSounds = GameObject.Find("Boss").GetComponent<BossSounds>();

        Vector3 direction = (new Vector3(0f, 0f, 0f) - transform.position).normalized;
        if (direction.z > 0)
        {
            spawnPosPositive = true;
        }
        else if (direction.z < 0)
        {
            spawnPosPositive = false;
        }
        health = 70;
    }

    // Update is called once per frame
    void Update()
    {
        bosShp = health - numCollisions;
        //Debug.Log(numCollisions);
        if(gameManager.gameActive)
        {
            transform.position = new Vector3(gameManager.playerR.transform.position.x, transform.position.y, transform.position.z);
        }
        
        //instantiate object in front of this one every few secondeese
        if (numCollisions >= health)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (bossD == false && rb != null)
                {
                    rb.AddForce(Vector3.up * 2500f, ForceMode.Impulse);
                }
            
            gameObject.tag = "Enemy";
            bossD = true;
            klum = true;
            bossSounds.audioSource.Play();
            gameManager.bossdeaths++;
            explosion.transform.position = transform.position;
            bossExplosion.audioSource.Play();
            bossExplosion.particle.Play();
            gameObject.SetActive(false);
        }


        if (klum)
        {
            if(enemyRb != null)
            {
                enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
                enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
                enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
                joe++;
                if (joe == 1)
                {
                    bossSounds.audioSource.Play();

                }
 
                gameObject.SetActive(false);
                Debug.Log("Boss Killed");
            }
             
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if(gameManager.gameActive)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                numCollisions++;
                PlayRandomParticle();
                Debug.Log("Hit" + (int)numCollisions);
            }
            if (collision.gameObject.CompareTag("dead") && (bossD))
            {
                klum = true;
            }
        }

    }
   



    Vector3 RandomLeftForce()
    {
        return Vector3.left * Random.Range(minLeftSpeed, maxLeftSpeed) * forcemultiplier;
    }
    Vector3 RandomUpForce()
    {
        return Vector3.up * Random.Range(minUpSpeed, maxUpSpeed) * forcemultiplier;
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque) * forcemultiplier;
    }

    
    IEnumerator SpawnObject()
    {
        
        if(firstRocket)
        {
            yield return new WaitForSeconds(1f);
            while (true)
            {
                // Calculate the position in front of the boss
                Vector3 spawnPosition = transform.position + transform.forward * 8f;
                if (spawnPosPositive)
                {
                    rocket.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                }else if (!spawnPosPositive)
                {
                    rocket.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                }
                

                // Instantiate the object at the spawn position
                if(gameManager.gameActive)
                {
                    Instantiate(rocket, spawnPosition, rocket.transform.rotation);
                }


                // Wait for the next spawn interval
                spawnInterval = Random.Range(0.15f, 3f);
                yield return new WaitForSeconds(spawnInterval);
                firstRocket = false;
            }

        }
        else
        {
            yield return new WaitForSeconds(0.01f);
            while (true)
            {
                // Calculate the position in front of the boss
                Vector3 spawnPosition = transform.position + transform.forward * 8f;
                if (spawnPosPositive)
                {
                    rocket.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                }
                else if (!spawnPosPositive)
                {
                    rocket.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                }

                rocket.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

                // Instantiate the object at the spawn position
                if (gameManager.gameActive)
                {
                    Instantiate(rocket, spawnPosition, rocket.transform.rotation);

                }


                // Wait for the next spawn interval
                yield return new WaitForSeconds(spawnInterval);
            }
        }

    }
    void PlayRandomParticle()
        {
            int randomIndex = Random.Range(0, particleSystems.Count);
            particle = particleSystems[randomIndex];
            particle.Play();
        }
}

