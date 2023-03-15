using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetX = new Vector3(-8, 16, 0);
    private PlayerController playerController;
    public float rotationSpeed = 2500;
    public int isFlipped = 1; // Flag to check if object is already flipped
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Camera Offset
        //if (playerController.isAlive == true)
        {
            if (playerController.isOnDead == false)
            {
                transform.position = player.transform.position + offsetX;
            }

            // Rotate the camera clockwise about the y-axis while 'z' key is pressed
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


    }
}


