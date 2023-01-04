using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        Ready,
        Go,
        Pause,
        GameOver
    }

    public GameState gState;

    public Text stateLabel;

    GameObject Cinderella;

    CinderellaMove CinderellaM;

    public static GameManager gm;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gState = GameState.Ready;

        StartCoroutine(GameStart());

        Cinderella = GameObject.Find("Cinderella");

        CinderellaM = Cinderella.GetComponent<CinderellaMove>();
    }

    IEnumerator GameStart()
    {
        stateLabel.text = "READY";
        stateLabel.color = new Color32(0,0,0,255);

        yield return new WaitForSeconds(2.0f);

        stateLabel.text = "START!";

        yield return new WaitForSeconds(0.5f);
        stateLabel.text = "";

        gState = GameState.Go;
   
    }

    // Update is called once per frame
    void Update()
    {
       if(CinderellaM.hp <= 0)
        {
            stateLabel.text = "GAME OVER";
            stateLabel.color = new Color32(255, 0, 0, 255);

            gState = GameState.GameOver;
        }
    }
}
