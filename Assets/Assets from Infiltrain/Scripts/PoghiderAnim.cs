using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoghiderAnim : MonoBehaviour
{
    public float speed = 1f; // adjust this to change the speed of the animation
    public float height = 1f; // adjust this to change the height of the animation
   
    public float znum;
    public Enemy enemy;
    private GameManager gameManager;
    private Vector3 startingPosition;
    public GameObject hogrider;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive)
        {
            float newY = startingPosition.y + height * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
        
        if(hogrider.transform.position.x < -100)
        {
            Destroy(gameObject);
        }
      
    }


}
        
    

