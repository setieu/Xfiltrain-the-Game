using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosion : MonoBehaviour
{
    public bool boom = false;
    public AudioSource audioSource;
    public List<AudioClip> BoomAudio; // list of audio clips to choose from for launch
    public ParticleSystem particle;
  
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {




    }
}
