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

    private AudioSource audioSource; // audio source component
    private PlayerController playerController;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        //transform.position = SpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy enemy when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
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
        if (collision.gameObject.CompareTag("dead"))
        {
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            PlayRandomDeadAudio();
        }
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
}
