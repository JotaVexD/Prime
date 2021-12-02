using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public static int ammoValue;
    Text ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoValue == 99999){
            ammo.text = "∞";
        }else{
            ammo.text = "" + ammoValue;
        }
    }
}
