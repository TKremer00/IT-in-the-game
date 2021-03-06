﻿ using UnityEngine;
 using UnityEngine.UI;

public class Shop : MonoBehaviour{

    public GameManagerControler gameManagerControler;
    public GameObject button;

    public Text text;

    public void Start (){
        GameObject[] allTurrets = gameManagerControler.getAllTurrets();
        for (int i = 0; i < allTurrets.Length; i++)
        {
            GameObject newButton = Instantiate(button,transform.position,transform.rotation);
            Debug.Log("Test button " + i);
            newButton.transform.parent = gameObject.transform;
            TurretBuy turretBuy = newButton.GetComponentInChildren<TurretBuy>();
            turretBuy.turret=allTurrets[i];
            //TODO: change this to the price of the turret
            turretBuy.price = allTurrets[i].GetComponent<Turret>().price;
            turretBuy.setText("Turret " + (i + 1) + " $" + allTurrets[i].GetComponent<Turret>().price);
        }
    }
}
