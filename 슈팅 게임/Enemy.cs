using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
 
    }

   private void OnEnable()
    {
        int randValue = Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();

        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        ScoreManager.Instance.Score++;

        transform.forward = Vector3.zero;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            PlayerFire.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);

     
        EnemyManager.enemyObjectPool.Add(other.gameObject);
       
    }
}
