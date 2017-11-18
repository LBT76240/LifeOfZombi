﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Prendre, Manger,Default,Droite,Gauche
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
        if (!GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            OnMouseDownAction();
        }
        else
        {
            //TODO action avec l'objet
            int i = 0;
            for(i=0; i<GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items.Count; i++)
            {
                if(!GameObject.Find("ImageItem" + (i + 1)).GetComponent<MenuSelector>().can_select)
                {
                    break;
                }
            }
            Debug.Log(i + 1);
        }
    }

    

    public void updateCursor() {
        
        Texture2D test = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(action);
        if (test == null) {
            print("null text");
        }
        Cursor.SetCursor(test, hotspot, curMod);
        
    }
    void OnMouseEnter() {
        if (!GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            updateCursor();
        }

    }

    protected abstract void OnMouseRightAction();

    void OnMouseOver() {
        if(Input.GetMouseButtonDown(1) && !GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            OnMouseRightAction();
        }
        else if(Input.GetMouseButtonDown(1) && !GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().resetCanSelect();
        }
    }


    void OnMouseExit() {
        if (!GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
        }
    }

}
