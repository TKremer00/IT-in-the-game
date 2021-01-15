using UnityEngine;

public class TurretPlacer : MonoBehaviour
{
    public GameManagerControler gameManagerControler;

    // default unity function
    void OnMouseUp() {
        // check if there is a turret
        if(gameManagerControler.selectedTurret != null){
            // add the turret to the screen and delete the placement
            Instantiate(gameManagerControler.selectedTurret,transform.position,transform.rotation);
            gameManagerControler.setSelectedTurret(null);
            Destroy(gameObject);
        }
    }
}
