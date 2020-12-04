using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerControler : MonoBehaviour
{

    float money = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetMoney (float money) {
        this.money = money;
    }
    
    float GetMoney () {
        return money;
    }
}
