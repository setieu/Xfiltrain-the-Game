using System.Collections;
using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    // Variables for controlling the blinking effect
    public float blinkSpeed = 1.0f;
    public float fadeTime = 1.0f;

    // Variables for controlling the red color and fade effect
    public float fadeSpeed = 1.0f;
    public float redIntensity = 1.0f;

    private Material material;
    private float timer;
    private bool isFadingOut;
    public bool activateonce = true;
    private MeshRenderer meshRenderer;
    private GameManager gameManager;
    private PauseScreen pauseScreen;
    public bool isActive = false;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        meshRenderer = GetComponent<MeshRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        pauseScreen = GameObject.Find("Canvas").GetComponent<PauseScreen>();
        timer = 0.0f;
        isFadingOut = false;
        StartCoroutine(Blink());
        isActive = false;
    }

    void Update()
    {
        if(gameManager.startedd && activateonce)
        {
            isActive = true;
            activateonce = false;
        }
        if (gameManager.gameActive && Input.GetKeyDown(KeyCode.H))
        {
            isActive = !isActive;
        }

        


    }

    IEnumerator Blink()
    {
        while (true)
        {
            if (isActive)
            {
                meshRenderer.enabled = true;

                if (!isFadingOut)
                {
                    float alpha = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
                    material.color = new Color(material.color.r, material.color.g, material.color.b, alpha * redIntensity);
                    if (alpha == 1.0f)
                    {
                        timer = fadeTime;
                        isFadingOut = true;
                    }
                }
                else
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0.0f)
                    {
                        isFadingOut = false;
                    }
                    else
                    {
                        float alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeTime);
                        material.color = new Color(material.color.r, material.color.g, material.color.b, alpha * redIntensity);
                    }
                }
            }
            else
            {
                meshRenderer.enabled = false;
            }

            yield return null;
        }
    }
}
