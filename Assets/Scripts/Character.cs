using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interactible {

    Vector3 target;

    [SerializeField]
    [Tooltip("Sets the movement speed of the zombie")]
    float speed = 1.5f;

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
    
    void FaceClickedPoint() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        transform.eulerAngles = new Vector3(transform.rotation.x, direction.x > 0 ? 0 : -180, transform.rotation.z);
    }


    void UpdateTarget() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.y = transform.position.y;    //  Horizontal movement only
        target.z = transform.position.z;
    }

    // Use this for initialization
    void Start () {
        target = transform.position;
        action = Action.Prendre;
        Animator = GetComponent<Animator>();
        Animator.StopPlayback();
        Animator.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            UpdateTarget();
            Animator.enabled = true;
            isTargetOverWhenClicking = GetComponent<BoxCollider2D>().bounds.Contains(target);

            //  Play the sound and face the target only if the mouse has not clicked on the character
            if (!isTargetOverWhenClicking)
            {
                FaceClickedPoint();
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

        if (transform.position == target)
        {
            Animator.Play(Animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0);

        }

        //  Move only if the target is not on the character
        if (!isTargetOverWhenClicking)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //  If the character reaches the target, stop playing the walking sound
        if (Vector3.Distance(transform.position, target) < 0.1) {
            audioSource.loop = false;
            audioSource.Stop();
        }
    }


    override protected void OnMouseDownAction() {
        audioSource.clip = rhhhSound;
        audioSource.Play();
    }

    protected override void OnMouseRightAction() {
        return;
    }
}
