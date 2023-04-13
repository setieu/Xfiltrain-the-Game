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
   
    public List<AudioClip> LaunchAudio; // list of audio clips to choose from for launch
    public bool launchS = false;
    
    public bool boomed = false;
    public Explosion explosions;
    public BossSounds bossSounds;

    private PauseScreen pauseScreen;
    private bool spawnPosPositive;
    private GameObject particleS;
    // Start is called before the first frame update
    void Start()
    {
        particleS = GameObject.FindGameObjectWithTag("Particles");
        Vector3 direction = (new Vector3(0f, 0f, 0f) - transform.position).normalized;
        if (direction.z > 0)
        {
            spawnPosPositive = true;
        }else if (direction.z < 0)
        {
            spawnPosPositive = false;
        }
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pauseScreen = GameObject.Find("Canvas").GetComponent<PauseScreen>();
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        explosions = GameObject.Find("FX_Explosion_Rubble").GetComponent<Explosion>();
        particle.Play();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        bossSounds = GameObject.Find("Boss").GetComponent<BossSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseScreen.isPaused == false)
        {
            if (spawnPosPositive)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            } else if (!spawnPosPositive)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }
            
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime); // rotates the object around the x-axis
        }


            if(transform.position.z > 50 || transform.position.z < -50)
            {
                Destroy(gameObject);
            }

        if (launchS == false)
        {
            PlayRandomLaunchAudio();
            launchS = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == player)
            {

                playerController.particle.Play();
                player.transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z + speed * 250);
                explosions.audioSource.volume = 1f;
                PlayRandomBoomAudio();
                Destroy(gameObject);
                playerController.isOnDead = true;
                boomed = true;
                audioSource.Stop();
            }
        else if (collision.gameObject.CompareTag("Projectile"))
            {
                particleS.transform.position = transform.position;
                Particles particles = GameObject.FindGameObjectWithTag("Particles").GetComponent<Particles>();
                particles.PlayRandomParticle();
                Destroy(gameObject);
                Destroy(collision.gameObject);
                explosions.audioSource.volume = 0.3f;
                PlayRandomBoomAudio();
        }        
    }

    void PlayRandomLaunchAudio()
    {
        int randomIndex = Random.Range(0, LaunchAudio.Count); // choose a random index within the list
        audioSource.clip = LaunchAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    public void PlayRandomBoomAudio()
    {
        int randomIndex = Random.Range(0, explosions.BoomAudio.Count); // choose a random index within the list
        explosions.audioSource.clip = explosions.BoomAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        explosions.audioSource.Play(); // play the audio
    }
}

