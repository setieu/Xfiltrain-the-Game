using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossman : MonoBehaviour
{
    public int numCollisions = 0;
    private float minUpSpeed = 2;
    private float maxUpSpeed = 3;
    private float minLeftSpeed = 2;
    private float maxLeftSpeed = 3;
    private float maxTorque = 1;
    public float forcemultiplier = 20f;
    public bool bossD = false;
    private float health = 50;
    public bool klum = false;
    public int joe = 0;
    private GameManager gameManager;
    public GameObject rocket;
    private float spawnInterval = 2f;

    private Rigidbody enemyRb;
    public List<AudioClip> DeadAudio; // list of audio clips to choose from for hogrider dying
    private AudioSource audioSource; // audio source component
    private BoxCollider boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
        enemyRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bossD = false;
        numCollisions = 0;
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numCollisions);
        if(gameManager.gameActive)
        {
            transform.position = new Vector3(gameManager.playerR.transform.position.x, transform.position.y, transform.position.z);
        }
        
        //instantiate object in front of this one every few secondeese
        if (numCollisions > health)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (bossD == false)
                {
                    rb.AddForce(Vector3.up * 2500f, ForceMode.Impulse);
                }
            
            gameObject.tag = "Enemy";
            bossD = true;
        }

        if (klum)
        {
             enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
             enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
             enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
             enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
             joe++ ;
             if (joe == 1)
                {
                    PlayRandomDeadAudio();
                }
             gameObject.SetActive(false);
             Debug.Log("Boss Killed");
        }


    }
    void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                numCollisions++;
                Debug.Log("Hit" + (int)numCollisions);
            }
            if (collision.gameObject.CompareTag("dead") && (bossD))
            {
                klum = true;
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

    void PlayRandomDeadAudio()
    {
        int randomIndex = Random.Range(0, DeadAudio.Count); // choose a random index within the list
        audioSource.clip = DeadAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(0.01f);
        while (true)
        {
            // Calculate the position in front of the boss
            Vector3 spawnPosition = transform.position + transform.forward * 8f;

            rocket.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            
            // Instantiate the object at the spawn position
            Instantiate(rocket, spawnPosition, rocket.transform.rotation);
            
            // Wait for the next spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

