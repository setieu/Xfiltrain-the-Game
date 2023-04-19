using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateOnX : MonoBehaviour
{
    public bool heet = true; // Set to true to enable translation
    private Rigidbody enemyRb;
    public bool isRunning = false;
    public bool nall = true;

    public float speed = 1.0f; // Speed of translation


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

            nall = false;
        }
    }

}