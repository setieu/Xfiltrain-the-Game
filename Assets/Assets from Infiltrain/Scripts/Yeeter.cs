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
    private float lastSpawnTime = 0f;
    private GameManager gameManager;
    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastSpawnTime >= 2f)
                {
                    // Choose a random object to spawn from the array
                    int randomIndex = Random.Range(0, objectsToSpawn.Length);
                    GameObject selectedObject = objectsToSpawn[randomIndex];

                    // Instantiate the object and add force in the forward direction
                    Vector3 spawnPos = transform.position + transform.rotation * spawnOffset;
                    GameObject spawnedObject = Instantiate(selectedObject, spawnPos, Quaternion.identity);
                    Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * force, ForceMode.Impulse);

                    // Update the last spawn time
                    lastSpawnTime = Time.time;
                }
            }

        }

    }
}
