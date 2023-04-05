using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;
    private float speed = 0.1f;
    public ParticleSystem particle;
    private float rotationSpeed = 360f; // adjust this to change the speed of rotation
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime); // rotates the object around the x-axis

            if(transform.position.z > 50)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerController.particle.Play();
            playerController.isOnDead = true;
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
        
    }
    
}

