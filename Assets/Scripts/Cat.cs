using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : PNJ {

    [SerializeField]
    [Tooltip("Sprite of the normal cat")]
    Sprite normalCat;

    [SerializeField]
    [Tooltip("Sprite of the zombie cat")]
    Sprite zombieCat;

    [SerializeField]
    [Tooltip("Sound played when the cat is caressed")]
    AudioClip caressedSound;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalCat;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnMouseDownAction() {
        Interact(Action.Caresser);
        return;
    }

    protected override void OnMouseRightAction() {
        return;
    }

    public override void Interact(Action action) {
        switch(action)
        {
            case Action.Caresser:
                audioSource.clip = caressedSound;
                audioSource.Play();
                break;
            case Action.Manger:
                //  Transform to ZOMBIIIIIIIE
                spriteRenderer.sprite = zombieCat;
                break;
            default:
                break;
        }
    }

    public override void Interact(Item item) {
        return;
    }
}
