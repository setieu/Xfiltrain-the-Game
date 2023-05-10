using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeeter : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float force = 10f;
    public bool lockXRotation = true;
    public bool lockYRotation = false;
    public bool lockZRotation = true;
    public Vector3 spawnOffset = new Vector3(0, 0, 1);
    public float lastSpawnTime = 0f;
    public float throwCD = 1.5f;
    private GameManager gameManager;
    private Quaternion initialRotation;
    private Animation animations;
    public bool canSpawn = true;
    public Animator animator;
    public List<AudioClip> ThrowAudio; // list of audio clips to choose from for Throw
    private AudioSource audioSource; // audio source component


    private void Start()
    {
        initialRotation = transform.rotation;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if(gameManager.gameActive)
        {
            // Get the mouse position in world space
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y - transform.position.y));

            // Calculate the direction the player needs to face
            Vector3 direction = (mousePos - transform.position).normalized;

            // Set the player's rotation to face the mouse cursor, while preserving the initial x and z rotations
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            float xRotation = lockXRotation ? initialRotation.eulerAngles.x : targetRotation.eulerAngles.x;
            float yRotation = lockYRotation ? initialRotation.eulerAngles.y : targetRotation.eulerAngles.y;
            float zRotation = lockZRotation ? initialRotation.eulerAngles.z : targetRotation.eulerAngles.z;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if(gameManager.modeeE == 9)
                {
                    if (Time.time - lastSpawnTime >= throwCD)
                    {
                        if (canSpawn)
                        {
                            animator.SetBool("throw", true);
                            StartCoroutine(SpawnObjectWithDelay(0f));
                            canSpawn = false;
                            PlayRandomThrowAudio();
                        }
                        // Update the last spawn time
                        lastSpawnTime = Time.time;
                    }
                }
                else if (gameManager.modeeE == 4)
                {
                    if (Time.time - lastSpawnTime >= throwCD)
                    {
                        if (canSpawn)
                        {
                            animator.SetBool("throw", true);
                            StartCoroutine(SpawnObjectWithDelay(0.2f));
                            canSpawn = false;
                            PlayRandomThrowAudio();
                        }
                        // Update the last spawn time
                        lastSpawnTime = Time.time;
                    }
                }
                else if (Time.time - lastSpawnTime >= throwCD)
                {
                    if (canSpawn)
                    {
                        animator.SetBool("throw", true);
                        StartCoroutine(SpawnObjectWithDelay(.25f));
                        canSpawn = false;
                        PlayRandomThrowAudio();
                    }
                    // Update the last spawn time
                    lastSpawnTime = Time.time;
                }
            }

        }

        IEnumerator SpawnObjectWithDelay(float delay)
        {
            // Wait for the specified delay before spawning the object
            yield return new WaitForSeconds(delay);



            // Choose a random object to spawn from the array
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject selectedObject = objectsToSpawn[randomIndex];

            // Instantiate the object and add force in the forward direction
            Vector3 spawnPos = transform.position + transform.rotation * spawnOffset;
            GameObject spawnedObject = Instantiate(selectedObject, spawnPos, Quaternion.identity);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * force, ForceMode.Impulse);


            animator.SetBool("throw", false);
            canSpawn = true;
        }

    }
    void PlayRandomThrowAudio()
    {
        int randomIndex = Random.Range(0, ThrowAudio.Count); // choose a random index within the list
        audioSource.clip = ThrowAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
}
