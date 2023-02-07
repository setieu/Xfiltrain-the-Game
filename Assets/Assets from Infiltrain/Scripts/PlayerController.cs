using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour
{
    public float yeetforce = 200.0f;
    public float zRange1 = 0.5f;
    public float zRange2 = 7.0f;
    public float forceMultiplier;
    public float gravityModifier;
    private float leftBound = -500;
    public bool isOnGround = true;
    public bool isOnDead = false;
    public bool protection = false;
    public bool isAlive;
    public AudioClip lossSound1;
    public AudioClip lossSound2;
    public AudioClip lossSound3;
    //public AudioClip winSound; 
    public AudioClip trainSound;


    //private float win = 505;
    private float speed = 8.0f;
    public float jumpForce = 16;
    private float minLeftSpeed = 20;
    private float maxLeftSpeed = 22;
    private float maxTorque = 30;
    public Rigidbody playerRb;
    private GameManager gameManager;
    private AudioSource playerAudio;




    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Physics.gravity *= gravityModifier;

        isAlive = false;
        isOnGround = true;

        playerRb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        //if a controls screen is wanted, move the isalive out of the void start
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        // Player movement

        playerRb.AddForce(Vector3.right * speed * verticalInput * forceMultiplier);

        playerRb.AddForce(Vector3.forward * speed * horizontalInput * forceMultiplier * -1.5f);

        // Constrain the Z


        if (protection)
        {
            if (transform.position.z < zRange1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange1);
            }

            if (transform.position.z > zRange2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange2);
            }
        }


        //if (transform.position.x > win)
        //{
            //gameManager.GameOverWon();
            //playerRb.constraints = RigidbodyConstraints.FreezePosition;

            //playerRb.freezeRotation = true;
        //}




        // Make the player Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce * forceMultiplier, ForceMode.Impulse);
            isOnGround = false;
        }


        //flings player if on dead
        if (isOnDead)
        {
            playerRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            playerRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            protection = false;
            gameManager.GameOverLost();
            playerAudio.PlayOneShot(lossSound1, 10.0f);

        }
        //Destroy player when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }






        //generate fling force
        Vector3 RandomLeftForce()
        {
            return Vector3.left * Random.Range(minLeftSpeed, maxLeftSpeed) * forceMultiplier;
        }
        float RandomTorque()
        {
            return Random.Range(-maxTorque, maxTorque) * forceMultiplier;
        }

    }


    //check if player is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("dead"))
        {
            isOnDead = true;
            protection = false;
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            protection = false;
            StartCoroutine(ProtectionCooldownRoutine());
        }
        //check if player touches enemy to fling them
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * yeetforce, ForceMode.Impulse);
        }
    }




    IEnumerator ProtectionCooldownRoutine()
    {
        yield return new WaitForSeconds(100);
        protection = false;
    }



}

