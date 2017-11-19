﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : PNJ {

    [SerializeField]
    [Tooltip("Sprite of the normal grandma")]
    Sprite normalGrandma;

    [SerializeField]
    [Tooltip("Sprite of the zombie grandma")]
    Sprite zombieGrandma;

    [SerializeField]
    [Tooltip("Speed of the grandma when crossing the street")]
    public float speed;

    //[SerializeField]
    //[Tooltip("Sound played when the cat is caressed")]
    //AudioClip caressedSound;

    GameObject zombi;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    Animator Animator;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalGrandma;
        audioSource = GetComponent<AudioSource>();

        listOfAction = new List<Action>();
        listOfAction.Add(Action.Help);
        listOfAction.Add(Action.DontHelp);
        index = 0;
        action = listOfAction[index];
        zombi = GameObject.Find("zombi");

        Animator = GetComponent<Animator>();
        Animator.enabled = false;
    }

    // Update is called once per frame
    void Update() {
    }

    protected override void OnMouseDownAction() {
        Interact(action);
        return;
    }

    override
     protected void OnMouseRightAction() {
        print("Pressed right click.");
        index++;
        if (index == listOfAction.Count)
        {
            index = 0;
        }
        action = listOfAction[index];

        updateCursor();
    }

    public override void Interact(Action action) {
        StartCoroutine(FinishWalking(action));
    }

    /// <summary>
    ///     Makes grandma walk toward the right side of the road
    /// </summary>
    IEnumerator WalkTowardRightSide() {
        while (Mathf.Abs(7.0f-transform.position.x)>0.1)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, transform.position.z);
            Debug.Log(transform.position.x);
            Animator.enabled = true;
            yield return null;
        }
        if (Mathf.Abs(7.0f - transform.position.x) < 0.1)
            Animator.enabled = false;
    }


    IEnumerator FinishWalking(Action action) {
        yield return new WaitForSeconds(0.1f);
        Vector3 target = zombi.GetComponent<Character>().getTarget();
        bool doneWalking = false;
        while (!doneWalking)
        {
            yield return new WaitForSeconds(0.1f);
            if (!zombi.GetComponent<Character>().IsWalking)
            {
                doneWalking = true;

            }

        }
        if (Mathf.Abs(target.x - zombi.transform.position.x) < 0.2)
        {
            switch (action)
            {
                case Action.Help:
                    //  Grandma crosses the road thanks to the wonderful help of Zombi, who is such an amazing character making great efforts to become human
                    StartCoroutine("WalkTowardRightSide");

                    //  Make Zombi forward with the grandma
                    zombi.GetComponent<Character>().WalkWithGrandma();
                    break;
                case Action.DontHelp:
                    //  Transform to ZOMBIIIIIIIE
                    spriteRenderer.sprite = zombieGrandma;
                    GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItem(Item.OsDeGrandMere);
                    break;
                default:
                    break;
            }
        }

    }

    public override void Interact(Item item) {
        return;
    }
}