using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dingspam : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip ding;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.modeeE == 9)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = ding;
            audioSource.Play();
        }
            
    }
}
