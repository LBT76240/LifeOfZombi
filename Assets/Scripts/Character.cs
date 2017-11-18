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
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateTarget();
            FaceClickedPoint();
 
            Animator.enabled = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position==target)
        {
            Animator.Play(Animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0);
            
        }
    }


    override protected void OnMouseDownAction() {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
        //audio.Play(44100);
    }

    protected override void OnMouseRightAction() {
        return;
    }
}
