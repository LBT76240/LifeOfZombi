using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : PNJ {

    [SerializeField]
    [Tooltip("Sprite of the normal seller")]
    Sprite normalSeller;

    [SerializeField]
    [Tooltip("Sprite of the zombie seller")]
    Sprite zombieSeller;

    GameObject zombi;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSeller;
        audioSource = GetComponent<AudioSource>();

        listOfAction = new List<Action>();
        listOfAction.Add(Action.Prendre);
        listOfAction.Add(Action.Manger);
        index = 0;
        action = listOfAction[index];
        zombi = GameObject.Find("zombi");
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
                case Action.Prendre:
                    break;
                case Action.Manger:
                    //  Transform to ZOMBIIIIIIIE
                    spriteRenderer.sprite = zombieSeller;
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
