using UnityEngine;

public class GameManagerControler : MonoBehaviour
{
    public float money = 0.0f;
    public float health = 1f;

    public GameObject selectedTurret;

    public void SetMoney(float money) 
    {
        // Update ui here
        this.money = money;
    }
    
    public float GetMoney() 
    {
        return money;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // Update ui here
    }
    
    public float GetHealth() 
    {
        return health;
    }

    public GameObject getSelectedTurret(){
        return selectedTurret;
    }

    public void setSelectedTurret(GameObject turret){
        selectedTurret = turret;
    }

    public void removeSelectedTurret(){
        selectedTurret = null;
    }
}
