using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;
    public GameObject prefab;
    public float spawnInterval;
    public float spawnTime;
    void Update()
    {
        spawnTime += Time.deltaTime * PlayerController.Instance.boost;
        if(spawnTime >= spawnInterval)
        {
            spawnTime = 0;
            spawnObject();
        }
    }

    private void spawnObject()
    {
        Instantiate(prefab, RandomSpawnPoint(), transform.rotation);
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        spawnPoint.x = minPos.position.x;
        spawnPoint.y = Random.Range(minPos.position.y, maxPos.position.y);
        return spawnPoint;  
    }
}
