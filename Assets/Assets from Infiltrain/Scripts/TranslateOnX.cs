using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateOnX : MonoBehaviour
{
    public bool heet = true; // Set to true to enable translation
    private Rigidbody enemyRb;
    public bool isRunning = false;
    public bool nall = true;
    private Rigidbody rb;


    private float speed = 10.0f; // Speed of translation
    private float speed2 = 50.0f; // Speed of translation

    private IEnumerator SetHeetFalseFor3Seconds()
    {
        isRunning = true;
        heet = false;
        yield return new WaitForSeconds(3f);
        heet = true;
        isRunning = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (heet && nall)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && isRunning == false)
        {

            StartCoroutine(SetHeetFalseFor3Seconds());
        }

        if (collision.gameObject.CompareTag("Train"))
        {
            //gameObject.AddComponent<Rigidbody>().mass = 1;
            //rb = gameObject.GetComponent<Rigidbody>();
            nall = false;
            //rb.AddForce(Vector3.up * 1050f, ForceMode.Impulse);
            //rb.AddForce(Vector3.left * 1050f, ForceMode.Impulse);
            StartCoroutine(MoveBack());

        }
    }
    IEnumerator MoveBack()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed2);
            yield return new WaitForSeconds(0.01f); // add a delay between each movement
        }
    }
}

