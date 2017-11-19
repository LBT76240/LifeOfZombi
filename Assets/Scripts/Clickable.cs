using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Action {
    Prendre, Manger,Default,Droite,Gauche, Caresser
};

public abstract class Clickable : MonoBehaviour {


    public Item objetInteractible;

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
            if(objetInteractible == GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items[i])
            {
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
        yield return new WaitForSeconds(0.1f);
        bool doneWalking = false;
        while (!doneWalking)
        {
            yield return new WaitForSeconds(0.1f);
            if (!GameObject.Find("zombi").GetComponent<Character>().IsWalking)
            {
                doneWalking = true;

            }

        }
        if (Mathf.Abs(transform.position.x - GameObject.Find("zombi").transform.position.x) < 0.2)
        {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Items.RemoveAt(i);
            GameObject.Find("ImageItem" + (i + 1)).GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("uimanager").GetComponent<UIManager>().sprite_default;
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currently_selecting = false;
            updateCursor();
            //Inclure ici l'appel à la fonction virtuelle
        }

    }
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
