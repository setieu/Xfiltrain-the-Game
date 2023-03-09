using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoghiderAnim : MonoBehaviour
{
    public float speed = 1f; // adjust this to change the speed of the animation
    public float height = 1f; // adjust this to change the height of the animation
    public float xspeed = 0.1f;
    public Vector3 targetPoint; // specify the point to move towards

    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startingPosition.y + height * Mathf.Sin(Time.time * speed);
        float newZ = startingPosition.z;

        if (transform.position.x < -30)
        {
            transform.position = new Vector3(transform.position.x + xspeed, newY, transform.position.z);
        }
        else
        {

        }
    }
}