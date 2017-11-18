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

    public bool can_select = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(this.GetComponentInParent<RectTransform>().rect.width, this.GetComponentInParent<RectTransform>().rect.height);
        GetComponent<BoxCollider2D>().offset = new Vector2( - this.GetComponentInParent<RectTransform>().rect.width / 2,
                                                                   + this.GetComponentInParent<RectTransform>().rect.height / 2);
        GetComponent<BoxCollider2D>().transform.position = GetComponentInParent<RectTransform>().transform.position;
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
        if (can_select && !GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            updateCursor();
        }
    }

    public void OnMouseDown()
    {
        if (can_select && !GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            Cursor.SetCursor(cursorMouse, hotspot, curMod);
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting = true;
            can_select = false;
        }
    }

    void OnMouseExit()
    {
        if (can_select && !GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting)
        {
            Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
        }
    }

}
