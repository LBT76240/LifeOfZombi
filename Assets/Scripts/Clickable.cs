using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Action {
    Prendre, Manger
};

public abstract class Clickable : MonoBehaviour {
    

    //A mettre dans le GameManager
    public Texture2D defaultCursor;
    public Texture2D collectibleCursor;
    public Texture2D mangerCursor;

    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    public Action action;
    

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(defaultCursor, hotspot, curMod);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   

    protected abstract  void OnMouseDownAction();

    public void OnMouseDown() {
        OnMouseDownAction();
    }

    void OnMouseEnter() {
        if (gameObject.tag == "Collectible") {
            updateCursor();
        }
    }

    public void updateCursor() {
        if (action == Action.Prendre) {
            Cursor.SetCursor(collectibleCursor, hotspot, curMod);
        } else if (action == Action.Manger) {
            Cursor.SetCursor(mangerCursor, hotspot, curMod);
        }
    }

    protected abstract void OnMouseRightAction();

    void OnMouseOver() {
        if(Input.GetMouseButtonDown(1)){
            OnMouseRightAction();
        }
    }


    void OnMouseExit() {
        Cursor.SetCursor(defaultCursor, hotspot, curMod);
    }

}
