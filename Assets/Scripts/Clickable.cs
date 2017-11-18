using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour {

    public Sprite mouseSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver() {
        //TODO
    }

    protected abstract  void OnMouseDownAction();

    public void OnMouseDown() {
        OnMouseDownAction();
    }

}
