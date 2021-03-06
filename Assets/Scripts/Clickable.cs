﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action {
    Prendre, Manger, Default, Droite, Gauche, Caresser, DontHelp, Help
};

public abstract class Clickable : MonoBehaviour {


    public Item objetInteractible;
    public Item objetInteractible2;

    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    public Action action;
    

	// Use this for initialization
	void Start () {

        Texture2D textureCursor = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);

        hotspot.x = textureCursor.height/2;
        hotspot.y = textureCursor.width / 2;
        Cursor.SetCursor(textureCursor, hotspot, curMod);
        
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
            print("MouseDown");
            if(objetInteractible == GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items[i] || objetInteractible2 == GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items[i])
            {
                print("Lol");
                Interact2(action,i);
            }
        }
    }

    public void Interact2(Action action, int i)
    {
        StartCoroutine(ObjAction(action,i));
    }

    IEnumerator ObjAction(Action action,int i)
    {
        print("Lol 1 ");
        yield return new WaitForSeconds(0.1f);
        Vector3 target = GameObject.Find("zombi").GetComponent<Character>().getTarget();
        bool doneWalking = false;
        while (!doneWalking)
        {
            yield return new WaitForSeconds(0.1f);
            if (GameObject.Find("zombi").GetComponent<Character>().IsDoneWalking)
            {
                doneWalking = true;

            }

        }
        print("Lol 2 ");
        if (Mathf.Abs(target.x - GameObject.Find("zombi").transform.position.x) < 0.2)
        {
            Item item = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items[i];

            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items.RemoveAt(i);
            for (i=i+1; i< GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items.Count+1;i++)
            {
                GameObject.Find("ImageItem" + (i)).GetComponent<Image>().sprite = GameObject.Find("ImageItem" + (i+1)).GetComponent<Image>().sprite;
                GameObject.Find("ImageItem" + (i)).GetComponent<MenuSelector>().cursorMouse = GameObject.Find("ImageItem" + (i + 1)).GetComponent<MenuSelector>().cursorMouse;
            }
            GameObject.Find("ImageItem" + (i)).GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("uimanager").GetComponent<UIManager>().sprite_default;
            GameObject.Find("ImageItem" + (i)).GetComponent<MenuSelector>().cursorMouse = GameObject.FindGameObjectWithTag("uimanager").GetComponent<UIManager>().texture_default;
            GameObject.Find("ImageItem" + (i)).GetComponent<MenuSelector>().can_select = false;
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().resetCanSelect();

            updateCursor();
            //Inclure ici l'appel à la fonction virtuelle
            print("Lol 3 ");
            actionObject(item);
        }

    }

    protected abstract void actionObject(Item item);

    public void updateCursor() {
        
        Texture2D textureCursor = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(action);
        
        hotspot.x = textureCursor.height / 2;
        hotspot.y = textureCursor.width / 2;

        Cursor.SetCursor(textureCursor, hotspot, curMod);
        
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
            Texture2D textureCursor = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);

            hotspot.x = textureCursor.height / 2;
            hotspot.y = textureCursor.width / 2;
            Cursor.SetCursor(textureCursor, hotspot, curMod);
        }
    }

}
