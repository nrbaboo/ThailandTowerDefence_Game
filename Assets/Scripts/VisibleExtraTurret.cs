
using UnityEngine;
using UnityEngine.UI;
public class VisibleExtraTurret : MonoBehaviour {

    public Image nonHero1;
    public Image nonHero2;
    public Image nonHero3;
   
    // Use this for initialization
    void Start () {
        
            if (Shop.haveExtraTurret1)
                nonHero1.enabled = false;
            if (Shop.haveExtraTurret2)
                nonHero3.enabled = false;
            if (Shop.haveExtraTurret3)
                nonHero2.enabled = false;
      
    }
	
	// Update is called once per frame
	
}
