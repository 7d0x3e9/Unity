using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public float speed = 5;

    public int attackPower = 4;

    GameObject Cinderella;

    public int maxHp = 3;

    int currentHp;

    // Start is called before the first frame update
    void Start()
    {
        Cinderella = GameObject.Find("Cinderella");

        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Go)
        {
            return;
        }

        Vector3 dir = Vector3.left;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.Contains("Bubble"))
        {
            GameObject smObject = GameObject.Find("ScoreManager");
            ScoreManager sm = smObject.GetComponent<ScoreManager>();
            sm.currentScore++;
            sm.currentScoreUI.text = "¸ÕÁö °ø°Ý Ã³Ä¡ : " + sm.currentScore + " / 10";
        }
        else
        {
            CinderellaMove pm = Cinderella.GetComponent<CinderellaMove>();
            pm.OnDamage(attackPower);
        }

        Destroy(gameObject);
    }
}
