using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interactible {

    Vector3 target;

    public float maxX = 8;
    public float minX = -8;

    public float minY = -3;

    [SerializeField]
    [Tooltip("Sets the movement speed of the zombie")]
    float speed = 1.5f;

    private float initialSpeed;

    Animator Animator;

    [SerializeField]
    [Tooltip("Sound played when clicking on the zombie")]
    AudioClip rhhhSound;

    [SerializeField]
    [Tooltip("Sound played when walking")]
    AudioClip walkSound;
 
    private AudioSource audioSource;

    /// <summary>
    ///     True if the target toward the character must walk to is over the current position of the character when pointing and clicking
    /// </summary>
    private bool isTargetOverWhenClicking;

    /// <summary>
    ///     The character rotates to look at the mouse
    /// </summary>

    /// 

    private bool isWalking;

    public bool IsWalking
    {
        get
        {
            return this.isWalking;
        }
    }

    public Vector3 getTarget() {
        return target;
    }

    void FaceClickedPoint() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        transform.eulerAngles = new Vector3(transform.rotation.x, direction.x > 0 ? 0 : -180, transform.rotation.z);
    }


    void UpdateTarget(Vector3 newTarget) {
        target = newTarget;
        target.y = transform.position.y;    //  Horizontal movement only
        target.z = transform.position.z;

        if(target.x<minX) {
            target.x = minX;
        }

        if (target.x > maxX) {
            target.x = maxX;
        }

        
    }

    // Use this for initialization
    void Start() {

        initialSpeed = speed;
        isWalking = false;

        target = transform.position;
        action = Action.Prendre;
        Animator = GetComponent<Animator>();
        Animator.StopPlayback();
        Animator.enabled = true;
        audioSource = GetComponent<AudioSource>();

        if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getCurrentScene() == 1)
        {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getLastScene() == 0)
            {
                Vector2 pos;
                pos.x = -2.22f;
                pos.y = 2.78f;
                gameObject.transform.position = pos;
                FaceClickedPoint();
            }
            else
            {
                Vector2 pos;
                pos.x = 7.4f;
                pos.y = 2.78f;
                gameObject.transform.position = pos;
                FaceClickedPoint();
            }
        }
        else if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getCurrentScene() == 2)
        {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getLastScene() == 1)
            {
                Vector2 pos;
                pos.x = -7.4f;
                pos.y = -0.3f;
                gameObject.transform.position = pos;
                FaceClickedPoint();
            }
            else
            {
                Vector2 pos;
                pos.x = 7.4f;
                pos.y = -0.3f;
                gameObject.transform.position = pos;
                FaceClickedPoint();
            }
        }
        target = transform.position;
    }

    void Walk() {
        if (minY < Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
        {
            UpdateTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            FaceClickedPoint();
            audioSource.clip = walkSound;
            audioSource.loop = true;
            audioSource.Play();

            isWalking = true;

        }
    }

    /// <summary>
    ///     Called by grandma so that Zombi walks slowly with her toward the other side of the road
    /// </summary>
    public void WalkWithGrandma() {
        UpdateTarget(new Vector3(7.0f, transform.position.y, transform.position.z));
        speed = GameObject.Find("mami").GetComponent<Grandma>().speed;
        audioSource.clip = walkSound;
        audioSource.loop = true;
        audioSource.Play();
        isWalking = true;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0)) {
            
            Vector3 tempTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tempTarget.y = transform.position.y;    //  Horizontal movement only
            tempTarget.z = transform.position.z;

            isTargetOverWhenClicking = GetComponent<BoxCollider2D>().bounds.Contains(tempTarget);

            //  Play the sound and face the target only if the mouse has not clicked on the character
            if (!isTargetOverWhenClicking)
            {
                Walk();
                //Animator.enabled = true;
            }
        }

        //  Move only if the target is not on the character
        
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


        //  If the character reaches the target, stop playing the walking sound
        if (Mathf.Abs(transform.position.x - target.x) < 0.1) {
            if(audioSource.clip == walkSound)
            {
                audioSource.loop = false;
                audioSource.Stop();
            }
            Animator.Play(Animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0);

            isWalking = false;
            speed = initialSpeed;
        }
    }


    override protected void OnMouseDownAction() {
        audioSource.clip = rhhhSound;
        audioSource.loop = false;
        audioSource.Play();
        target.x = this.transform.position.x;
    }

    protected override void OnMouseRightAction() {
        return;
    }
}
