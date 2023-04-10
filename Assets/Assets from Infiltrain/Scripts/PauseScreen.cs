using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    public Text instructionsText;
    public bool isPaused = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.titleScreen.SetActive(true);
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)//notpaused then will pause
            {
                Time.timeScale = 0;
                isPaused = true;
                pausePanel.SetActive(true);
                gameManager.gameActive = false;
                gameManager.titleScreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                pausePanel.SetActive(false);
                if (gameManager.startedd == true)
                {
                    gameManager.gameActive = true;
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


