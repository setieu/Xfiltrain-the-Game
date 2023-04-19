using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackOnCollision : MonoBehaviour
{
    private float minUpSpeed = 10;
    private float maxUpSpeed = 16;
    private float minLeftSpeed = 32;
    private float maxLeftSpeed = 38;
    private float maxTorque = 1500;
    private float leftBound = -100;
    public float forcemultiplier;
    public float speed = 100f;
    public int detachD = 0;
    public int HPP = 100;
    private Rigidbody rb;
    private HealthBar healthBar;
    private HealthBar healthText;
    private AudioSource audioSource; // audio source component
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    public List<AudioClip> Smacking; // list of audio clips to choose from for Detachment
    public List<AudioClip> Crash; // list of audio clips to choose from for Detachment

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Bar").GetComponent<HealthBar>();
        //healthText = GameObject.Find("HPText").GetComponent<HealthBar>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //HPP = healthBar.HP;
        //healthText = ;
        if (healthBar.HP <= 0)
        {
            StartCoroutine(MoveBack());
        }
        if (detachD == 1)
        {
            PlayRandomDetachmentAudio();
        }
        //Destroy flatcar when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            detachD++;
            PlayRandomSmackingAudio();
            healthBar.HP--;
            // Get a reference to the Enemy script on the other game object
            Enemy enemyS = other.gameObject.GetComponent<Enemy>();
            enemyS.StartCoroutine("Reattack");
            enemyS.isCoroutineRunning = true;
        }

        if (other.gameObject.CompareTag("Rogue"))
        {
            gameObject.AddComponent<Rigidbody>().mass = 1;
            rb = gameObject.GetComponent<Rigidbody>();
            Debug.Log("rogue");
            PlayRandomCrashAudio();
            
            rb.AddForce(Vector3.up * 1050f, ForceMode.Impulse);
            rb.AddForce(Vector3.left * 1050f, ForceMode.Impulse);
            //rb.AddForce(Vector3.forward * 350f, ForceMode.Impulse);
            //transform.Rotate(Vector3.right * Time.deltaTime * 30f);
            rb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            rb.AddForce(Vector3.up * 1050f, ForceMode.Impulse);
            //rb.AddForce(Vector3.left * 50f, ForceMode.Impulse);
            rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            //yield return new WaitForSeconds(3f); FIX THIS

            //StartCoroutine(MoveBack());
        }

    }
    
    IEnumerator MoveBack()
    {
        while (true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.01f); // add a delay between each movement
        }
    }

    void PlayRandomDetachmentAudio()
    {
        int randomIndex = Random.Range(0, DetachmentAudio.Count); // choose a random index within the list
        audioSource.clip = DetachmentAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomSmackingAudio()
    {
        int randomIndex = Random.Range(0, Smacking.Count); // choose a random index within the list
        audioSource.clip = Smacking[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomCrashAudio()
    {
        int randomIndex = Random.Range(0, Crash.Count); // choose a random index within the list
        audioSource.clip = Crash[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
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
}


