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
    public bool startedd = false;
    public bool gameStarted = false;
    private PlayerController playerController;
    private PogHider pogHider;
    private Yeeter yeeTer;
    public float cooldown;


    public List<GameObject> targetPrefabs;
    public List<AudioClip> GSaudio; // list of audio clips to choose from for Game Start
    public List<AudioClip> DeathAudio; // list of audio clips to choose from for Death
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    
    public List<AudioClip> HitAudio; // list of audio clips to choose from for Hitting Enemy
    public List<AudioClip> RandomAudio; // list of audio clips to choose from for Randomly saying
    public List<AudioClip> SecondaryAudio; // list of audio clips to choose from for Secondary

    private AudioSource audioSource; // audio source component

    public GameObject titleScreen;
    public GameObject healtHbar;
    public TextMeshProUGUI gameOverLostText;
    public TextMeshProUGUI gameOverWonText;
    public TextMeshProUGUI credits;
    public TextMeshProUGUI timer;
    public GameObject toolAssist;
    //so no bocchi death sound
    private bool diefirst = true;
   // public TextMeshProUGUI xcord;
   // public TextMeshProUGUI ycord;
   // public TextMeshProUGUI zcord;
   // public GameObject player;
    //public float xCord = player.transform.position.x + 32;
    //public float yCord = player.transform.position.y - 4.56f;
    //public float zCord = player.transform.position.z - 3.6f;


    public Button restartButton;

    public bool gameActive;
    public int Scoree =  0;
    public int hogdeaths = 0;
    public int gameDiff;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        // Assign the Yeeter component to yeeTer
        yeeTer = GameObject.Find("Player").GetComponent<Yeeter>() as Yeeter;
        if (yeeTer == null)
        {
            Debug.LogError("Failed to get Yeeter component from Player game object.");
        }
        pogHider = GameObject.Find("PogHide Spawner").GetComponent<PogHider>();
        gameActive = false;
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Scene Loaded");

    }

    public void StartGame(int difficulty)
    {
        // Set up game based on difficulty level
        switch (difficulty)
        {
            case 0:
                // Set up for peaceful mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");

                startedTime = Time.time;
                //StartCoroutine(Wait());
                //PlayRandomSecondaryAudio();
                // Input sounds
                //Yeeter.throwCD
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 1f;
                }
                gameDiff = 0;
                Debug.Log("Peaceful");
                break;
            case 1:
                // Set up for easy mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");

                startedTime = Time.time;
                //StartCoroutine(Wait());
                //PlayRandomSecondaryAudio();
                // Input sounds
                pogHider.waveDelay = 5f;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 1.5f;
                }
                pogHider.maxPogs = 15;
                gameDiff = 1;
                Debug.Log("Easy");
                break;
            case 2:
                // Set up for hard mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");

                startedTime = Time.time;
                //StartCoroutine(Wait());
                //PlayRandomSecondaryAudio();
                // Input sounds
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.3 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 1.3f;
                }
                pogHider.waveDelay = 2f;
                pogHider.maxPogs = 30;
                gameDiff = 2;
                Debug.Log("Hard");
                break;
            case 3:
                // Set up for normal mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");

                startedTime = Time.time;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 1.5f;
                }
                pogHider.waveDelay = 4f;
                pogHider.maxPogs = 20;
                gameDiff = 1;
                break;
            case 4:
                //set up for anarchy mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");

                startedTime = Time.time;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.1f;
                }

                pogHider.waveDelay = 0.3f;
                pogHider.maxPogs = 75;
                gameDiff = 2;
                break;
            case 5:
                //set up for ??? mode
                break;
            default:
                Debug.LogError("Invalid difficulty level: " + difficulty);
                break;
        }

        // Start the game
        gameStarted = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (yeeTer != null)
        {
            // Access the throwcooldown variable from yeeTer
            cooldown = yeeTer.throwCD;
            // Do something with the cooldown value
            Debug.Log("Cooldown is: " + cooldown);
        }
        if (gameActive==true)

        {
            healtHbar.SetActive(true);
            timePassed = Time.time - startedTime;
            Scoree = (int)timePassed + hogdeaths*10;
            timer.text = "Score: " + (int)Scoree +"0";

        }
        if(gameActive == false)
        {
            healtHbar.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dead"))
        {

            
            GameOverLost();
            Debug.Log("Game over");
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
        if(diefirst == true)
        {
            PlayRandomDeathAudio();
            diefirst = false;
        }
        
        gameOverLostText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playerController.isOnDead = true;
        gameActive = false;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics.gravity /= 3;
        startedd = false;
        Time.timeScale = 1;
        Debug.Log("Game Restarted");
    }

   // IEnumerator SpawnTarget()
    //{
    //    while (gameActive)
    //    {
     //       yield return new WaitForSeconds(throwRate);
     //       int index = Random.Range(0, arrayRange);


    //        Instantiate(targetPrefabs[index]);


    //    }

    //}




    
    //frame limiter
     void Awake ()
     {
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 90;
     }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        // Do something after waiting for 2 seconds
    }


    void PlayRandomGSAudio()
    {
        int randomIndex = Random.Range(0, GSaudio.Count); // choose a random index within the list
        audioSource.clip = GSaudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomDeathAudio()
    {
        int randomIndex = Random.Range(0, DeathAudio.Count); // choose a random index within the list
        audioSource.clip = DeathAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomHitAudio()
    {
        int randomIndex = Random.Range(0, HitAudio.Count); // choose a random index within the list
        audioSource.clip = HitAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    
    void PlayRandomDetachmentAudio()
    {
        int randomIndex = Random.Range(0, DetachmentAudio.Count); // choose a random index within the list
        audioSource.clip = DetachmentAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
    void PlayRandomSecondaryAudio()
    {
        int randomIndex = Random.Range(0, SecondaryAudio.Count); // choose a random index within the list
        audioSource.clip = SecondaryAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
}
