using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject goodPrefab;
    [SerializeField] private GameObject badPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnYPos = 0;
    [Range(0f, 1f)][SerializeField] private float badChance = 0.4f;

    private float timer;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        GameObject prefabToSpawn;

        // Adjustable spawn chance
        float roll = Random.value;
        if (roll < badChance)
        {
            prefabToSpawn = badPrefab;
        }
        else
        {
            prefabToSpawn = goodPrefab;
        }
        if (prefabToSpawn == null) return;

        // Spawn on left of screen
        Vector3 leftEdge = mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 spawnPos = new Vector3(leftEdge.x - 1f, spawnYPos, 0);

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
