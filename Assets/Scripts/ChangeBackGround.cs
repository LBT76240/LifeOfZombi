using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackGround : MonoBehaviour {

    public Sprite spriteRue;
    public Sprite spriteCimetiere;

    public void ChangeBack(int level) {
        switch(level) {
            case 1:
                gameObject.GetComponent<Image>().sprite = spriteCimetiere;
                break;
            case 2:
                gameObject.GetComponent<Image>().sprite = spriteRue;
                break;
            default:
                break;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //gameObject.GetComponent<Image>().sprite = spriteRue;
	}
}
