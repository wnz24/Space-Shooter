
using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    [SerializeField] private int waveNumber;
    [SerializeField] private List<Wave> waves;

    [System.Serializable]
    public class Wave {
    public GameObject prefab;
    public float spawnInterval;
    public float spawnTime; 
    public int objectsPerWave;
    public int spawnedObjectCount; 

    }
    void Update()
    {
       waves[waveNumber].spawnTime += Time.deltaTime * PlayerController.Instance.boost;
        if (waves[waveNumber].spawnTime >= waves[waveNumber].spawnInterval)
        {
            waves[waveNumber].spawnTime = 0;
            spawnObject();
        }
        if (waves[waveNumber].spawnedObjectCount >= waves[waveNumber].objectsPerWave)
        {
            waves[waveNumber].spawnedObjectCount = 0;
            waveNumber = (waveNumber + 1) % waves.Count;
        }
    }

    private void spawnObject()
    {
        Instantiate(waves[waveNumber].prefab, RandomSpawnPoint(), transform.rotation,transform);
        waves[waveNumber].spawnedObjectCount++; 
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        spawnPoint.x = minPos.position.x;
        spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
        return spawnPoint;
    }
}
