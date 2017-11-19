using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Item {
    None,Chat,Piece,FleurFleuriste,FleurCimetiere,Ballon,Casquette,PoilDeChat,OsDeGrandMere
};

public enum PNJ_State
{
    Chat_Humain, Chat_Zombie, Vieille_Humain, Vieille_Zombie, Femme_Humain, Femme_Zombie, Vendeur_Humain, Vendeur_Zombie
}

public class GameManager : MonoBehaviour {

    public int lastScene = 0;
    public int currentScene;
    public ChangeBackGround changeBackGround;

    public int getLastScene() {
        return lastScene;
    }

    public int getCurrentScene() {
        return currentScene;
    }

    public void changeCurrentScene(int value) {
        lastScene = currentScene;
        currentScene = value;
        //changeBackGround.ChangeBack(value);
    }

    public CursorMode curMod = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
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
    public List<Item> items_taken;

    public List<PNJ_State> state_pnj;

    [SerializeField]
    float maxMoral;

    [SerializeField]
    float minMoral;

    float moral;

    [SerializeField]
    int time;

    public bool currently_selecting = false ;

    List<bool> actions;

    public Texture2D defaultCursor;
    public Texture2D collectibleCursor;
    public Texture2D mangerCursor;
    public Texture2D gaucheCursor;
    public Texture2D droiteCursor;
    public Texture2D textureChat;
    public Texture2D texturePiece;
    public Texture2D textureFleurFleuriste;
    public Texture2D textureFleurCimetiere;
    public Texture2D textureBallon;
    public Texture2D textureCasquette;
    public Texture2D texturePoilDeChat;
    public Texture2D textureOsDeGrandMere;

    private AudioSource audioSource;

    [SerializeField]
    [Tooltip("Music played in the graveyard")]
    AudioClip graveYardSound;

    [SerializeField]
    [Tooltip("Music played in the city")]
    AudioClip citySound;

    [SerializeField]
    [Tooltip("Music played in the city when humain again")]
    AudioClip cityHumainSound;

    public void playMusicGraveYard() {
        audioSource.clip = graveYardSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void playMusicCity() {
        audioSource.clip = citySound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public Texture2D getTexture(Action action) {
        switch (action) {
            case Action.Prendre:
                return collectibleCursor;
            case Action.Help:
                return collectibleCursor;
            case Action.DontHelp:
                return collectibleCursor;
            case Action.Caresser:
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
            case Item.None:
                return spriteDefault;
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
            case Item.None:
                return defaultCursor;
            case Item.Chat:
                return textureChat;
            case Item.Piece:
                return texturePiece;
            case Item.FleurFleuriste:
                return textureFleurFleuriste;
            case Item.FleurCimetiere:
                return textureFleurCimetiere;
            case Item.Ballon:
                return textureBallon;
            case Item.Casquette:
                return textureCasquette;
            case Item.PoilDeChat:
                return texturePoilDeChat;
            case Item.OsDeGrandMere:
                return textureOsDeGrandMere;
            default:
                return defaultCursor;
        }
    }

    public void addItemTaken(Item item) {
        items_taken.Add(item);
    }

    public void addItem (Item item) {
        items_taken.Add(item);
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

    public float MaxMoral
    {
        get
        {
            return this.maxMoral;
        }
    }

    public float MinMoral
    {
        get
        {
            return this.minMoral;
        }
    }

    public float Moral
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
        audioSource = GetComponent<AudioSource>();
        items = new List<Item>();

    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(1))
        {
            resetCanSelect();
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("_Unload");
        }
	}

    public void resetCanSelect()
    {
        if(currently_selecting)
        {
            for(int i=0;i<items.Count;i++)
            {
                GameObject.Find("ImageItem" + (i+1)).GetComponent<MenuSelector>().can_select = true;
            }
            Cursor.SetCursor(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default), hotspot, curMod);
            currently_selecting = false;
        }
    }
}
