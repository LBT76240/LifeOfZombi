using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum Item {
    Chat,Piece,FleurFleuriste,FleurCimetiere,Ballon,Casquette,PoilDeChat,OsDeGrandMere
};

public class GameManager : MonoBehaviour {

    public Sprite spriteDefault;
    public Sprite spriteChat;
    public Sprite spritePiece;
    public Sprite spriteFleurFleuriste;
    public Sprite spriteFleurCimetiere;
    public Sprite spriteBallon;
    public Sprite spriteCasquette;
    public Sprite spritePoilDeChat;
    public Sprite spriteOsDeGrandMere;

    [SerializeField]
    int currentLevel;

    List<Item> items;

    [SerializeField]
    int maxMoral;

    [SerializeField]
    int minMoral;

    int moral;

    [SerializeField]
    int time;

    List<bool> actions;

    public Texture2D defaultCursor;
    public Texture2D collectibleCursor;
    public Texture2D mangerCursor;
    public Texture2D gaucheCursor;
    public Texture2D droiteCursor;
    public Texture2D textureChat;

    public Texture2D getTexture(Action action) {
        switch (action) {
            case Action.Prendre:
                return collectibleCursor;
            case Action.Manger:
                return mangerCursor;
            case Action.Droite:
                return droiteCursor;
            case Action.Gauche:
                return gaucheCursor;
            default:
                return defaultCursor;
        }
        
            
    }

    public Sprite getSprite(Item item) {
        switch (item) {
            case Item.Chat:
                return spriteChat;
            case Item.Ballon:
                return spriteBallon;
            case Item.Piece:
                return spritePiece;
            case Item.FleurFleuriste:
                return spriteFleurFleuriste;
            case Item.FleurCimetiere:
                return spriteFleurCimetiere;
            case Item.Casquette:
                return spriteCasquette;
            case Item.PoilDeChat:
                return spritePoilDeChat;
            case Item.OsDeGrandMere:
                return spriteOsDeGrandMere;
            default:
                return spriteDefault;
        }
    }

    public Texture2D getTexture(Item item)
    {
        switch (item)
        {
            case Item.Chat:
                return textureChat;
            default:
                return defaultCursor;
        }
    }

    public void addItem (Item item) {
        items.Add(item);
        GameObject.Find("ImageItem" + (items.Count)).GetComponent<Image>().sprite = GetComponent<GameManager>().getSprite(GetComponent<GameManager>().Items[items.Count -1]);
        GameObject.Find("ImageItem" + (items.Count)).GetComponent<MenuSelector>().cursorMouse = GetComponent<GameManager>().getTexture(item);
        GameObject.Find("ImageItem" + (items.Count)).GetComponent<MenuSelector>().can_select = true;
    }

    public int CurrentLevel
    {
        get
        {
            return this.currentLevel;
        }
        set
        {
            this.currentLevel = value;
        }
    }

    public List<Item> Items
    {
        get
        {
            return this.items;
        }
        set
        {
            this.items = value;
        }
    }

    public int MaxMoral
    {
        get
        {
            return this.maxMoral;
        }
    }

    public int MinMoral
    {
        get
        {
            return this.minMoral;
        }
    }

    public int Moral
    {
        get
        {
            return this.moral;
        }
        set
        {
            this.moral = value;
        }
    }

    public int Time
    {
        get
        {
            return this.time;
        }
    }

    public List<bool> Actions
    {
        get
        {
            return this.actions;
        }
        set
        {
            this.actions = value;
        }
    }

    // Use this for initialization
    void Start () {
        items = new List<Item>();

    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
