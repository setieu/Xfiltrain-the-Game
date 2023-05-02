using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public MoveBackOnCollision moveBackOnCollision;

    // Start is called before the first frame update
    void Start()
    {
        moveBackOnCollision = GameObject.Find("Cars").GetComponent<MoveBackOnCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveBackOnCollision.boomboom == true)
        {
            explosion.SetActive(true);
        }
    }
}
