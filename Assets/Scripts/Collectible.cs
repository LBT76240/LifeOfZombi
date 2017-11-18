using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactible {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


  

    override
    protected void OnMouseDownAction() {
        print("Onclick");
    }
}
