using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour{

    public GameManagerControler gameManagerControler;
    public GameObject button;

    public void Start (){
        Debug.Log("test");
        GameObject[] allTurrets = gameManagerControler.getAllTurrets();
        for (int i = 0; i < allTurrets.Length; i++)
        {
            GameObject newButton = Instantiate(button,transform.position,transform.rotation);
            newButton.transform.parent = gameObject.transform;
            TurretBuy turretBuy = newButton.GetComponentInChildren<TurretBuy>();
            turretBuy.turret=allTurrets[i];
            //TODO: change this to the price of the turret
            turretBuy.price = 1f;
        }
    }

//     //1 public void purchase...turret is a button, copy to make a new
//     public void PurchaseStandardTurret (){
//         Debug.Log("standard turret purchased");
//         gameManagerControler.setSelectedTurret(gameManagerControler.selectedTurret);
//     }

//     public void PurchaseOtherTurret (){
//         Debug.Log("other turret purchased");
//         //gameManagerControler.setSelectedTurret(gameManagerControler.selectedTurret2);
//     }

}
