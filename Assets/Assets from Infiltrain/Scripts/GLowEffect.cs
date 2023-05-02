using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLowEffect : MonoBehaviour
{
    // Variables for controlling the red color and fade effect
    public float fadeSpeed = 1.0f;
    public float redIntensity = 1.0f;

    private Renderer rend;
    private bool isEffectOn = true;

    void Start()
    {
        // Get the Renderer component of the GameObject
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Toggle the effect on/off when the H key is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            isEffectOn = !isEffectOn;
        }

        // If the effect is on, update the red color and fade effect
        if (isEffectOn)
        {
            // Calculate the new red color based on the current time
            float redValue = Mathf.Sin(Time.time * fadeSpeed) * redIntensity;

            // Set the color of the material to the new red color
            rend.material.color = new Color(redValue, 0.0f, 0.0f, 1.0f);
        }
    }
}