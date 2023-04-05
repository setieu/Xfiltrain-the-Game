using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 25f;
    public float max = 80f; // the boundary at which the movement direction should change
    public float min = 31f;

    private bool movingRight = true; // the initial direction of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // move the object horizontally based on the current direction of movement
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // check if the object has reached the boundary, and change the direction of movement if necessary
        if (transform.position.x >= max && movingRight)
        {
            movingRight = false;
        }
        else if (transform.position.x <= min && !movingRight)
        {
            movingRight = true;
        }
    }
}
