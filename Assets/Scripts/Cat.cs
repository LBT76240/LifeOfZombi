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

    GameObject zombi;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalCat;
        audioSource = GetComponent<AudioSource>();

        listOfAction = new List<Action>();
        listOfAction.Add(Action.Caresser);
        listOfAction.Add(Action.Manger);
        index = 0;
        action = listOfAction[index];
        zombi = GameObject.Find("zombi");

        for (int i = 0; i < GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_zombie)
            {
                spriteRenderer.sprite = zombieCat;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnMouseDownAction() {
        
        Interact(action);
        return;
    }

    override
     protected void OnMouseRightAction() {
        print("Pressed right click.");
        index++;
        if (index == listOfAction.Count) {
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
        print(1);
        bool doneWalking = false;
        while (!doneWalking) {
            yield return new WaitForSeconds(0.1f);
            if (zombi.GetComponent<Character>().IsDoneWalking) {
                doneWalking = true;

            }

        }
        print(2);
        if (Mathf.Abs(target.x - zombi.transform.position.x) < 0.2) {
            int i = isAlreadyStated();
            switch (action) {
                case Action.Caresser:
                    audioSource.clip = caressedSound;
                    audioSource.Play();
                    if (i >= GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count)
                    {
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_humain);
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral += 2.5f;
                    }
                    break;
                case Action.Manger:
                    //  Transform to ZOMBIIIIIIIE
                    i = isAlreadyStated();
                    if(i >= GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count)
                    {
                        spriteRenderer.sprite = zombieCat;
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_zombie);
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral -= 2.5f;
                        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItem(Item.PoilDeChat);
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
}
