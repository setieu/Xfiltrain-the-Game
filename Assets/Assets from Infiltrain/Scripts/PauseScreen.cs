using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    public Text instructionsText;
    public bool isPaused = false;
    private GameManager gameManager;
    private BlinkingObject blinkingObject;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        blinkingObject = GameObject.Find("Cube (1)").GetComponent<BlinkingObject>();
        blinkingObject = GameObject.Find("Cube (2)").GetComponent<BlinkingObject>();
        blinkingObject = GameObject.Find("Cube (3)").GetComponent<BlinkingObject>();
        blinkingObject = GameObject.Find("Cube (4)").GetComponent<BlinkingObject>();
        gameManager.titleScreen.SetActive(true);
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)//notpaused then will pause
            {
                Time.timeScale = 0;
                isPaused = true;
                pausePanel.SetActive(true);
                gameManager.gameActive = false;
                gameManager.titleScreen.SetActive(false);
                blinkingObject.isActive = false;
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                pausePanel.SetActive(false);
                if (gameManager.startedd == true)
                {
                    gameManager.gameActive = true;
                    blinkingObject.isActive = true;
                }
                else
                {
                    gameManager.titleScreen.SetActive(true);
                    gameManager.gameActive = false;
                }
            }
        }
    }
}


