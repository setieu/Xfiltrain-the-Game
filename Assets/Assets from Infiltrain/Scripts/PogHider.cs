using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogHider : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 2f;
    public float waveDelay = 2f;
    public int waveSize = 100;
    public float minSpawnDistance = 5f;

    private float lastWaveTime;
    private int objectsSpawnedInCurrentWave;
    private Transform playerTransform;
    //Gamemanager
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerTransform = GetComponent<Transform>();
    }
 
    private void Update()
    {
        if(gameManager.gameActive)
        {
            if (Time.time - lastWaveTime >= waveDelay)
            {
                objectsSpawnedInCurrentWave = 0;
                StartCoroutine(SpawnWave());
                lastWaveTime = Time.time;
            }
        }

    }

    private IEnumerator SpawnWave()
    {
        if(gameManager.gameActive)
        {
            while (objectsSpawnedInCurrentWave < waveSize)
            {
                Vector3 spawnPosition = GetValidSpawnPosition();

                if (spawnPosition != Vector3.zero)
                {
                    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    objectsSpawnedInCurrentWave++;
                }

                yield return new WaitForSeconds(spawnDelay);
            }
        }

    }

    private Vector3 GetValidSpawnPosition()
    {

        Vector3 spawnPosition = playerTransform.position + Random.onUnitSphere * minSpawnDistance * 2;
        spawnPosition.y = playerTransform.position.y;

        if (Vector3.Distance(playerTransform.position, spawnPosition) < minSpawnDistance)
        {
            return Vector3.zero;
        }

        return spawnPosition;
    }
}