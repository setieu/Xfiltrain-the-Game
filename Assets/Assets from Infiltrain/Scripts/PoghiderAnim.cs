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
            // calculate the direction towards the target point
            Vector3 direction = targetPoint - transform.position;

            // calculate the distance towards the target point
            float distance = direction.magnitude;

            // check if the object has reached the target point
            if (distance < 0.01f)
            {
                return; // exit the update method if we've reached the target point
            }

            // normalize the direction towards the target point
            direction /= distance;

            // calculate the amount to move towards the target point
            float amountToMove = Mathf.Min(speed * Time.deltaTime, distance);

            // move towards the target point
            transform.position += direction * amountToMove;
        }
    }
}