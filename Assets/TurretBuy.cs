﻿using UnityEngine;
using UnityEngine.UI;

public class TurretBuy : MonoBehaviour
{
    public GameObject turret;
    public GameManagerControler gameManagerControler;
    public float price;

    public Text text;

    public void Start(){
        gameManagerControler = GameObject.FindObjectOfType<GameManagerControler> ().GetComponent<GameManagerControler> ();
        Debug.Log(GameObject.FindObjectOfType<GameManagerControler> ());
    } 

    public void PurchaseStandardTurret (){
        if(gameManagerControler.GetMoney() >= price && gameManagerControler.getSelectedTurret() == null){
            Debug.Log("standard turret purchased");
            gameManagerControler.setSelectedTurret(turret);
            gameManagerControler.removeMoney(price);
        } else {
            Debug.Log("you can't buy this turret");
        }
    }
    public void PurchaseStandardTurret2 (){
        Debug.Log("yass");
    }

    public void setText(string turretText){
        text.text = turretText;
    }
}