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
    public float forcemultiplier;
    public bool bossD = false;
    public float health = 3;
    public bool kum = false;


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

        if (kum)
        {
             enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
             enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
             enemyRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
             enemyRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
             PlayRandomDeadAudio();
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
                kum = true;
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

