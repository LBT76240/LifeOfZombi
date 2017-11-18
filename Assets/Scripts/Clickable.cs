using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Prendre, Manger,Default
};

public abstract class Clickable : MonoBehaviour {


    

    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    public Action action;
    

	// Use this for initialization
	void Start () {
        

        Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   

    protected abstract  void OnMouseDownAction();

    public void OnMouseDown() {
        OnMouseDownAction();
    }

    

    public void updateCursor() {
        
        Texture2D test = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(action);
        if (test == null) {
            print("null text");
        }
        Cursor.SetCursor(test, hotspot, curMod);
        
    }
    void OnMouseEnter() {

        updateCursor();

    }

    protected abstract void OnMouseRightAction();

    void OnMouseOver() {
        if(Input.GetMouseButtonDown(1)){
            OnMouseRightAction();
        }
    }


    void OnMouseExit() {
        Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
    }

}
