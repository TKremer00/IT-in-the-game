using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform target; // The end position to walk to
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target.position){
            MoveToVector(target.position);
        }else {
            // Enemy is at the target
            Die();
        }
    }

    // Let the enemy walk towards a target
    public void MoveToVector(Vector3 target) 
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target,step);
        // Let enemy look at target
        Quaternion targetRotation = Quaternion.LookRotation( target );
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, Time.deltaTime);
    }
    
    // The destory the enemy
    void Die()
    {
        Destroy(gameObject);
    }
}
