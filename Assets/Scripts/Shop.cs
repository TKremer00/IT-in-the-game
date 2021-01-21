 using UnityEngine;

public class Shop : MonoBehaviour{

    public GameManagerControler gameManagerControler;
    public GameObject button;

    public void Start (){
        Debug.Log("test");
        GameObject[] allTurrets = gameManagerControler.getAllTurrets();
        for (int i = 0; i < allTurrets.Length; i++)
        {
            GameObject newButton = Instantiate(button,transform.position,transform.rotation);
            Debug.Log("Test button");
            newButton.transform.parent = gameObject.transform;
            TurretBuy turretBuy = newButton.GetComponentInChildren<TurretBuy>();
            turretBuy.turret=allTurrets[i];
            //TODO: change this to the price of the turret
            turretBuy.price = allTurrets[i].GetComponent<Turret>().price;
        }
    }
}
