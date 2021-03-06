﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : Interactible {






    public Item item;
    GameObject zombi;

    List<Action> listOfAction;
    int index = -1;

	// Use this for initialization
	void Start () {
        zombi = GameObject.Find("zombi");
        listOfAction = new List<Action>();
        listOfAction.Add(Action.Prendre);
        listOfAction.Add(Action.Manger);
        index = 0;
        action = listOfAction[index];
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    


    override
    protected void OnMouseDownAction() { 
        StartCoroutine(FinishWalking());

    }

    IEnumerator FinishWalking() {
        
        
        yield return new WaitForSeconds(0.1f);
        if(zombi==null) {
            zombi = GameObject.Find("zombi");
        }
        Vector3 target = zombi.GetComponent<Character>().getTarget();
        bool doneWalking = false;
        while (!doneWalking) {
            yield return new WaitForSeconds(0.1f);
            if (zombi.GetComponent<Character>().IsDoneWalking) {
                doneWalking = true;

            }
            
        }
        
        if (Mathf.Abs(target.x - zombi.transform.position.x) < 0.2) {
            if (action == Action.Prendre) {
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItem(item);
                Texture2D textureCursor = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);

                hotspot.x = textureCursor.height / 2;
                hotspot.y = textureCursor.width / 2;
                Cursor.SetCursor(textureCursor, hotspot, curMod);
                Destroy(gameObject);
            } else
            if (action == Action.Manger) {
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItemTaken(item);
                Texture2D textureCursor = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);

                hotspot.x = textureCursor.height / 2;
                hotspot.y = textureCursor.width / 2;
                Cursor.SetCursor(textureCursor, hotspot, curMod);
                Destroy(gameObject);
            }

        }


    }

    override
    protected void OnMouseRightAction() {
        print("Pressed right click.");
        index++;
        if(index == listOfAction.Count) {
            index = 0;
        }
        action = listOfAction[index];

        updateCursor();
    }

    override
    protected void actionObject(Item item) {
        return;
    }
}
