﻿using System;
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

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalLady;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    protected override void OnMouseDownAction() {

        return;
    }

    protected override void OnMouseRightAction() {
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
        switch(item)
        {
            case Item.FleurCimetiere:
                spriteRenderer.sprite = zombieLady;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_zombie);
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral -= 2.5f;
                
                break;
            case Item.FleurFleuriste:
                spriteRenderer.sprite = ladyInLove;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_humain);
                GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral += 2.5f;
                break;
        }
        return;
    }

    override
    protected void actionObject(Item item) {
        Interact(item);
    }
}
