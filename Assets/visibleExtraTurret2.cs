using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visibleExtraTurret2 : MonoBehaviour {
    public Image nonHero1;
    public Image nonHero2;
    public Image nonHero3;
    // Use this for initialization
    void Start () {

        if (Shop.haveExtraTurret4)
            nonHero1.enabled = false;
        if (Shop.haveExtraTurret5)
            nonHero3.enabled = false;
        if (Shop.haveExtraTurret6)
            nonHero2.enabled = false;
    }
	
}
