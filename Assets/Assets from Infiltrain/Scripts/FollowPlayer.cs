using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offsetX = new Vector3(15, 6, -20);
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Camera Offset
        //if (playerController.isAlive == true)
        {
            if(playerController.isOnDead == false)
            {
                transform.position = player.transform.position + offsetX;
            }
        }
        
    }
}
