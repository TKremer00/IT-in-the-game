using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [System.NonSerialized]
    public List<Transform> pathPoints;
    private Transform target; // The current target we are walking towards
    private Transform castle;
    public GameManagerControler gameManagerControler;
    public float speed = 1f;
    public float enemyStrenght = 1f;
    public float worth = 1f; // the amount of money to add or remove
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.Find("Castle").transform;
        target = pathPoints[0];

    }

    // Update is called once per frame
    void Update()   
    {
        if(Vector3.Distance(transform.position,target.position) < 1.0f && target != castle){
            pathPoints.RemoveAt(0);
            
            if(pathPoints.Count == 0){
                target = castle;
            }else{
                target = pathPoints[0];
            }
            
        } else if(Vector3.Distance(transform.position,castle.position) > 1.0f) {
            MoveToVector(target.position);
        }else {
            //take damage
            gameManagerControler.TakeDamage(enemyStrenght);
            // Enemy is at the target
            Die();
            return;
        }

        MoveToVector(target.position);

        if(health <= 0)
        {
            Die();
        }
    }

    // Let the enemy walk towards a target
    public void MoveToVector(Vector3 target) 
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target,step);
        // Let enemy look at target
        
        var lookRotation = Quaternion.LookRotation((target - transform.position).normalized);
        lookRotation.x = 0;
        lookRotation.z = 0;
        var rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 1.5f);
        transform.rotation = rotation;
    }

    // add the money to the users account
    private void giveUserMoney()
    {
        gameManagerControler.addMoney(worth);
    }
    
    // The destory the enemy
    private void Die()
    {
        Destroy(gameObject);
    }
}
