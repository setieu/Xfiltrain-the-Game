using System.Collections;
using UnityEngine;

public class PogHider : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 2f;
    public float waveDelay = 2f;
    public int waveSize = 1;
    public int maxPogs = 10;

    private float lastWaveTime;
    private int objectsSpawnedInCurrentWave;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    //GameObject modeS = GameObject.Find("Modes");
    private Difficulty difficultY;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        //  Difficulty difficultyScript = modeS.GetComponent<Difficulty>();
        difficultY = GameObject.Find("Modes").GetComponent<Difficulty>();
    }

    private void Update()
    {


        if (gameManager.gameActive)
        {
            // Check if there are any active poghiders
            //if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                if (Time.time - lastWaveTime >= waveDelay)
                {
                    objectsSpawnedInCurrentWave = 0;
                    StartCoroutine(SpawnWave());
                    lastWaveTime = Time.time;
                }
            }
        }
    }

    private IEnumerator SpawnWave()
    {
        // Increment wave size at the start of each wave
        if(gameManager.gameDiff == 1)
        {
             waveSize++;
        }
        else if(gameManager.gameDiff == 2)
        {
            waveSize += 2;
        }
      
      
        Debug.Log(waveSize);
        objectsSpawnedInCurrentWave = 0;
        
        if (gameManager.gameActive)
        {
            while (objectsSpawnedInCurrentWave < waveSize && GameObject.FindGameObjectsWithTag("Enemy").Length < maxPogs)
            {
                Vector3 spawnPosition = spawnManager.GetRandomSpawnPoint();

                if (spawnPosition != Vector3.zero)
                {
                    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    objectsSpawnedInCurrentWave++;
                    Debug.Log("Spawning wave " + (int)waveSize);
                }

                yield return new WaitForSeconds(spawnDelay);

            }
        }
    }
}


