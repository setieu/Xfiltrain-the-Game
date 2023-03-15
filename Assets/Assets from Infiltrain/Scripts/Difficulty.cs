using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty = 0;
    public List<GameObject> childObjects; // list to store child objects

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDifficulty(int difficulty)
    {
        gameManager.StartGame(difficulty);
    }


}
