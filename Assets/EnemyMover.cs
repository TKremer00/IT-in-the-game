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
        if(Vector3.Distance(transform.position,target.position) > 1.0f){
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
        targetRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, Time.deltaTime);
    }
    
    // The destory the enemy
    private void Die()
    {
        Destroy(gameObject);
    }
}
