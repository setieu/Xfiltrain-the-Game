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
    public List<AudioClip> GSaudio; // list of audio clips to choose from for Game Start
    public List<AudioClip> DeathAudio; // list of audio clips to choose from for Death
    public List<AudioClip> DetachmentAudio; // list of audio clips to choose from for Detachment
    
    public List<AudioClip> HitAudio; // list of audio clips to choose from for Hitting Enemy
    public List<AudioClip> RandomAudio; // list of audio clips to choose from for Randomly saying
    public List<AudioClip> SecondaryAudio; // list of audio clips to choose from for Secondary

    private AudioSource audioSource; // audio source component

    public GameObject titleScreen;
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




    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameActive = false;
        audioSource = GetComponent<AudioSource>();
        

    }
    public void StartGame(int difficulty)
    {
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
        
        startedTime = Time.time;
        //StartCoroutine(Wait());
        //PlayRandomSecondaryAudio();
        // Input sounds

    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive==true)

        {
            timePassed = Time.time - startedTime;
            timer.text = "Score: " + (int)timePassed +"0";

            //xcord.text = "X:" + xCord;
            //ycord.text = "Y:" + yCord;
            //zcord.text = "Z:" + zCord;
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
        if(diefirst)
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
