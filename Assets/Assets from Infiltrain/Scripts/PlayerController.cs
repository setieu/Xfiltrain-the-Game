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
    private AudioSource audioSource; // audio source component

    public GameObject player;
    //private float win = 505;
    private float speed = 0.125f;
    public float jumpForce = 16;
    private float minLeftSpeed = 20;
    private float maxLeftSpeed = 22;
    private float maxTorque = 30;
    public Rigidbody playerRb;
    private GameManager gameManager;
    private AudioSource playerAudio;
    private FollowPlayer followPlayer;
    public Camera cam;
    private bool deadonce = true;
    public List<AudioClip> DeathTwoAudio; // list of audio clips to choose from for Death2
    public bool sounded = true;

    //Chatgpt code
    private Quaternion initialRotation;

    public bool lockXRotation = false;
    public bool lockYRotation = false;
    public bool lockZRotation = false;







    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        followPlayer = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        sounded = true;
        isAlive = false;
        isOnGround = true;

        playerRb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        //if a controls screen is wanted, move the isalive out of the void start


        // Store the initial rotation of the player
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (gameManager.gameActive)
        {
            lockXRotation = true;
            lockYRotation = false;
            lockZRotation = true;
        }
        else
        {
            lockXRotation = true;
            lockYRotation = true;
            lockZRotation = true;
        }


        // Get the mouse position in world space
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y - transform.position.y));

        // Calculate the direction the player needs to face
        Vector3 direction = (mousePos - transform.position).normalized;

        // Set the player's rotation to face the mouse cursor, while preserving the initial x and z rotations
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        float xRotation = lockXRotation ? initialRotation.eulerAngles.x : targetRotation.eulerAngles.x;
        float yRotation = lockYRotation ? initialRotation.eulerAngles.y : targetRotation.eulerAngles.y;
        float zRotation = lockZRotation ? initialRotation.eulerAngles.z : targetRotation.eulerAngles.z;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);









        // Constrain the Z


        //if (protection)
        {
            //if (transform.position.z < zRange1)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, zRange1);
            }

            //if (transform.position.z > zRange2)
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, zRange2);
            }
        }


        //if (transform.position.x > win)
        //{
        //gameManager.GameOverWon();
        //playerRb.constraints = RigidbodyConstraints.FreezePosition;

        //playerRb.freezeRotation = true;
        //}



        // Player movement

        //playerRb.AddForce(Vector3.right * speed * verticalInput * forceMultiplier);

        //playerRb.AddForce(Vector3.forward * speed * horizontalInput * forceMultiplier * -1.5f);


        // Make the player Jump
        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        //{
        //playerRb.AddForce(Vector3.up * jumpForce * forceMultiplier, ForceMode.Impulse);
        //isOnGround = false;
        //}
        // Player movement
        if (gameManager.gameActive)
        {
            // Get the player movement direction

                Vector3 movementDirection = new Vector3(verticalInput, 0.0f, -1.5f * horizontalInput);



            // Normalize the movement direction vector
            if (followPlayer.isFlipped == 1)
            {
                 movementDirection = movementDirection.normalized;
            }
            else if (followPlayer.isFlipped == 2)
            {
                movementDirection = -movementDirection.normalized;
            }


            // Translate the player's position based on the movement direction
            playerRb.transform.Translate(movementDirection * speed * forceMultiplier * Time.deltaTime, Space.World);
        }



        // Make the player Jump
        // if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        // {
        //     playerRb.transform.Translate(Vector3.up * jumpForce * forceMultiplier * Time.deltaTime);
        //     isOnGround = false;
        // }

        //flings player if on dead
        if (isOnDead)
        {
            playerRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            playerRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
            protection = false;
            gameManager.GameOverLost();
            playerAudio.PlayOneShot(lossSound1, 10.0f);

            if (sounded)
            {
                PlayRandomDeathTwoAudio();
                sounded = false;
            }
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

        if(gameManager.gameLost == true)
        {
            playerRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
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

    void PlayRandomDeathTwoAudio()
    {
        int randomIndex = Random.Range(0, DeathTwoAudio.Count); // choose a random index within the list
        audioSource.clip = DeathTwoAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }

}


