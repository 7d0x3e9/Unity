using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    float createTime;
    float currentTime;
    public GameObject enemyFactory;

    public float minTime = 1;
    public float maxTime = 5;


    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;


    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime>createTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemy.SetActive(true);

                enemyObjectPool.RemoveAt(0);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
            }

            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);
        }
    }
}
