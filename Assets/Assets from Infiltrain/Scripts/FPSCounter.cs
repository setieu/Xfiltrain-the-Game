using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FPSCounter : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI fpsText;
    private float deltaTime;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = ("FPS: ") + Mathf.Round(fps).ToString();
        if(gameManager.gameWon)
        {
            fpsText.text = "FPS: 90";
        }
    }
}

