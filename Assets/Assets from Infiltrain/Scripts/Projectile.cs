using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody projectileRb;
    private GameManager gameManager;
    private float minUpSpeed = 10;
    private float maxUpSpeed = 16;
    private float minLeftSpeed = 32;
    private float maxLeftSpeed = 38;
    private float maxTorque = 30;
    public float ddownforce = 3;
    private float leftBound = -200;
    public float forcemultiplier;
    public GameObject player;
    public float despawnTime = 5f;
    public AudioClip destroySound;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("Player");

        projectileRb = GetComponent<Rigidbody>();

       // projectileRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
       // projectileRb.AddForce(RandomUpForce(), ForceMode.Impulse);
     //  projectileRb.AddForce(Downforce(), ForceMode.Impulse);
        projectileRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //  transform.position = SpawnPosition();

        StartCoroutine(Despawn());
    }
    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //Destroy projectile when out of bounds
        if (transform.position.x < leftBound && gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }





    }


   Vector3 RandomLeftForce()
    {
        return Vector3.left * Random.Range(minLeftSpeed, maxLeftSpeed) * forcemultiplier;
    }
    //Vector3 Downforce()
    //{
   //     return Vector3.down * ddownforce * forcemultiplier;
   // }
   // Vector3 RandomUpForce()
   // {
   //     return Vector3.up * Random.Range(minUpSpeed, maxUpSpeed) * forcemultiplier;
   // }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque) * forcemultiplier;
    }


  //  Vector3 SpawnPosition()
  //  {

   //     Vector3 spawnPosition = new Vector3(player.transform.position.x + 60, 8, Random.Range(1.2f,6.2f));
   //     return spawnPosition;

   // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dead"))
        {
            projectileRb.AddForce(RandomLeftForce(), ForceMode.Impulse);
            projectileRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        }

      //  if(collision.gameObject.CompareTag("Ground") && collision.gameObject.CompareTag("Player"))
       // {
       //     playerController.isOnGround = true;
       // }

    }
}
