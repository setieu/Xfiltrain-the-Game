using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    private GameObject Boss;
    public Bossman bossman;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        Boss = GameObject.Find("Ridehogger 1 1");
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss != null)
        {
            transform.position = Boss.transform.position;
        }
    }
    public void PlayRandomDeadAudio()
    {
        int randomIndex = Random.Range(0, bossman.DeadAudio.Count); // choose a random index within the list
        audioSource.clip = bossman.DeadAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
}
