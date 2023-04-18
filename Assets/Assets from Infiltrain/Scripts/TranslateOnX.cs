using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateOnX : MonoBehaviour
{
    public bool heet = true; // Set to true to enable translation

    public float speed = 1.0f; // Speed of translation

    // Update is called once per frame
    void Update()
    {
        if (heet)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}