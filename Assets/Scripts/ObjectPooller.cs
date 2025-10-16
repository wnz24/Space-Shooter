using System.Collections.Generic;   
using UnityEngine;

public class ObjectPooller : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 5;
    private List<GameObject> pool;


    private void Start()
    {
        Createpool();   
    }
    private void Createpool()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            createNewObject();
        }
    }

    public GameObject createNewObject()
    {
        GameObject obj = Instantiate(prefab,transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
               
                return obj;
            }
        }
        return createNewObject();
    }   
}
