using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    private GameObject target;

    [Header("Attributes")]
    public float range = 3f;
    public float fireRate = 0.001f;
    private float fireCountdown = 1f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public int price;
    


    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("UpdateTarget", 0f, 0.5f);   
    }

   void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject Enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance( transform.position, Enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
               shortestDistance = distanceToEnemy;
               nearestEnemy = Enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy;
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
           
       Vector3 dir = target.transform.position - transform.position;
       Quaternion lookRotation = Quaternion.LookRotation(dir);
       Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
       partToRotate.rotation = Quaternion.Euler (-90f, rotation.y, 0f);

       fireCountdown = fireCountdown-fireRate;
       if (fireCountdown <= 0f)
       {
           Shoot();
           fireCountdown = fireCountdown+1f;
       }
    }

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }

    void OnDrawGizmosSelected () 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
