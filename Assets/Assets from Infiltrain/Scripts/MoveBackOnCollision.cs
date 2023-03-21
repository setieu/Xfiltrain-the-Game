using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackOnCollision : MonoBehaviour
{
    private float leftBound = -100;
    public float speed = 100f;
    public int detachD = 0;
    public int HPP = 100;

    private HealthBar healthBar;
    private HealthBar healthText;
    private AudioSource audioSource; // audio source component
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    public List<AudioClip> Smacking; // list of audio clips to choose from for Detachment

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
            if (healthBar.HP <= 0)
                {
                    StartCoroutine(MoveBack());
                }
            
            detachD++;
            PlayRandomSmackingAudio();
            healthBar.HP--;
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
}

