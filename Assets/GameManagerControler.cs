using UnityEngine;

public class GameManagerControler : MonoBehaviour
{
    public float money = 0.0f;
    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMoney(float money) {
        // Update ui here
        this.money = money;
    }
    
    public float GetMoney() {
        return money;
    }

    public void TakeDamage(float damage){
        health -= damage;
    }
    
    public float GetHealth() {
        return health;
    }
}
