using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoghiderAnim : MonoBehaviour
{
    public float speed = 1f; // adjust this to change the speed of the animation
    public float height = 1f; // adjust this to change the height of the animation
    public float xspeed = 0.2f;
    public float zspeed = 1f;
    public float znum;
    public Enemy enemy;
    
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
        
     
        if (transform.position.x < 80 && enemy.alive)
        {
            transform.position = new Vector3(transform.position.x + xspeed, newY, transform.position.z);
        }
        else
        {
            if ((transform.position.z > 15 || transform.position.z < 5) && enemy.alive)
            {
                // calculate the direction to the target point
                Vector3 direction = (new Vector3(0f, newY, 0f) - transform.position).normalized;

                // move the object towards the target point along the z-axis
                znum += direction.z * zspeed * Time.deltaTime;

                transform.position = new Vector3(80, newY, transform.position.z + znum);
            }
            else
            {
                
            }
        }

    }


}
        
    

