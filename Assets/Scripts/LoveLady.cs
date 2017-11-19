using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveLady : PNJ {

    [SerializeField]
    [Tooltip("Sprite of the normal laday")]
    Sprite normalLady;

    [SerializeField]
    [Tooltip("Sprite of the lady in love")]
    Sprite ladyInLove;

    [SerializeField]
    [Tooltip("Sprite of the zombie lady")]
    Sprite zombieLady;

    GameObject zombi;

    [SerializeField]
    [Tooltip("Sound played when the lady is in love")]
    AudioClip inLoveSound;

    [SerializeField]
    [Tooltip("Sound played when the lady is scared")]
    AudioClip scaredSound;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    bool alreadyInterract = false;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalLady;
        audioSource = GetComponent<AudioSource>();
        listOfAction = new List<Action>();
        listOfAction.Add(Action.Default);
        
        zombi = GameObject.Find("zombi");
        index = 0;
        action = listOfAction[index];
        for (int i = 0; i < GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count; i++) {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_zombie) {
                spriteRenderer.sprite = zombieLady;
                alreadyInterract = true;
            }
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_humain) {
                spriteRenderer.sprite = ladyInLove;
                alreadyInterract = true;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }

    protected override void OnMouseDownAction() {
        Interact(action);
        return;
    }

    protected override void OnMouseRightAction() {
        print("Pressed right click.");
        index++;
        if (index == listOfAction.Count) {
            index = 0;
        }
        action = listOfAction[index];

        updateCursor();
        return;
    }

    public override void Interact(Action action) {
        switch (action)
        {
            case Action.Manger:
                //  Transform to ZOMBIIIIIIIE
                spriteRenderer.sprite = zombieLady;
                break;
            default:
                break;
        }
    }

    public override void Interact(Item item) {
        print("Interract Item");
        switch(item)
        {
            case Item.FleurCimetiere:
                spriteRenderer.sprite = zombieLady;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_zombie);
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral -= 2.5f;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().checkTime();
                alreadyInterract = true;
                audioSource.clip = scaredSound;
                audioSource.Play();
                break;
            case Item.FleurFleuriste:
                audioSource.clip = inLoveSound;
                audioSource.Play();
                spriteRenderer.sprite = ladyInLove;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_humain);
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral += 2.5f;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().checkTime();
                alreadyInterract = true;
                break;
        }
        return;
    }

    override
    protected void actionObject(Item item) {
        if(!alreadyInterract) {
            Interact(item);
        }
        
    }
}
