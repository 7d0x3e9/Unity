using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustManager : MonoBehaviour
{
    float createTime;
    float currentTime;
    public GameObject DustFactory;

    public float minTime = 1;
    public float maxTime = 5; 

    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(minTime, maxTime);   
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Go)
        {
            return;
        }

        currentTime += Time.deltaTime;

        if(currentTime > createTime)
        {
            GameObject Dust = Instantiate(DustFactory);
            Dust.transform.position = transform.position;

            currentTime = 0;

            createTime = Random.Range(minTime, maxTime);
        } 
    }
}
