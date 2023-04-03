using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameManager gameManager;
    private float minUpSpeed = 10;
    private float maxUpSpeed = 16;
    private float minLeftSpeed = 32;
    private float maxLeftSpeed = 38;
    private float maxTorque = 50;
    private float leftBound = -300;
    public float forcemultiplier;
    public List<AudioClip> DeadAudio; // list of audio clips to choose from for hogrider dying
    public int numCollisions = 0;
    public bool hogD = false;
    public int yeeyee = 0;
    public int Dhog;
    public bool alive = true;

    private Animator animator;
    public List<ParticleSystem> particleSystems;
    public ParticleSystem particle;
    private AudioSource audioSource; // audio source component
    private PlayerController playerController;
    public GameObject player;
    public float znum;
    public float xspeed = 0.2f;
    public float zspeed = 0.5f;
    public bool isCoroutineRunning = false;
  

    // Start is called before the first frame update
    void Start()
    {
        
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        //transform.position = SpawnPosition();
        animator = GetComponent<Animator>();
        animator.SetBool("gallop", true);
        alive = true;
  
        particle.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy enemy when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        Vector3 direction = (new Vector3(0f, 0f, 0f) - transform.position).normalized;
        if(isCoroutineRunning && gameManager.gameActive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - znum/2.5f);
        }
        znum += direction.z * zspeed * Time.deltaTime;
        if (gameManager.gameActive && alive && !isCoroutineRunning)
        {
            if ((transform.position.z < -20 || transform.position.z > 30) && transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + znum);
            }
            else if ((transform.position.z < 10f && transform.position.z > -1f) && transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - znum);
            }
            else
            {
                if (transform.position.x > 60  && (transform.position.z > 8.25 || transform.position.z < -1f))
                {
                    if (transform.position.x < 80)
                    {
                        transform.position = new Vector3(transform.position.x + xspeed / 2.5f, transform.position.y, transform.position.z + znum / 2.5f);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + znum/2.5f);
                    }
                }
                else if (transform.position.x < 60 && (transform.position.z > 8.25 || transform.position.z < -1f))
                {
                    transform.position = new Vector3(transform.position.x + xspeed, transform.position.y, transform.position.z);
                }
                else
                {
                    if (!isCoroutineRunning && transform.position.x < 60 && (transform.position.z >= 8.5 || transform.position.z <= -0.5f)) 
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + znum/ 2.5f);
                    }
                }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dead") && hogD)
        {
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            if (yeeyee == 1)
            {
                PlayRandomDeadAudio();
                gameManager.hogdeaths++;
            }
            
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * 1000f, ForceMode.Impulse);
            numCollisions++;
            Debug.Log("Hit" + (int)numCollisions);
            hogD = true;
            gameObject.tag = "Untagged";
            animator.SetBool("gallop", false);
            PlayRandomParticle();
            alive = false;
            
        }
        
        
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().isOnDead = true;
        }
        
        if (collision.gameObject.CompareTag("dead") && (hogD))
        {
            yeeyee++;
            Dhog++;
        }
        



    
        //Vector3 SpawnPosition()
        //{

        //     Vector3 spawnPosition = new Vector3(player.transform.position.x + 50, 8, Random.Range(1.2f, 6.2f));
        //    return spawnPosition;

        // }
        void PlayRandomDeadAudio()
        {
            int randomIndex = Random.Range(0, DeadAudio.Count); // choose a random index within the list
            audioSource.clip = DeadAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
            audioSource.Play(); // play the audio
        }
        void PlayRandomParticle()
        {
            int randomIndex = Random.Range(0, particleSystems.Count);
            particle = particleSystems[randomIndex];
            particle.Play();
        }

    }
    
    IEnumerator Reattack() 
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(1f);
        isCoroutineRunning = false;
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}