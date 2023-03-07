using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoghiderAnim : MonoBehaviour
{
    public float speed = 1f; // adjust this to change the speed of the animation
    public float height = 1f; // adjust this to change the height of the animation

    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startingPosition.y + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
