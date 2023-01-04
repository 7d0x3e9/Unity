using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet")|| other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Bullet"))
            {
               PlayerFire.bulletObjectPool.Add(other.gameObject);
            }

            if (other.gameObject.name.Contains("Enemy"))
            {
               EnemyManager.enemyObjectPool.Add(other.gameObject);
            }
        }
      
    }
}
