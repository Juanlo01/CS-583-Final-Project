using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Tower : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public int SummonCost = 100;
    
    [Header("Audio Settings")]
    public AudioClip fireSound; // Sound for firing bullets
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing! Add an AudioSource to the turret.");
        }
        
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //array storing all the enemies present
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; //shortest distance inf if no enemy nearby
        GameObject nearestEnemy = null;

        //loop that iterates through each enemy, if distance to enemy is less than shortest distance, the distance becomes shortest
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position; // Direction to the target
        dir.y = 0; // Keep the direction in the horizontal plane to avoid tilting

        Quaternion lookRotation = Quaternion.LookRotation(dir); // Calculate the desired rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(90f, rotation.y, 0f); // Maintain the 90-degree X-axis rotation

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;

        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        audioSource.PlayOneShot(fireSound);

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    //function needed to visualize the range of our turret
    void OnDrawGizmosSelected()
    {
        //red sphere set to turret's location and radius size of range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
