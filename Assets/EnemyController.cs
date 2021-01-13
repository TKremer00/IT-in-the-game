using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<Transform> pathPoints;
    private Transform target; // The current target we are walking towards
    private Transform castle;
    public GameManagerControler gameManagerControler;
    public float speed = 1f;
    public float enemyStrenght = 1f;
    public float worth = 1f; // the amount of money to add or remove

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.Find("Castle").transform;

        pathPoints = new List<Transform>();
        // add points
        pathPoints.AddRange(gameManagerControler.getPath().GetComponentsInChildren<Transform>());
        // remove parrent
        pathPoints.RemoveAt(0);

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
            
        } else if(Vector3.Distance(transform.position,castle.position) < 1.0f) {
            //take damage
            gameManagerControler.TakeDamage(enemyStrenght);
            // Enemy is at the target
            Die();
            return;
        }

        MoveToVector(target.position);
    }

    // Let the enemy walk towards a target
    public void MoveToVector(Vector3 target) 
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,target,step);
        // Let enemy look at target
        
        Quaternion targetRotation = Quaternion.LookRotation( target );
        targetRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, Time.deltaTime);
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
