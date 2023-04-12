using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetX = new Vector3(-8, 16, 0);
    private Vector3 offsettwo = new Vector3(-12, 20, 0);
    private PlayerController playerController;
    public float rotationSpeed = 2500;
    public int isFlipped = 1; // Flag to check if object is already flipped
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip lagtrain;
    public AudioClip gsc;
    public AudioClip pillyman;
    public AudioClip chill;
    public AudioClip journey;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = journey;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = 1f;
        gameManager.modeeE = 7;

    }
     void Update()
    {
        if (gameManager.modeeE == 0)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = chill;
            audioSource.Play();
        }
        if (gameManager.modeeE == 1)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = lagtrain;
            audioSource.Play();
        }
        if (gameManager.modeeE == 2)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = lagtrain;
            audioSource.Play();
        }
        if (gameManager.modeeE == 3)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = lagtrain;
            audioSource.Play();
        }
        if (gameManager.modeeE == 4)
        {
            audioSource.Pause();
            audioSource.clip = gsc;
            audioSource.Play();
            //Debug.Log("secondaudio");
        }
        if(gameManager.modeeE == 5)
        {
            audioSource.volume = .4f;
            audioSource.Pause();
            audioSource.clip = pillyman;
            audioSource.Play();
        }
        if (gameManager.modeeE == 7)
        {
            audioSource.volume = 1.0f;
            audioSource.Pause();
            audioSource.clip = journey;
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

        // Camera Offset
        //if (playerController.isAlive == true)
        {
            if(gameManager.modeeE != 5)
            {
                if (gameManager.gameActive)
                {
                    if (playerController.isOnDead == false)
                    {
                        transform.position = player.transform.position + offsetX;
                    }
                }
                else
                {
                    transform.position = transform.position;
                }
            }
            else if(gameManager.modeeE == 5)
            {
                if (gameManager.gameActive)
                {
                    if (playerController.isOnDead == false)
                    {
                        transform.position = player.transform.position + offsettwo;
                    }
                }
                else
                {
                    transform.position = transform.position;
                }
            }



            // Rotate the camera clockwise about the y-axis while 'z' key is pressed
            if(gameManager.modeeE != 5)
            {
                if (gameManager.gameActive == true)
                {
                    if (Input.GetKeyDown(KeyCode.Z) && isFlipped == 1) // Check if the 'z' key is pressed
                    {
                        // Flip the object 180 degrees about the y-axis
                        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y + 180f, 0f);
                        offsetX = new Vector3(8, 16, 0);
                        // Update the flag to reflect the current state of the object
                        isFlipped = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.X) && isFlipped == 2) // Check if the 'z' key is pressed
                    {
                        // Flip the object 180 degrees about the y-axis
                        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y + 180f, 0f);
                        offsetX = new Vector3(-8, 16, 0);
                        // Update the flag to reflect the current state of the object
                        isFlipped = 1;
                    }
                }
            }
            else if(gameManager.modeeE == 5)
            {
                if (gameManager.gameActive == true)
                {
                    if (Input.GetKeyDown(KeyCode.Z) && isFlipped == 1) // Check if the 'z' key is pressed
                    {
                        // Flip the object 180 degrees about the y-axis
                        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y + 180f, 0f);
                        offsettwo = new Vector3(12, 20, 0);
                        // Update the flag to reflect the current state of the object
                        isFlipped = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.X) && isFlipped == 2) // Check if the 'z' key is pressed
                    {
                        // Flip the object 180 degrees about the y-axis
                        transform.rotation = Quaternion.Euler(50f, transform.rotation.eulerAngles.y + 180f, 0f);
                        offsettwo = new Vector3(-12, 20, 0);
                        // Update the flag to reflect the current state of the object
                        isFlipped = 1;
                    }
                }
            }


        }


    }
}


