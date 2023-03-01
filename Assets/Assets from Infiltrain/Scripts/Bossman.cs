using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossman : MonoBehaviour
{
    public int numCollisions = 0;
    private float minUpSpeed = 100;
    private float maxUpSpeed = 160;
    private float minLeftSpeed = 320;
    private float maxLeftSpeed = 380;
    private float maxTorque = 500;
    public float forcemultiplier;
    public bool bossD = false;
    public float health = 100;

    private Rigidbody enemyRb;
    public List<AudioClip> DeadAudio; // list of audio clips to choose from for hogrider dying
    private AudioSource audioSource; // audio source component


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        bossD = false;
        numCollisions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            numCollisions++;
            Debug.Log("Hit" + (int)numCollisions);
            if (numCollisions > health)
            {
                Rigidbody rb = GetComponent<Rigidbody>();               
                rb.AddForce(Vector3.up * 1000f, ForceMode.Impulse);
                gameObject.tag = "Enemy";
                bossD = true;
            }
        }
        if (collision.gameObject.CompareTag("dead") && (bossD))
        {
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            PlayRandomDeadAudio();
            Debug.Log("Boss Killed");
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
}
