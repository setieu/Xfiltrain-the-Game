using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour

{

    public float rotationSpeed = 30.0f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerController.isAlive == true)
        {
            transform.Rotate(Vector3.right * rotationSpeed);
        }
    }//ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
}
