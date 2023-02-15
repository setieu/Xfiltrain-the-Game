using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackOnCollision : MonoBehaviour
{
    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            yield return new WaitForSeconds(0.01f); // add a delay between each movement
        }
    }
}

