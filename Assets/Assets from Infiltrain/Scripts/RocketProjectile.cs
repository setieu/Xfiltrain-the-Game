using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;
    private float speed = 0.1f;
    public List<ParticleSystem> particleSystems;
    public ParticleSystem particle;

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
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isOnDead = true;
        Destroy(gameObject);
    }

    
}
