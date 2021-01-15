using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerControler : MonoBehaviour
{
   
    public float money = 0.0f;
    public float health = 1f;
    public TMP_Text moneyText;
    public TMP_Text healthText;
   
    public GameObject selectedTurret;

    public GameObject path;

    void Start() {
        moneyText.SetText(money.ToString());
        healthText.SetText(health.ToString());
    }

    public void addMoney(float addition) 
    {
        // Update ui here
        this.money += addition;
        moneyText.text = money.ToString();
    }

    public void removeMoney(float subtraction) 
    {
        // Update ui here
        this.money -= subtraction;
        moneyText.text = money.ToString();
    }
    
    public float GetMoney() 
    {
        return money;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthText.text = health.ToString();
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

    public GameObject getPath(){
        return path;
    }
}



