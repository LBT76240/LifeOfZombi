using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    int currentLevel;

    List<Collectible> items;

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

    public List<Collectible> Items
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
		
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
