using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public float bosshP;
    public int stamina;
    private float throwRate = 45.0f;
    private int arrayRange;
    private int time = 0;
    public float timePassed;
    private float startedTime;
    public bool startedd = false;
    public bool gameStarted = false;
    private MoveBackOnCollision backOnCollision;
    private PauseScreen pauseScreen;
    private Bossman bossMan;
    private GameObject bossObject;
    private PlayerController playerController;
    private PogHider pogHider;
    private Yeeter yeeTer;
    public float cooldown;
    public int modeeE;
    public bool gameLost = false;
    public AudioClip winn;
    public GameObject tanks;
    public GameObject rogueTrain;
    [SerializeField] private Light sunLight;
    


    public List<GameObject> targetPrefabs;
    public List<AudioClip> GSaudio; // list of audio clips to choose from for Game Start
    public List<AudioClip> DeathAudio; // list of audio clips to choose from for Death
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    public List<AudioClip> DeathTwoAudio; // list of audio clips to choose from for Death2
    public List<AudioClip> HitAudio; // list of audio clips to choose from for Hitting Enemy
    public List<AudioClip> RandomAudio; // list of audio clips to choose from for Randomly saying
    public List<AudioClip> SecondaryAudio; // list of audio clips to choose from for Secondary

    private AudioSource audioSource; // audio source component

    public bool flawless = false;
    public bool bosspawnedonce = true;
    public GameObject fpscounter;
    public GameObject rail1;
    public GameObject rail2;
    public GameObject rail3;
    public GameObject rail4;
    public GameObject bosshpobject;
    public GameObject playerR;
    public GameObject hoglicopter;
    public GameObject titleScreen;
    public GameObject healtHbar;
    private HealthBar baR;
    public GameObject Bar;
    public TextMeshProUGUI bossHPText;
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

    public GameObject uiTextObject;
    public float transitionSpeed = 500.0f;
    public float waitTime = 2.0f;

    public bool gameWon = false;
    public bool gameActive;
    public int Scoree =  0;
    public int hogdeaths = 0;
    public int bossdeaths = 0;
    public int gameDiff;
    public bool flashingman = false;
    public GameObject glower;


    public GameObject BossHpBar;
    // Start is called before the first frame update
    void Start()
    {
        backOnCollision = GameObject.Find("Cars").GetComponent<MoveBackOnCollision>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        pauseScreen = GameObject.Find("Canvas").GetComponent<PauseScreen>();
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
        glower.SetActive(false);
    }

    public void StartGame(int difficulty)
    {
        // Set up game based on difficulty level
        switch (difficulty)
        {
            case 0:
                // Set up for peaceful mode
                modeeE = 0;
                arrayRange = difficulty;
                modeText.text = "Peaceful - Sandbox";
                StartTheGame();
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
                modeeE = 1;
                arrayRange = difficulty;
                modeText.text = "Easy - Get 3000 points";
                StartTheGame();
                pogHider.waveDelay = 6f;
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }
                pogHider.maxPogs = 12;
                gameDiff = 1;

                Debug.Log("Easy");
                break;
            case 2:
                // Set up for hard mode
                modeeE = 2;
                arrayRange = difficulty;
                modeText.text = "Hard - Get 15000 points";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.3 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }
                pogHider.waveDelay = 2.5f;
                pogHider.maxPogs = 30;
                gameDiff = 2;

                Debug.Log("Hard");
                break;
            case 3:
                // Set up for normal mode
                modeeE = 3;
                arrayRange = difficulty;
                modeText.text = "Normal - Get 10000 points";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 1.5 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }
                pogHider.waveDelay = 5f;
                pogHider.maxPogs = 14;
                gameDiff = 1;

                break;
            case 4:
                //set up for anarchy mode
                modeeE = 4;
                arrayRange = difficulty;
                modeText.text = "Anarchy - Objective: Survive";
                StartTheGame();
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
                modeeE = 5;
                arrayRange = difficulty;
                modeText.text = "Bossfight - Get 15000 points";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }

                pogHider.waveDelay = 3.5f;
                pogHider.maxPogs = 5;
                gameDiff = 1;

                break;
            case 6:
                //Set up for extra mode
                modeeE = 6;
                Destroy(tanks);
                rail1.SetActive(true);
                rail2.SetActive(true);
                rail3.SetActive(true);
                rail4.SetActive(true);
                sunLight.color = Color.red;
                rogueTrain.SetActive(true);
                arrayRange = difficulty;
                modeText.text = "Chase Mode - Survive";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }

                pogHider.waveDelay = 1.0f;
                pogHider.maxPogs = 0; //fix
                gameDiff = 1;

                break;
            case 8:
                //Set up for hidden mode
                modeeE = 8;
                arrayRange = difficulty;
                modeText.text = "Ramp Up Mode - Survive";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.7f;
                }

                pogHider.waveDelay = 1.0f;
                pogHider.maxPogs = 5;
                gameDiff = 1;

                break;
            case 9:
                //Set up for secret mode
                modeeE = 9;
                arrayRange = difficulty;
                modeText.text = "PC Crash Mode";
                StartTheGame();
                if (yeeTer != null)
                {
                    // Set the throwcooldown variable to 0.1 seconds
                    yeeTer.canSpawn = true;
                    yeeTer.throwCD = 0.01f;
                }

                pogHider.waveDelay = .3f;
                pogHider.maxPogs = 50;
                gameDiff = 1;

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
        if(backOnCollision.randomvariable)
        {
            glower.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H) && flashingman)
        {
            glower.SetActive(false);
            flashingman = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && !flashingman)
        {
            glower.SetActive(true);
            flashingman = true;
        }
            if (gameActive == false && pauseScreen.isPaused == false && flawless == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flawless = true;
                if (flawless)
                {
                    baR.MaxHP = 1;
                    baR.HP = 1;

                }
            }
        }
        else if (gameActive == false && pauseScreen.isPaused == false && flawless == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flawless = false;
                baR.MaxHP = 10;
                baR.HP = 10;
            }
        }


        if(flawless)
        {
            sunLight.color = Color.red;
        }
        else if(flawless == false && modeeE != 6)
        {
            sunLight.color = Color.white;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Physics.gravity /= 3;
            startedd = false;
            Time.timeScale = 1;
            Debug.Log("Game Restarted");
        }

        if(bosspawnedonce && modeeE == 5 && timePassed >= 3.4f)
        {
            Instantiate(hoglicopter, new Vector3(55f, 7.6f, -18f), Quaternion.identity);
            bosspawnedonce = false;

        }

        if(timePassed > 3.41f && modeeE == 5)
        {
            bossObject = GameObject.Find("Ridehogger(Clone)");
            if(bossObject != null)
            {
                bosshpobject.SetActive(true);
                bossMan = GameObject.Find("Ridehogger(Clone)").GetComponent<Bossman>();
                bosshP = bossMan.bosShp;
                Debug.Log(bossMan.bosShp);
                bossHPText.text = "Boss HP: " + bosshP.ToString();
                BossHpBar.SetActive(true);
            }


            if(bossObject == null)
            {
                bosshpobject.SetActive(false);
                BossHpBar.SetActive(false);
            }
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
            Scoree = (int)timePassed + hogdeaths*10 + bossdeaths*1250;
            timer.text = "Score: " + (int)Scoree + "0";

        }
        if(gameActive == false && gameWon == false)
        {
            healtHbar.SetActive(false);
        }
        if(baR.HP < 1)
        {
            healtHbar.SetActive(false);
        }

        if(gameWon == true && gameActive == false)
        {
            Time.timeScale = 0;
        }
        else if(gameWon == false && gameActive == false && gameLost == false && pauseScreen.isPaused == false)
        {
            //work in progress code
            //havent tested it yet but i imagine if change the timescale to something
            //then pause and unpause, the timescale will be set back to 1
            Time.timeScale = 1;
        }

    }
    public void LateUpdate()
    {
        if (modeeE == 1)
        {
            //score is x10
            if (Scoree >= 300)
            {
                GameOverWon();
            }

        }
        if (modeeE == 2)
        {
            //score is x10
            if (Scoree >= 1500)
            {
                GameOverWon();

            }
        }
        if (modeeE == 3)
        {
            //score is x10
            if (Scoree >= 1000)
            {
                GameOverWon();

            }
        }
        if (modeeE == 4)
        {
            //score is x10
            if (Scoree >= 15000)
            {
                GameOverWon();

            }
        }
        if (modeeE == 5)
        {

            //score is x10
            if (Scoree >= 1500)
            {
                GameOverWon();

            }
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

    private void StartTheGame()
    {
        playerController.isAlive = true;
        gameActive = true;
        modeTexttGameobject.SetActive(true);
        timergameobject.SetActive(true);
        fpscounter.SetActive(true);
        glower.SetActive(true);
        flashingman = true;
        stamina = 50;
        //StartCoroutine(SpawnTarget());
        playerController.playerRb.constraints = RigidbodyConstraints.None;
        titleScreen.SetActive(false);
        toolAssist.SetActive(true);
        PlayRandomGSAudio();
        startedd = true;
        Debug.Log("Game started");
        if(modeeE != 6)
        {
            healtHbar.transform.position = new Vector3(940, 530, 0);
            if(modeeE != 0)
            {
                // Set the UI text gameobject to active
                uiTextObject.SetActive(true);

                // Wait for the specified amount of time
                StartCoroutine(WaitAndTranslate());
            }
            
        }
        

        startedTime = Time.time;
    }
    public void GameOverWon()
    {

        audioSource.Pause();
        audioSource.clip = winn;
        audioSource.Play();
        gameOverWonText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        playerController.isAlive = false;
        gameActive = false;
        gameWon = true;
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
    private IEnumerator WaitAndTranslate()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(waitTime);

        // Translate the UI text gameobject off screen to the top
        while (uiTextObject.transform.position.y < Screen.height)
        {
            Vector3 newPos = uiTextObject.transform.position;
            newPos.y += transitionSpeed * Time.deltaTime;
            uiTextObject.transform.position = newPos;
            yield return null;
        }

        // Set the UI text gameobject to inactive after the transition is complete
        uiTextObject.SetActive(false);
    }
}
