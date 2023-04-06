using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogSpin : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    private PlayerController playerController;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameManager.gameActive)
        {
            transform.Rotate(Vector3.down * rotationSpeed);
        }

    }
}
