using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoghiderAnim : MonoBehaviour
{
    public float speed = 1f; // adjust this to change the speed of the animation
    public float height = 1f; // adjust this to change the height of the animation
    public float xspeed = 0.2f;
    public float zspeed = 0.5f;
    public float znum;
    public Enemy enemy;
    private GameManager gameManager;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
        float newY = startingPosition.y + height * Mathf.Sin(Time.time * speed);

        // calculate the direction to the target point
        Vector3 direction = (new Vector3(0f, newY, 0f) - transform.position).normalized;

        // move the object towards the target point along the z-axis
        znum += direction.z * zspeed * Time.deltaTime;
        if (gameManager.gameActive)
        {
            if (transform.position.z < -20 || transform.position.z > 30)
            {
                transform.position = new Vector3(transform.position.x, newY, transform.position.z + znum);
            }
            else
            {
                if (transform.position.x > 60 && enemy.alive && (transform.position.z > 9 || transform.position.z < -0.5f))
                {
                    if (transform.position.x < 80)
                    {
                        transform.position = new Vector3(transform.position.x + xspeed / 2.5f, newY, transform.position.z + znum / 2.5f);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, newY, transform.position.z + znum);
                    }
                }
                else if (transform.position.x < 60 && enemy.alive && (transform.position.z > 9 || transform.position.z < -0.5f))
                {
                    transform.position = new Vector3(transform.position.x + xspeed, newY, transform.position.z);
                }
                else
                {
                    if (transform.position.z > 9 || transform.position.z < -0.5f)
                    {
                        transform.position = new Vector3(transform.position.x, newY, transform.position.z + znum);
                    }
                    else
                    {
                        transform.position = new Vector3(transform.position.x, newY, transform.position.z - znum);
                    }
                    //else
                    //{
                    //Destroy(gameObject);
                    //}

                }
            }
        }
        
      
    }


}
        
    

