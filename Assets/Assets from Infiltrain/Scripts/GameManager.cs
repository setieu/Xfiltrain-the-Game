using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public int stamina;
    private float throwRate = 45.0f;
    private int arrayRange;
    private int time = 0;
    private float timePassed;
    private float startedTime;
    private PlayerController playerController;


    public List<GameObject> targetPrefabs;

    public GameObject titleScreen;
    public TextMeshProUGUI gameOverLostText;
    public TextMeshProUGUI gameOverWonText;
    public TextMeshProUGUI credits;
    public TextMeshProUGUI timer;
    public GameObject toolAssist;
    

    public Button restartButton;

    private bool gameActive;




    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameActive = false;


    }
    public void StartGame(int difficulty)
    {
        arrayRange = difficulty;
        playerController.isAlive = true;
        gameActive = true;

        stamina = 50;
        throwRate = throwRate /= difficulty;
        StartCoroutine(SpawnTarget());
        playerController.playerRb.constraints = RigidbodyConstraints.None;
        titleScreen.SetActive(false);
        toolAssist.SetActive(true);

        startedTime = Time.time;
        // Input sounds

    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive==true)

        {
            timePassed = Time.time - startedTime;
            timer.text = "Time: " + (int)timePassed;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dead"))
        {
            GameOverLost();
        }
    }


    public void GameOverWon()
    {
        gameOverWonText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playerController.isAlive = false;
        gameActive = false;
    }
    public void GameOverLost()
    {
        gameOverLostText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playerController.isOnDead = true;
        gameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics.gravity /= 3;
    }

    IEnumerator SpawnTarget()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(throwRate);
            int index = Random.Range(0, arrayRange);


            Instantiate(targetPrefabs[index]);


        }

    }




    
    //frame limiter
     void Awake ()
     {
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 90;
     }


}
