using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackOnCollision : MonoBehaviour
{
    public float detachSpeed = 100;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine(MoveBack());
        }
    }

    IEnumerator MoveBack()
    {
        while (true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * detachSpeed);
            yield return new WaitForSeconds(0.01f); // add a delay between each movement
        }
    }
}