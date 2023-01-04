using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinderellaFire : MonoBehaviour
{
    public GameObject bubbleFactory;
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Go)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject bubble = Instantiate(bubbleFactory);
            bubble.transform.position = firePosition.transform.position;
        }
    }

}
