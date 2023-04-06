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
    public int modeeE;
    public bool gameLost = false;

    public List<GameObject> targetPrefabs;
    public List<AudioClip> GSaudio; // list of audio clips to choose from for Game Start
    public List<AudioClip> DeathAudio; // list of audio clips to choose from for Death
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    public List<AudioClip> DeathTwoAudio; // list of audio clips to choose from for Death2
    public List<AudioClip> HitAudio; // list of audio clips to choose from for Hitting Enemy
    public List<AudioClip> RandomAudio; // list of audio clips to choose from for Randomly saying
    public List<AudioClip> SecondaryAudio; // list of audio clips to choose from for Secondary

    private AudioSource audioSource; // audio source component

    public bool bosspawnedonce = true;
    public GameObject playerR;
    public GameObject hoglicopter;
    public GameObject titleScreen;
    public GameObject healtHbar;
    private HealthBar baR;
    public GameObject Bar;
    public TextMeshProUGUI gameOverLostText;
    public TextMeshProUGUI gameOverWonText;
    public TextMeshProUGUI credits;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI modeText;
    public GameObject toolAssist;
    public GameObject modeTexttGameobject;
    public GameObject timergameobject;
    //so no bocchi death sound
    private bool diefirst = true;
    // public TextMeshProUGUI xcord;
    // public TextMeshProUGUI ycord;
    // public TextMeshProUGUI zcord;
    // public GameObject player;
    //public float xCord = player.transform.position.x + 32;
    //public float yCord = player.transform.position.y - 4.56f;
    //public float zCord = player.transform.position.z - 3.6f;

    public float testX;
    public float testY;

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
        baR = GameObject.Find("Bar").GetComponent<HealthBar>();
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
                
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "Sandbox";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
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
                modeeE = 0;
                Debug.Log("Peaceful");
                break;
            case 1:
                // Set up for easy mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "Easy";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
                startedTime = Time.time;
                //StartCoroutine(Wait());
                //PlayRandomSecondaryAudio();
                // Input sounds
                pogHider.waveDelay = 5f;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }
                pogHider.maxPogs = 15;
                gameDiff = 1;
                modeeE = 1;
                Debug.Log("Easy");
                break;
            case 2:
                // Set up for hard mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "Hard";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
                startedTime = Time.time;
                //StartCoroutine(Wait());
                //PlayRandomSecondaryAudio();
                // Input sounds
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.3 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.9f;
                }
                pogHider.waveDelay = 2f;
                pogHider.maxPogs = 30;
                gameDiff = 2;
                modeeE = 2;
                Debug.Log("Hard");
                break;
            case 3:
                // Set up for normal mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "Normal";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
                startedTime = Time.time;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.8f;
                }
                pogHider.waveDelay = 4f;
                pogHider.maxPogs = 20;
                gameDiff = 1;
                modeeE = 3;
                break;
            case 4:
                //set up for anarchy mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "Anarchy";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
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
                modeeE = 4;
                break;
            case 5:
                //set up for ??? mode
                arrayRange = difficulty;
                playerController.isAlive = true;
                gameActive = true;
                modeTexttGameobject.SetActive(true);
                timergameobject.SetActive(true);
                modeText.text = "???";

                stamina = 50;
                throwRate = throwRate /= difficulty;
                //StartCoroutine(SpawnTarget());
                playerController.playerRb.constraints = RigidbodyConstraints.None;
                titleScreen.SetActive(false);
                toolAssist.SetActive(true);
                PlayRandomGSAudio();
                startedd = true;
                Debug.Log("Game started");
                healtHbar.transform.position = new Vector3(1255, 710, 0);
                startedTime = Time.time;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }

                pogHider.waveDelay = 3f;
                pogHider.maxPogs = 5;
                gameDiff = 1;
                modeeE = 5;
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
        if(bosspawnedonce && modeeE == 5 && timePassed >= 3.4f)
        {
            Instantiate(hoglicopter, new Vector3(55f, 7.6f, -18f), Quaternion.identity);
            bosspawnedonce = false;
        }
        if (yeeTer != null)
        {
            // Access the throwcooldown variable from yeeTer
            cooldown = yeeTer.throwCD;

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
        if(baR.HP < 1)
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
            
            PlayRandomDeathTwoAudio();
            PlayRandomDeathAudio();
            diefirst = false;
        }
       
        gameOverLostText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playerController.isOnDead = true;
        gameActive = false;
        gameLost = true;
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
    void PlayRandomDeathTwoAudio()
    {
        int randomIndex = Random.Range(0, DeathTwoAudio.Count); // choose a random index within the list
        audioSource.clip = DeathTwoAudio[randomIndex]; // set the audio source's clip to the chosen audio clip
        audioSource.Play(); // play the audio
    }
}
