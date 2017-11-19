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


    public GameObject flowerGood;

    bool alreadyInterract = false;

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

        for (int i = 0; i < GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count; i++) {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_zombie) {
                spriteRenderer.sprite = zombieSeller;
                alreadyInterract = true;
            }
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_humain) {
                Vector3 pos = transform.position;
                pos.x = 7.0f;
                transform.position = pos;
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
            if (zombi.GetComponent<Character>().IsDoneWalking)
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
                    if (!alreadyInterract) {
                        //  Transform to ZOMBIIIIIIIE
                        spriteRenderer.sprite = zombieSeller;
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_zombie);
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral -= 2.5f;

                        spawnFlower();
                        alreadyInterract = true;
                    }
                    break;
                default:
                    break;
            }
        }

    }

    public override void Interact(Item item) {
        
        return;
    }

    override
    protected void actionObject(Item item) {
        if (!alreadyInterract) {
            spawnFlower();
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_humain);
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral += 2.5f;
            alreadyInterract = true;
        }
        return;
    }

    void spawnFlower() {
        Instantiate(flowerGood, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
