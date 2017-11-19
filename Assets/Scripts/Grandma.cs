using System;
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

    [SerializeField]
    [Tooltip("Sound played when the cat is eaten")]
    AudioClip eatenSound;

    //[SerializeField]
    //[Tooltip("Sound played when the cat is caressed")]
    //AudioClip caressedSound;

    GameObject zombi;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;

    Animator Animator;

    bool alreadyInterract = false;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalGrandma;
        audioSource = GetComponent<AudioSource>();

        listOfAction = new List<Action>();
        listOfAction.Add(Action.Help);
        index = 0;
        action = listOfAction[index];
        zombi = GameObject.Find("zombi");

        Animator = GetComponent<Animator>();
        Animator.enabled = false;

        for (int i = 0; i < GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count; i++) {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_zombie) {
                spriteRenderer.sprite = zombieGrandma;
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

    /// <summary>
    ///     Makes grandma walk toward the right side of the road
    /// </summary>
    IEnumerator WalkTowardRightSide() {
        while (Mathf.Abs(7.0f-transform.position.x)>0.1)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, transform.position.z);
            
            Animator.enabled = true;
            yield return null;
        }
        if (Mathf.Abs(7.0f - transform.position.x) < 0.1) {
            Animator.enabled = false;
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_humain);
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral += 2.5f;
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItem(Item.Piece);
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().checkTime();
        }
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
            switch (action) {
                case Action.Help:
                    if (!alreadyInterract) { 

                        if(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral > 2 ) {
                            StartCoroutine(WalkTowardRightSide());
                            //  Grandma crosses the road thanks to the wonderful help of Zombi, who is such an amazing character making great efforts to become human
                            //  Make Zombi forward with the grandma
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                            zombi.GetComponent<Character>().WalkWithGrandma();
                            alreadyInterract = true;
                        } else {
                            //  Transform to ZOMBIIIIIIIE
                            audioSource.clip = eatenSound;
                            audioSource.Play();
                            spriteRenderer.sprite = zombieGrandma;
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().currentTime += GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().tempsAction;
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().addItem(Item.OsDeGrandMere);
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Add(state_zombie);
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral -= 2.5f;
                            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().checkTime();
                            alreadyInterract = true;
                        }
                        
                        
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
        return;
    }
}
