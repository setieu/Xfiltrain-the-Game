using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty = 0;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
