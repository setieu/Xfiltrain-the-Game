using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;
    private float speed = 0.15f;
    public ParticleSystem particle;
    private float rotationSpeed = 360f; // adjust this to change the speed of rotation
    public GameObject player;
    public AudioClip explosion;
    public AudioSource audioSource;
    public AudioSource audioSource1;
    public List<AudioClip> LaunchAudio; // list of audio clips to choose from for launch
    public bool launchS = false;
    public List<AudioClip> BoomAudio; // list of audio clips to choose from for launch
    public bool boomed = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        particle.Play();
        audioSource = GetComponent<AudioSource>();
        audioSource1 = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        Quaternion rotation = Quaternion.Euler(0f, -90f, 0f) ;
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime); // rotates the object around the x-axis

        if (gameManager.gameActive)
        {
            if(transform.position.z > 50)
            {
                Destroy(gameObject);
            }
        }
        if (launchS == false)
        {
            PlayRandomLaunchAudio();
            launchS = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
     
        if(playerController.isOnDead == false)
        {
            if (collision.gameObject == player)
            {

                playerController.particle.Play();
                player.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z + speed * 250);
                PlayRandomBoomAudio();
                Destroy(gameObject);
                playerController.isOnDead = true;
                boomed = true;

            }
            else if (collision.gameObject.CompareTag("Projectile"))
            {
                Destroy(gameObject);
            }
        }
        
        
    }

    void PlayRandomLaunchAudio()
    {
        int randomIndex = Random.Range(0, LaunchAudio.Count); // choose a random index within the list
        audioSource.clip = LaunchAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomBoomAudio()
    {
        int randomIndex = Random.Range(0, BoomAudio.Count); // choose a random index within the list
        audioSource1.clip = BoomAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource1.Play(); // play the audio
    }

}

