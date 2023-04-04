using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogSpin : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


            transform.Rotate(Vector3.down * rotationSpeed);

    }
}
