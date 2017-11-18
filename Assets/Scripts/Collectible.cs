using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : Interactible {




   


    

    List<Action> listOfAction;
    int index = -1;

	// Use this for initialization
	void Start () {
        
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
        print("Onclick");
        
        for (int i = 0; i < listOfAction.Count; i++) {
            print(listOfAction[i]);
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
}
