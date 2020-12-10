﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 3f;
    public string enemyTag = "Enemy";

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
            target = nearestEnemy.transform;
       }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
           return;
       }
    }

    void OnDrawGizmosSelected () 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
