using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{

    public Action action;
    public Texture2D cursorMouse;
    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    bool selected = false;
    public bool Selected
    {
        get
        {
            return selected;
        }
        set
        {
            selected = Selected;
        }
    }

    public bool can_select = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateCursor()
    {

        Texture2D test = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(action);
        if (test == null)
        {
            print("null text");
        }
        Cursor.SetCursor(test, hotspot, curMod);

    }

    void OnMouseEnter()
    {
        if (!selected && can_select)
        {
            updateCursor();
        }
    }

    public void OnMouseDown()
    {
        if (!selected && can_select)
        {
            Cursor.SetCursor(cursorMouse, hotspot, curMod);
        }
        else
        {
            //TODO déclencher l'action ou non, supprimer l'item du menu etc
        }
    }

    void OnMouseExit()
    {
        if (!selected && can_select)
        {
            Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
        }
    }

}
