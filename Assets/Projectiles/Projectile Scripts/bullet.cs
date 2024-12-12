using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Transform target;
    public float damage = 1f;
    public float speed = 70f;
    
    public void Seek(Transform _target)
    {
        target = _target;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            Debug.Log("Hit!");
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.transform.tag == "Enemy"){
            // do damage here, for example:
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}
