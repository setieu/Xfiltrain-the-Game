using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject player;
    public AudioSource audioSource;
    public List<AudioClip> BoomAudio; // list of audio clips to choose from for launch

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isOnDead == false)
        {
            transform.position = player.transform.position;
        }
    }
   

    

}
