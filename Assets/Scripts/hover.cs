using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class hover : MonoBehaviour {
    public Texture2D defaultCursor;
    public Texture2D collectibleCursor;
    public Texture2D mangerCursor;

    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    

    // Use this for initialization
    void Start () {
        Cursor.SetCursor(defaultCursor, hotspot, curMod);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        if(gameObject.tag=="Collectible") {
            Cursor.SetCursor(collectibleCursor, hotspot, curMod);
        }
    }

    void OnMouseExit() {
        Cursor.SetCursor(defaultCursor, hotspot, curMod);
    }

}
