using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public GameObject dogPrefab;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosYDog = 0;
    private float spawnPosYBall = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomDogs", startDelay);
        Invoke("SpawnRandomBall", startDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomDogs ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosYDog, 0);

        // instantiate ball at random spawn location
        Instantiate(dogPrefab, spawnPos, dogPrefab.transform.rotation);
        Invoke("SpawnRandomDogs", Random.Range(startDelay, spawnInterval));
    }

    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosYBall, 0);

        // instantiate ball at random spawn location
        int indexBall = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[indexBall], spawnPos, ballPrefabs[indexBall].transform.rotation);
        Invoke("SpawnRandomBall", Random.Range(startDelay, spawnInterval));

    }

}
